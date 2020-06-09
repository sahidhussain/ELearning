using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Dto.V1.Response
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
