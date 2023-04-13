using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SecondAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondController : ControllerBase
    {
        [HttpGet]
        public async Task<string> SecondCall()
        {
            await Task.Delay(3000);
            string second = "Second Api finished execution(sleep for 3 seconds) ";
            Console.WriteLine(second);
            return second;
        }
    }
}
