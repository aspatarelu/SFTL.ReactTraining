using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SFTL.ReactTraining.API.Controllers
{
    [Route("[controller]")]

    [ApiController]
    public class ResourceController : ControllerBase
    {
        [Route("test2")]
        public ObjectResult Get2()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToArray();
            var response = new { message = "Hello API", claims };
            return new ObjectResult(response);
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public string Get()
        {
            return "Horaaay. You're an admin";
        }
    }
}
