using AutoMapper;
using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BackEndOTP.service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly OTAPPContext _oTAPPContext;
        private readonly IMapper _mapper;

        public UsuarioService(OTAPPContext oTAPPContext,
            IMapper mapper)
        {
            _oTAPPContext = oTAPPContext;
            _mapper = mapper;
        }


        public void create(UsuarioModel usuarioModel)
        {
            var use = _mapper.Map<Usuario>(usuarioModel);
            use.senha = hashsenha(usuarioModel.senha);
            _oTAPPContext.usuarios.Add(use);
            _oTAPPContext.SaveChanges();
        }

        public void delete(int id)
        {
            _oTAPPContext.Remove
                (_oTAPPContext.usuarios.Single(u => u.Id == id));
            _oTAPPContext.SaveChanges();
        }

        public Usuario getid(int Id)
        {
            Usuario user = _oTAPPContext.usuarios.FirstOrDefault(u => u.Id == Id);
            return user;
        }

        public string hashsenha(string senha)
        {
            byte[] salt;
            byte[] buffer2;
            if (senha == null)
            {
                throw new ArgumentNullException("senha");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(senha, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public IEnumerable<Usuario> list()
        {
            var usuario = _oTAPPContext.usuarios.ToList();
            return usuario;
        }

        public void update(int id, UsuarioModel usuariomodel)
        {
            var usuarios = _oTAPPContext.usuarios.FirstOrDefault(u => u.Id == id);
            usuarios.cpf = usuariomodel.cpf;
            usuarios.dateDeNascimento = usuariomodel.dateDeNascimento;
            usuarios.email = usuariomodel.email;
            usuarios.nome = usuariomodel.nome;
            usuarios.sobrenome = usuariomodel.sobrenome;
            usuarios.senha = usuariomodel.senha;

            _oTAPPContext.Update(usuarios);
            _oTAPPContext.SaveChanges();
        }
    }
}
