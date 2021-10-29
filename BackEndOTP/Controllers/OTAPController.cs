using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OTAPController : ControllerBase
    {
        private readonly IUsuarioService _usuario;
        public OTAPController(IUsuarioService usuario)
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
        public ActionResult<Usuario> cadastro(Usuario usuario)
        {
            _usuario.create(usuario);
            return Ok();
        }

    }
}
