using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBoxManager.Data.DTOs.ODO;
using SBoxManager.Services.Interfaces;

namespace SBoxManager.api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialDetallesController : ControllerBase
    {
        private readonly IHistorialDetallesService _historialDetalles;

        public HistorialDetallesController(IHistorialDetallesService historialDetalles)
        {
            _historialDetalles = historialDetalles;
        }

        // GET: api/HistorialDetalles
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HistorialDetalles/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetAll/{id}", Name = "GetAll")]        
        public IEnumerable<HistorialDetalle> GetAllById(int id)
        {
            return _historialDetalles.ReadAll(id);
        }

        // POST: api/HistorialDetalles
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HistorialDetalles/5
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
