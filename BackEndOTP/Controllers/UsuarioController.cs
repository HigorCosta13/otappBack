using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> cadastro([FromBody] UsuarioModel usuarioModel)
        {
            var CPF = _usuario.validareCPF(usuarioModel);
            var email = _usuario.validaremail(usuarioModel);
            if (email == true)
            {
                if (CPF == true)
                {
                    _usuario.create(usuarioModel);
                    usuarioModel.senha = "";
                    return new { usuarioModel };
                };
                return BadRequest(new { message = "CPF inválidos" });
            }
            return BadRequest(new { message = "Email Invalido" });
        }
        [HttpPut]
       public ActionResult<UsuarioModel> update([FromBody] UsuarioModel usuario)
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _usuario.update(Convert.ToInt32(header), usuario);
            return Ok();
        }
        [HttpDelete]
        public ActionResult<UsuarioModel> delete()
        {
            string header = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _usuario.delete(Convert.ToInt32(header));
            return Ok();
        }
        [HttpGet]
        [Route("/{id}")]
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
            if (user != null)
            {
                return user;
               
            }
            return NotFound(new { message = "Usuário ou senha inválidos" });
        }
        


    }
}
