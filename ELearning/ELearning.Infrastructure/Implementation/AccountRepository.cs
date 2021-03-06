﻿using ELearning.Dto.V1.Request;
using ELearning.Dto.V1.Response;
using ELearning.Entities;
using ELearning.Infrastructure.DbContext;
using ELearning.Services.Services;
using ELearning.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Infrastructure.Implementation
{
    public class AccountRepository : IAccountServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext dbContext;
        private readonly JwtSettings jwtSetting;
        private readonly TokenValidationParameters tokenValidationParameters;

        public AccountRepository(UserManager<ApplicationUser> UserManager,
            RoleManager<IdentityRole> RoleManager,
            JwtSettings JwtSetting,
            TokenValidationParameters TokenValidationParameters,
            AppDbContext DbContext)
        {
            userManager = UserManager;
            roleManager = RoleManager;
            jwtSetting = JwtSetting;
            tokenValidationParameters = TokenValidationParameters;
            dbContext = DbContext;
        }


        #region Roles
        public async Task<ApiResponse<RolesResponse>> AddRoles(RolesRequest req)
        {
            var roleExist = await roleManager.RoleExistsAsync(req.Role);

            if (roleExist)
            {
                return new ApiResponse<RolesResponse>()
                {
                    Success = false,
                    Errors = new[] { $"{req.Role} already exist." }
                };
            }
            else
            {
                var appRole = new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = req.Role
                };

                var result = await roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    return new ApiResponse<RolesResponse>()
                    {
                        Success = true,
                        Data = new RolesResponse() { ID = appRole.Id, Role = appRole.Name }
                    };
                }
                else
                {
                    return new ApiResponse<RolesResponse>()
                    {
                        Success = false,
                        Errors = result.Errors.Select(e => e.Description)
                    };

                }
            }
        }
        #endregion

        #region User Creations
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

            return await GenerateJwtTokenAsync(user);
        }
        public async Task<ApiResponse<string>> RegisterAsync(RegisterRequest req, string role = "User")
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
            }
            else
            {
                response.Success = false;
                response.Errors = result.Errors.Select(e => e.Description);
            }
            return response;
        }
        public async Task<AuthResponse> RefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "Invalid token." }
                };
            }

            var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateUtc = new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateUtc > DateTime.UtcNow)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "This token hasn't expired yet." }
                };
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await dbContext.RefreshToken.SingleOrDefaultAsync(x => x.Token == refreshToken);

            if (storedRefreshToken == null)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "This refresh token doesn't exist." }
                };
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "This refresh token has expired." }
                };
            }

            if (storedRefreshToken.InValidated)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "This refresh token has been invalidated." }
                };
            }

            if (storedRefreshToken.Used)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "This refresh token has been used." }
                };
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthResponse()
                {
                    Success = false,
                    Errors = new[] { "This refresh token doesn't match the JWT." }
                };
            }

            storedRefreshToken.Used = true;

            dbContext.RefreshToken.Update(storedRefreshToken);
            await dbContext.SaveChangesAsync();

            var user = await userManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "Id").Value);

            return await GenerateJwtTokenAsync(user);
        }
        public async Task<ApiResponse<string>> AssignRoleToUser(string userId, string role)
        {
            var user = await userManager.FindByIdAsync(userId);

            var result = await userManager.AddToRoleAsync(user, role);

            if (result.Succeeded)
            {
                return new ApiResponse<string>()
                {
                    Success = true,
                    Message = $"{user.Email} was assign the role of {role}."
                };
            }
            else
            {
                return new ApiResponse<string>()
                {
                    Success = true,
                    Errors = result.Errors.Select(x => x.Description)
                };

            }
        }
        public async Task<ApiResponse<List<UsersResponse>>> AllUsers()
        {
            var users =  userManager.Users
                        .Include(x => x.Title)
                        .Include(u => u.UserType)
                        .Select(s => new UsersResponse
                        {
                            ID = s.Id,
                            Title = s.Title.Name,
                            FirstName = s.FirstName,
                            MiddleName = s.MiddleName,
                            LastName = s.LastName,
                            Email = s.Email,
                            UserType = s.UserType.Name,
                            IsAccountActive = s.IsAccountActive
                        });

            if (users.Any())
            {
                return new ApiResponse<List<UsersResponse>> ()
                {
                    Success = true,
                    Data = await users.ToListAsync()
                };
            }
            else
            {
                return new ApiResponse<List<UsersResponse>>()
                {
                    Success = false,
                    Errors = new [] {"No record found"}
                };

            }
        }
        #endregion

        #region Private Methods
        private async Task<AuthResponse> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSetting.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
               {
                   new Claim(type: JwtRegisteredClaimNames.Sub, value: user.UserName),
                   new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                   new Claim(type: JwtRegisteredClaimNames.Email, value: user.Email),
                   new Claim(type: "Id", value: user.Id)
               }),
                Expires = DateTime.UtcNow.Add(jwtSetting.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };

            await dbContext.RefreshToken.AddAsync(refreshToken);
            await dbContext.SaveChangesAsync();

            return new AuthResponse()
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }
        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }
                return principal;
            }
            catch
            {
                return null;
            }
        }
        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(value: SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase);
        }
        #endregion
    }
}
