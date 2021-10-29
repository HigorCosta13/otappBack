using BackEndOTP.entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.Interface
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario>list();
       void create(Usuario usuario);
    }

}
