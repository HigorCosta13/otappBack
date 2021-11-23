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
        [HttpGet]
        [Route("getvacinacaoList")]
        public IEnumerable<Vacinacao> GetVacinacaosList()
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _consulta.listVacinacao(Convert.ToInt32(header));
        }
        [HttpPost]
        [Route("Cadastrovacinacao")]
        public ActionResult<VacinacaoModel> cadastroVacinacao([FromBody] VacinacaoModel vacinacao)
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _consulta.CreateVacinacao(Convert.ToInt32(header),vacinacao);
            return Ok();
        }
        [HttpPut]
        [Route("Updatevacinacao")]
        public ActionResult<VacinacaoModel> updateVacinacao(int id,[FromBody] VacinacaoModel vacinacao)
        {
            _consulta.UpdateVacinacao(id, vacinacao);
            return Ok();
        }

        [HttpGet]
        [Route("Getvacinacaoid")]
        public Vacinacao getIdVacinacao(int Id)
        {
             return _consulta.getIdVacinacao(Id);
        }
        [HttpDelete]
        [Route("DeleteVacinacao")]
        public ActionResult<VacinacaoModel> deleteVacinacao(int id)
        {
            _consulta.deleteVacinacao(id);
            return Ok();
        }

    }
}
