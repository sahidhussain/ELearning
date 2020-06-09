using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Dto.V1.Response
{
    public class ErrorResponse: BaseResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }

    public class ErrorModel
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
