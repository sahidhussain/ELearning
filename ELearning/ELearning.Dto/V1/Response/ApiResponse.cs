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
        public IEnumerable<string> Errors { get; set; }
    }
}
