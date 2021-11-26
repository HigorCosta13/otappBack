﻿using System;
using BackEndOTP.entity;
using BackEndOTP.model;
using System.Collections.Generic;

namespace BackEndOTP.Interface
{
    public interface IUsuarioService
    {
       IEnumerable<Usuario> list();
       void create(UsuarioModel usuarioModel);
       void update(int id, UsuarioModel usuario);
       void delete(int id);
       Usuario getid(int Id);
       String login(LoginModal loginModal);
       bool validaremail(UsuarioModel usuarioModel);
       bool validareCPF(UsuarioModel usuarioModel);
       

    }

}
