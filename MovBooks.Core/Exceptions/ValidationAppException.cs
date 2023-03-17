using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Exceptions
{
    
    public class ValidationAppException: Exception
    {
        public string Title { get => Title; set => Title = value; }
        public string Message { get => Message; set => Message = value; }
        public int StatusCode { get => StatusCode; set => StatusCode = value; }
        public ValidationAppException(string message, int statusCode, string title) : base(message)
        {
            StatusCode = statusCode;
            Title = title;
        }
    }
}
