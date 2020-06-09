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
        #region Roles Management
        Task<ApiResponse<RolesResponse>> AddRoles(RolesRequest req);
        #endregion

        Task<ApiResponse<string>> RegisterAsync(RegisterRequest req, string role = "User");
        Task<AuthResponse> LoginAsync(LoginRequest req);
        Task<AuthResponse> RefreshTokenAsync(string token, string refreshToken);
        Task<ApiResponse<string>> AssignRoleToUser(string userId, string role);
        Task<ApiResponse<List<UsersResponse>>> AllUsers();
    }
}
