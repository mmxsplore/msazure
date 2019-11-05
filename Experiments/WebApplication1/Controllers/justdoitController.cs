using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class justdoitController : ControllerBase
    {
        // GET: api/justdoit
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string computername;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                computername = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            }
            else
            {
                computername = System.Environment.GetEnvironmentVariable("HOSTNAME");
            }

            return new string[] { computername };
        }

        // GET: api/justdoit/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/justdoit
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/justdoit/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
