﻿// An adaptation of the default values controller generated by the project scaffolding.
// The controller now leverages a service, ValuesService, and this service implements a
// strategy pattern based on configuraiton.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiCore.Common.Config;
using WebApiCore.Services;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IValuesService _valuesService;
        private readonly IOptions<ValuesServiceConfig> _valuesServiceOptions;

        public ValuesController(IValuesService valuesService, IOptions<ValuesServiceConfig> valuesServiceOptions)
        {
            _valuesService = valuesService;
            _valuesServiceOptions = valuesServiceOptions;
        }

        // GET api/values
        [HttpGet]
        public Task<object> Get()
        {
            // Generated by .NET Core scaffolding
            //return new string[] { "value1", "value2" };

            return _valuesService.GetValues(_valuesServiceOptions.Value.DataSource);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return string.Format("value for {0}", id);
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
    }
}
