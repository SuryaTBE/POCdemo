using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POCdemoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        [HttpGet]
        public async Task<string> FirstCall()
        {
            
            var c = "First Api finished execution (sleep for 10 seconds).";
            Console.WriteLine(c);
            await Task.Delay(10000);
            return c;
        }
    }
}
