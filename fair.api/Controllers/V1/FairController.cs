using fair.application.Contract;
using fair.application.DTO;
using fair.domain.Filters;
using Microsoft.AspNetCore.Mvc;

namespace fair.api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class FairController : BaseController
    {
        private ILogger<FairController> logger;
        private IFairService service;

        public FairController(IFairService service, ILogger<FairController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFairs([FromQuery] FairFilter filter)
        {            
            var ret = await this.service.GetFairs(filter);
            return ValidResult(ret);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FairDTO fairDto)
        {
            var ret = await this.service.Create(fairDto);
            return ValidResult(ret);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FairDTO fairDto)
        {
            if (fairDto.Id == 0)
                return BadRequest("Id obrigatório.");

            var ret = await this.service.Update(fairDto);
            return ValidResult(ret);
        }

        [HttpDelete("{idFair}")]
        public async Task<IActionResult> DeleteFair(int idFair)
        {
            if (idFair == 0)
                return BadRequest("Id obrigatório.");

            var ret = await this.service.Delete(idFair);
            return ValidResult(ret);
        }
    }
}
