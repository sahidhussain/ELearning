﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.API.Helper;
using ELearning.Dto.V1.Request;
using ELearning.Dto.V1.Response;
using ELearning.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.API.Controllers
{
    //[ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountServices accountService { get; set; }
        public AccountController(IAccountServices AccountService)
        {
            accountService = AccountService;
        }

        [HttpPost(ApiRoute.Account.Register)]
        public async Task<ActionResult> Register(RegisterRequest req)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ApiResponse<string>()
            //    {
            //        Success = false,
            //        Errors = ModelState.Values.SelectMany(s => s.Errors.Select(e => e.ErrorMessage))
            //    });
            //}

            var response = await accountService.RegisterAsync(req);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost(ApiRoute.Account.Login)]
        public async Task<ActionResult> Login(LoginRequest req)
        {
            var response = await accountService.LoginAsync(req);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost(ApiRoute.Account.Refresh)]
        public async Task<ActionResult> Refresh(RefreshTokenRequest req)
        {
            var response = await accountService.RefreshTokenAsync(req.Token, req.RefreshToken);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost(ApiRoute.Account.CreateRole)]
        public async Task<ActionResult> CreateRole(RolesRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Success = false,
                    Errors = ModelState.Values.SelectMany(s => s.Errors.Select(e => e.ErrorMessage))
                });
            }

            var response = await accountService.AddRoles(req);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost(ApiRoute.Account.AssignRole)]
        public async Task<ActionResult> AssignRole(AssignRoleRequest req)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ApiResponse<string>()
            //    {
            //        Success = false,
            //        Errors = ModelState.Values.SelectMany(s => s.Errors.Select(e => e.ErrorMessage))
            //    });
            //}

            var response = await accountService.AssignRoleToUser(req.UserId, req.RoleName);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet(ApiRoute.Account.GetAllUser)]
        public async Task<ActionResult> GetAllUser()
        {
            var response = await accountService.AllUsers();

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
