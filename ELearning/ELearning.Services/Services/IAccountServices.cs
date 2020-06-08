using ELearning.Dto.V1.Request;
using ELearning.Dto.V1.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services.Services
{
    public interface IAccountServices
    {
        Task<ApiResponse<string>> RegisterAsync(RegisterRequest req);
        Task<AuthResponse> LoginAsync(LoginRequest req);
    }
}
