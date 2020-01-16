using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGol.Business;
using ApiGol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroplanoController : ControllerBase
    {
        private AirplaneService _service;
        public AeroplanoController(AirplaneService service)
        {
            _service = service;
        }

        // GET: api/Aeroplano
        [HttpGet]
        public IEnumerable<AirplaneModel> Get()
        {
            return _service.ListarTodos();
        }

        // GET: api/Aeroplano/5
        [HttpGet("{id}", Name = "Get")]
        public AirplaneModel Get(int id)
        {
            var aeroplano = _service.Obter(id);
            if (aeroplano != null)
                return aeroplano;
            else
                return new AirplaneModel();
        }

        // POST: api/Aeroplano
        [HttpPost]
        public Resultado Post([FromBody] AirplaneModel value)
        {
            return _service.Incluir(value);

        }

        // PUT: api/Aeroplano/5
        [HttpPut]
        public Resultado Put([FromBody] AirplaneModel value)
        {
            return _service.Atualizar(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Resultado Delete(int id)
        {
            return _service.Excluir(id);
        }
    }
}
