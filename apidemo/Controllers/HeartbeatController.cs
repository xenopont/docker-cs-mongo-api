using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/heartbeat")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> ReturnOk()
        {
            return "OK";
        }
    }
}
