using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace BackEndOTP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consulta;
        private readonly OTAPPContext _oTAPPContext;
        public ConsultaController(IConsultaService consulta, OTAPPContext oTAPPContext)
        {
            _consulta = consulta;
            _oTAPPContext = oTAPPContext;
        }
        [HttpGet]
        [Route("list")]
        public IEnumerable<Consulta> consultas()
        {
            return _consulta.list();
        }
        [HttpPost]
        [Route("cadastro")]
        public ActionResult<ConsultaCadastroModal> cadastro([FromBody] ConsultaCadastroModal consulta)
        {

            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _consulta.create(consulta, header);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public ActionResult<ConsultaModel> update([FromBody] ConsultaCadastroModal consulta)
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _consulta.update(Convert.ToInt32(header), consulta);
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
        public ConsultaModel getid(int id)
        {
            return _consulta.getid(id);
        }
        [HttpGet]
        [Route("getconsultacliente")]
        public IEnumerable<ConsultaModel> GetConsultaCliente()
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _consulta.GetConsulta(Convert.ToInt32(header));
        }

    }
}
