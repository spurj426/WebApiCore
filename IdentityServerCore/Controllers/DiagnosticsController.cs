﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServerCore.Controllers
{
    //[SecurityHeaders]
    [Authorize]
    public class DiagnosticsController : Controller
    {
        //public async Task<IActionResult> Index()
        //{
        //    var localAddresses = new string[] { "127.0.0.1", "::1", HttpContext.Connection.LocalIpAddress.ToString() };
        //    if (!localAddresses.Contains(HttpContext.Connection.RemoteIpAddress.ToString()))
        //    {
        //        return NotFound();
        //    }

        //    var model = new DiagnosticsViewModel(await HttpContext.AuthenticateAsync());
        //    //return View(model);
        //}
    }
}
