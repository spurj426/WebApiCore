using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCoreProxy.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly string ValuesControllerApi = "api/Values/";
        private string FullApiUrl => Startup.JsonHttpClient.BaseAddress + ValuesControllerApi;

        public ValuesController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            //CheckApiBaseAddress();
        }

        // GET api/values
        [HttpGet]
        public Task<string> Get()
        {           
            Uri uri = new Uri(FullApiUrl);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            httpRequestMessage.Headers.Authorization = CheckCurrentRequestForBearerToken();
            return Startup.JsonHttpClient.SendAsync(httpRequestMessage).Result.Content.ReadAsStringAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<string> Get(int id)
        {
            Uri uri = new Uri(FullApiUrl + id);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            httpRequestMessage.Headers.Authorization = CheckCurrentRequestForBearerToken();
            return Startup.JsonHttpClient.SendAsync(httpRequestMessage).Result.Content.ReadAsStringAsync();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // Post custom business object
        [HttpPost]

        public async Task<HttpResponseMessage> AddUpdateUser(User user)
        {
            Uri uri = new Uri(FullApiUrl);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            httpRequestMessage.Headers.Authorization = CheckCurrentRequestForBearerToken();
            //httpRequestMessage.Content = new ObjectContent<User>(user, new JasonMediaTypeFormatter());
            return await Startup.JsonHttpClient.SendAsync(httpRequestMessage);

        }
    }

    public class User
    {
        public int UserId { get; set; } = 1;
        public string UserName { get; set; } = "Default User";
        public string Email { get; set; } = "anyone@gmail.com";
    }
}
