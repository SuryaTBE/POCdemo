using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThirdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdController : ControllerBase
    {
        [HttpGet]
        public async Task<string> thirdCall()
        {
            await Task.Delay(4000);
            var third = "Third Api finished execution (sleep for 4 seconds)";
            return third;
        }
    }
}
