using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.API.Helper;
using ELearning.Dto.V1.Request;
using ELearning.Services;
using ELearning.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.API.Controllers
{
    [ApiController]
    public class TitleController : ControllerBase
    {
        private ITitleServices titleService { get; set; }
        public TitleController(ITitleServices TitleService)
        {
            titleService = TitleService;
        }

        [HttpGet(ApiRoute.Title.Get)]
        public async Task<ActionResult> Get(int titleId)
        {
            var response = await titleService.GetById(titleId);

            if (response.Success)
                return Ok(response);

            return NotFound(response);
        }

        [HttpGet(ApiRoute.Title.GetAll)]
        public async Task<ActionResult> GetAll()
        {
            var response = await titleService.GetAll();
            if (response.Success)
                return Ok(response);

            return NotFound(response);
        }

        [HttpPost(ApiRoute.Title.Create)]
        public async Task<ActionResult> Created([FromBody] TitleRequest req)
        {
            var response = await titleService.CreateAsync(req);
            if (response.Success)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Title.Get.Replace("{titleId}", response.Data.ID.ToString());
               
                return Created(locationUri, response);
            }
            return BadRequest(response);
        }

        [HttpPost(ApiRoute.Title.Bulk)]
        public async Task<ActionResult> Bulk([FromBody] List<TitleRequest> req)
        {
            var response = await titleService.BulkAsync(req);
            return Ok(response);
        }

        [HttpPut(ApiRoute.Title.Update)]
        public async Task<ActionResult> Update(int titleId, [FromBody] TitleRequest req)
        {
            var response = await titleService.UpdateAsync(titleId, req);
            return Ok(response);
        }
    }
}
