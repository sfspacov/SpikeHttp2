using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://httpbin.org/")
            };

            var response = await client.SendAsync(
                new HttpRequestMessage(HttpMethod.Get, "get")
                {
                    Version = HttpVersion.Version20,
                });

            if (response.IsSuccessStatusCode)
                return Ok(response.Content);

            return BadRequest();
        }
    }
}
