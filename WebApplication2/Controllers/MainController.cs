using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://httpbin.org/")
            };

            var response = client.SendAsync(
                new HttpRequestMessage(HttpMethod.Get, "get")
                {
                    Version = HttpVersion.Version20,
                });

            if (response.Result.IsSuccessStatusCode)
                return Ok(response.Result.Content);

            return BadRequest();
        }
    }
}