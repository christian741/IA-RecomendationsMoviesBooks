using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.CustomEntities
{
    public class TheMovieOptions
    {
        public string Api { get; set; }
        public string ApiKey { get; set; }
        public string Language { get; set; }
        public bool Enable { get; set; }
        public bool EnableTrackingGenders { get; set; }
    }
}
