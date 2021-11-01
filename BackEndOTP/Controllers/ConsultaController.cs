using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndOTP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consulta;
        public ConsultaController(IConsultaService consulta)
        {
            _consulta = consulta;
        }
        [HttpGet]
        [Route("list")]
        public IEnumerable<Consulta> consultas()
        {
            return _consulta.list();
        }
        [HttpPost]
        [Route("cadastro")]
        public ActionResult<ConsultaModel> cadastro([FromBody] ConsultaModel consulta)
        {
            _consulta.create(consulta);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public ActionResult<ConsultaModel> update(int id, [FromBody] ConsultaModel consulta)
        {
            _consulta.update(id,consulta);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult<ConsultaModel> delete(int id)
        {
            _consulta.delete(id);
            return Ok();
        }
        [HttpGet]
        [Route("getid")]
        public Consulta getid(int id)
        {
            return _consulta.getid(id);
        }
        [HttpGet]
        [Route("getconsultacliente")]
        public IEnumerable<ConsultaModel> GetConsultaCliente(int id)
        {
            return _consulta.GetConsulta(id);
        }
            
     }
}
