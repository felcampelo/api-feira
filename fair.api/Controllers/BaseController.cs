using fair.domain.Entities.Custom;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace fair.api.Controllers
{
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        protected ActionResult ValidResult(GenericResult result)
        {
            return result.Success ? Ok(result)
                : InternalServerError(result.ErrorMessage);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected ActionResult InternalServerError(string? message) =>
           StatusCode((int)HttpStatusCode.InternalServerError, message);
    }
}
