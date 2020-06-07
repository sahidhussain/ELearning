using ELearning.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Utilities
{
   public interface IJwtGenerate
    {
        string JwtToken(ApplicationUser user);
    }
}
