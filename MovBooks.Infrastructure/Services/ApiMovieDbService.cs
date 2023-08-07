using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.Interfaces.Repositorys;
using MovBooks.Infrastructure.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Services
{
    public class ApiMovieDbService : IApiMovieDb
    {
        private HttpClient client = new HttpClient();
        private readonly TheMovieOptions _theMovieOptions;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        const string ROUTE_GENRE_MOVIE = "/genre/movie/list";

        public ApiMovieDbService(IOptions<TheMovieOptions> options, ILogger<ApiMovieDbService> logger,IUnitOfWork unitOfWork)
        {
            _theMovieOptions = options.Value;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task GetGenresApiMovie()
        {
            if (_theMovieOptions.Enable && _theMovieOptions.EnableTrackingGenders)
            {
                try
                {
                    using var httpResponse = await client.GetAsync(_theMovieOptions.Api + ROUTE_GENRE_MOVIE + "?language=" + _theMovieOptions.Language +
                    "&api_key=" + _theMovieOptions.ApiKey + "&include_image_language=" + _theMovieOptions.Language);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var jsonData = await httpResponse.Content.ReadAsStringAsync();
                        var jsonResult = JObject.Parse(jsonData)["genres"];
                        if (jsonResult != null)
                        {
                            foreach (var item in jsonResult)
                            {
                                string name = item.SelectToken("name").ToString();
                                int id = Int32.Parse(item.SelectToken("id").ToString());
                                var nameGender = await _unitOfWork.GenderRepository.FindByName(name);
                                
                                if(nameGender == null)
                                {
                                    var gender = new Genre()
                                    {
                                        Name = name,
                                        IdApi = id,
                                    };
                                    await _unitOfWork.GenderRepository.Add(gender);
                                    await _unitOfWork.SaveChangesAsync();
                                }
                                else
                                {
                                    _logger.LogInformation("This Record Exist = "+name);
                                }

                                _logger.LogInformation("Genre Api = " + name);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception.Message, exception);
                }
            }
        }
    }
}
