using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BackEndOTP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuario;
        public UsuarioController(IUsuarioService usuario)
        {
            _usuario = usuario;
        }
       [HttpGet]
       [Route("listausuarios")]
       public IEnumerable<Usuario> usuarios()
        {
           var usuario = _usuario.list();
            return usuario;
        }
        [HttpPost]
        [Route("Cadastro")]
        public ActionResult<UsuarioModel> cadastro([FromBody] UsuarioModel usuario)
        {
            _usuario.create(usuario);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
       public ActionResult<UsuarioModel> update(int id, [FromBody] UsuarioModel usuario)
        {

            _usuario.update(id,usuario);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult<UsuarioModel> delete(int id)
        {
            _usuario.delete(id);
            return Ok();
        }
        [HttpGet]
        [Route("getid")]
        public Usuario getid(int id)
        {
           return _usuario.getid(id);

        }

    }
}
