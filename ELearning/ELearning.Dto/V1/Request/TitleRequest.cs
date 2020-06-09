using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Dto.V1.Request
{
    public class TitleRequest
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
