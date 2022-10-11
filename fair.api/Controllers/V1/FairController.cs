using Microsoft.AspNetCore.Mvc;

namespace fair.api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class FairController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetFairs()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetFairsByFilter()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFair()
        {
            return Ok();
        }

        [HttpDelete("{idFair}")]
        public async Task<IActionResult> DeleteFair(int idFair)
        {
            return Ok();
        }

    }
}
