using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using MovBooks.Core.DataStructures;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Services
{
    public class RecommendService : IRecommendService
    {

        private ILogger<RecommendService> _ilogger;
        private readonly IUnitOfWork _unitOfWork;
        private MLContext mlcontext = new MLContext();
        private string modelPath;

        public RecommendService(ILogger<RecommendService> ilogger, IUnitOfWork unitOfWork, MLContext mlcontext, string modelPath)
        {
            _ilogger = ilogger;
            _unitOfWork = unitOfWork;
            this.mlcontext = mlcontext;
            this.modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip") ?? "";
        }

        public async Task RecommendBooksUserService(int userId, int numberIterations = 20, int aproximationRank = 100)
        {
           

             await Task.Delay(100);
        }

        public async Task RecommendMoviesUserService(int userId, int numberIterations = 20, int aproximationRank = 100)
        {

            await Task.Delay(100);
        }


        public async Task TrainerModelRecommender(int userId, int numberIterations = 20, int aproximationRank = 100)
        {
            (IDataView trainingDataView, IDataView testDataView) = LoadData(this.mlcontext);
            // ML.NET doesn't cache data set by default. Therefore, if one reads a data set from a file and accesses it many times, it can be slow due to
            // expensive featurization and disk operations. When the considered data can fit into memory, a solution is to cache the data in memory. Caching is especially
            // helpful when working with iterative algorithms which needs many data passes. Since SDCA is the case, we cache. Inserting a
            // cache step in a pipeline is also possible, please see the construction of pipeline below.
            trainingDataView = this.mlcontext.Data.Cache(trainingDataView);
            ITransformer model = BuildAndTrainModel(this.mlcontext, trainingDataView, numberIterations, aproximationRank);
            EvaluateModel(this.mlcontext, testDataView, model);
            SaveModel(this.mlcontext, trainingDataView.Schema, model);
            await Task.Delay(100);
        }

        // Load data
        public (IDataView training, IDataView test) LoadData(MLContext mlContext)
        {
            // Load training & test datasets using datapaths
            IDataView trainingDataView = mlContext.Data.LoadFromEnumerable(_unitOfWork.BookRepository.GetRaingsBooks());
            IDataView testDataView = mlcontext.Data.LoadFromEnumerable(_unitOfWork.BookRepository.GetRaingsBooks());

            return (trainingDataView, testDataView);
        }

        // Build and train model
        public ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingDataView, int numberIterations, int aproximationRank)
        {
            // Add data transformations
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "userId")
                .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "movieId"));

            // Set algorithm options and append algorithm
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",//"movieIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = numberIterations,
                ApproximationRank = aproximationRank
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            _ilogger.LogInformation("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            return model;
        }

        // Evaluate model
        public void EvaluateModel(MLContext mlContext, IDataView testDataView, ITransformer model)
        {
            // Evaluate model on test data & print evaluation metrics
            _ilogger.LogInformation("=============== Evaluating the model ===============");
            var prediction = model.Transform(testDataView);

            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");
           
            _ilogger.LogInformation("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            _ilogger.LogInformation("RSquared: " + metrics.RSquared.ToString());
        }

        // Use model for single prediction
        public void UseModelForSinglePrediction(MLContext mlContext, ITransformer model, int userId, int movieId)
        {
            _ilogger.LogInformation("=============== Making a prediction ===============");
            var predictionEngine = mlContext.Model.CreatePredictionEngine<MovieRating, MovieRatingPrediction>(model);
          
            // Create test input & make single prediction
            var testInput = new MovieRating { userId = Convert.ToString(userId), movieId = Convert.ToString(movieId) };

            var movieRatingPrediction = predictionEngine.Predict(testInput);
           
            if (Math.Round(movieRatingPrediction.Score, 1) > 3.5)
            {
                _ilogger.LogInformation("Movie " + testInput.movieId + " is recommended for user " + testInput.userId);
            }
            else
            {
                _ilogger.LogInformation("Movie " + testInput.movieId + " is not recommended for user " + testInput.userId);
            }
        }

        //Save model
        public void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            // Save the trained model to .zip file
            this.modelPath = Path.Combine(Environment.CurrentDirectory, "../Data", "MovieRecommenderModel.zip");

            _ilogger.LogInformation("=============== Saving the model to a file ===============");
            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }

        public ITransformer LoadModelFile()
        {
            ITransformer trainedModel;
            using (FileStream stream = new FileStream(this.modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                trainedModel = this.mlcontext.Model.Load(stream, out var modelInputSchema);
            }
            return trainedModel;
        }
    }
}
