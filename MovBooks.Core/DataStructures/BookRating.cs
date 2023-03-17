using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.DataStructures
{
    public class BookRating
    {
        [LoadColumn(0)]
        public string userId;

        [LoadColumn(1)]
        public string movieId;

        [LoadColumn(2)]
        public bool Label;
    }
}
