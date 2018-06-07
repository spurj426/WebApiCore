using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        //public async Task<TokenResponse> GetToken()
        //{
        //    var disco = await GetDisco();

        //    // request token
        //    var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
        //    return await tokenClient.RequestClientCredentialsAsync("api1");
        //}

        //private async Task<DiscoveryResponse> GetDisco()
        //{
        //    // discover endpoints from metadata
        //    return await DiscoveryClient.GetAsync("http://localhost:5000");
        //}
    }
}