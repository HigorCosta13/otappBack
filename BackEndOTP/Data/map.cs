using AutoMapper;
using BackEndOTP.entity;
using BackEndOTP.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.Data
{
    public class map : Profile
    {
        public map()
        {
            CreateMap<Usuario, UsuarioModel>();
            CreateMap<UsuarioModel, Usuario>();
        }
    }
}
