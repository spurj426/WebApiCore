using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCoreProxy.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly string ValuesControllerApi = "api/Token/";
        private string FullApiUrl => Startup.JsonHttpClient.BaseAddress + ValuesControllerApi;

        // GET: api/<controller>
        [HttpGet]
        public async Task<HttpResponseMessage> GetToken()
        {
            Uri uri = new Uri(FullApiUrl);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return await Startup.JsonHttpClient.SendAsync(httpRequestMessage); 
        }

    }
}
