using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.API.Helper;
using ELearning.Dto.V1.Request;
using ELearning.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.API.Controllers
{
    [ApiController]
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
            var response = await accountService.RegisterAsync(req);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
