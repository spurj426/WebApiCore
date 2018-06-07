using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCoreProxy.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthenticationHeaderValue CheckCurrentRequestForBearerToken()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(token) && token.Substring(0, 6) == "Bearer" && token.Length > 7)
            {
                return new AuthenticationHeaderValue("Bearer", token.Substring(7));
            }
            return new AuthenticationHeaderValue("Bearer", "");
        }
    }
}