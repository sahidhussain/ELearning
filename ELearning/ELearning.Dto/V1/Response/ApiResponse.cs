using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Dto.V1.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Exceptions Exception { get; set; }
    }

    public class Exceptions
    {
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string ErrorPath { get; set; }
    }
}
