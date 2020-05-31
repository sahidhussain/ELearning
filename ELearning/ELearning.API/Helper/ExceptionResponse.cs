using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.API.Helper
{
    public class ExceptionResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public Exceptions Exceptions { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Exceptions
    {
        public string ErrorMessage { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string ErrorPath { get; set; }
    }
}
