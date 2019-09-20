using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBoxManager.api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        // GET: api/Historial
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Historial/5
        [HttpGet("{id}", Name = "GetHistorial")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Historial
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Historial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("Hola");
        }
    }
}
