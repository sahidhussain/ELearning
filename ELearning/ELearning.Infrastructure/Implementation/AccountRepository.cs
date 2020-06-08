using ELearning.Dto.V1.Request;
using ELearning.Dto.V1.Response;
using ELearning.Entities;
using ELearning.Services.Services;
using ELearning.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Infrastructure.Implementation
{
    public class AccountRepository : IAccountServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtGenerate jwtToken;

        public AccountRepository(UserManager<ApplicationUser> UserManager, IJwtGenerate JwtToken)
        {
            userManager = UserManager;
            jwtToken = JwtToken;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest req)
        {
            var user = await userManager.FindByEmailAsync(req.Email);

            if (user == null)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "This email is not registered." }
                };
            }

            var checkPassword = await userManager.CheckPasswordAsync(user, req.Password);

            if (!checkPassword)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "The email/password doesn't matched." }
                };
            }

            return new AuthResponse()
            {
                Success = true,
                Token = jwtToken.JwtToken(user)
            };
        }

        public async Task<ApiResponse<string>> RegisterAsync(RegisterRequest req)
        {
            var userExist = await userManager.FindByEmailAsync(req.Email);

            var response = new ApiResponse<string>();

            if (userExist != null)
            {
                response.Success = false;
                response.Errors = new[] { $"{req.Email} is already registered." };
                return response;
            }

            ApplicationUser user = new ApplicationUser()
            {
                TitleID = req.TitleId,
                FirstName = req.FirstName,
                MiddleName = req.MiddleName,
                LastName = req.LastName,
                UserName = req.Email,
                Email = req.Email,
                UserTypeId = req.UserTypeId
            };

            var result = await userManager.CreateAsync(user, req.Password);

            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = $"{req.Email} is registered successfully.";
                response.Data = jwtToken.JwtToken(user);
            }
            else
            {
                response.Success = false;
                response.Errors = result.Errors.Select(e => e.Description);
            }
            return response;
        }
    }
}
