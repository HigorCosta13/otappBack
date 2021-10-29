using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly OTAPPContext _oTAPPContext;

        public UsuarioService(OTAPPContext oTAPPContext)
        {
            _oTAPPContext = oTAPPContext;
        }

        public void create(Usuario usuario)
        {
            _oTAPPContext.usuarios.Add(usuario);
            _oTAPPContext.SaveChanges();
        }

        public IEnumerable<Usuario> list()
        {
            var usuario = _oTAPPContext.usuarios.ToList();
            return usuario;
        }
    }
}
