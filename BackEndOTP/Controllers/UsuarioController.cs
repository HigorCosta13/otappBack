using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using BackEndOTP.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEndOTP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuario;
        private readonly OTAPPContext _oTAPPContext;
        public UsuarioController(IUsuarioService usuario, OTAPPContext oTAPPContext)
        {
            _usuario = usuario;
            _oTAPPContext = oTAPPContext;
        }
        [HttpPost]
        [Route("Cadastro")]
        [AllowAnonymous]
        public ActionResult<UsuarioModel> cadastro([FromBody] UsuarioModel usuarioModel)
        {
            _usuario.create(usuarioModel);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
       public ActionResult<UsuarioModel> update([FromBody] UsuarioModel usuario)
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _usuario.update(Convert.ToInt32(header), usuario);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult<UsuarioModel> delete()
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _usuario.delete(Convert.ToInt32(header));
            return Ok();
        }
        [HttpGet]
        [Route("getid")]
        public Usuario getid()
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _usuario.getid(Convert.ToInt32(header));
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> login([FromBody] LoginModal loginModal)
        {

            var user = _usuario.login(loginModal);
            return new
            {
                user
            };
        }
     

    }
}
