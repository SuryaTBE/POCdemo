using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;

namespace POCdemo.Controllers
{
    public class POCController : Controller
    {
        private readonly ILogger<POCController> _logger;
        public POCController(ILogger<POCController> logger) 
        {
            _logger = logger;
        }

        public IActionResult CallAsyncAPI()
        {
            _logger.LogInformation("Starting async execution of 3 APIs");
            //firstCall();
            //secondCall();
            //thirdCall();
            Task.WhenAll(firstCall(), secondCall(),thirdCall()).Wait();
            _logger.LogInformation("Finished async execution of 3 APIs");
            return RedirectToAction("Index", "Home");
        }
       public async Task firstCall()
        {
            _logger.LogInformation("First Api Called at "+DateTime.Now);
            string firstcall = "";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res =await client.GetAsync("https://localhost:7261/api/First");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    firstcall = response;
                }
                Console.WriteLine(firstcall + " " + DateTime.Now);
            }
        }
        public async Task secondCall()
        {
            _logger.LogInformation("Second API called at "+DateTime.Now);
            string secondcall = "";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:7015/api/Second");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    secondcall = response;
                }
                Console.WriteLine(secondcall+" "+DateTime.Now);
            }
        }
        public async Task thirdCall()
        {
            _logger.LogInformation("Third API called at " + DateTime.Now);
            string thirdcall = "";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:7159/api/Third");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    thirdcall = response;
                }
                Console.WriteLine(thirdcall + " " + DateTime.Now);
            }
        }
    }
}
