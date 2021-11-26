
using AutoMapper;
using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BackEndOTP.service
{
    public class UsuarioService : IUsuarioService
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 10101;
        private readonly OTAPPContext _oTAPPContext;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public UsuarioService
            (
            OTAPPContext oTAPPContext,
            IMapper mapper,
            HttpClient httpClient
            )
        {
            _oTAPPContext = oTAPPContext;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public void create(UsuarioModel usuarioModel)
        {
            var use = _mapper.Map<Usuario>(usuarioModel);
            use.senha = HashPassword(usuarioModel.senha);
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

        public void update(int id, UsuarioModel usuariomodel)
        {
            var usuarios = _oTAPPContext.usuarios.FirstOrDefault(u => u.Id == id);
            usuarios.cpf = usuariomodel.cpf;
            usuarios.dateDeNascimento = usuariomodel.dateDeNascimento;
            usuarios.email = usuariomodel.email;
            usuarios.nome = usuariomodel.nome;
            usuarios.sobrenome = usuariomodel.sobrenome;
            usuarios.senha = HashPassword(usuariomodel.senha);

            _oTAPPContext.Update(usuarios);
            _oTAPPContext.SaveChanges();
        }

        IEnumerable<Usuario> IUsuarioService.list()
        {
            var usuario = _oTAPPContext.usuarios.ToList();
            return usuario;
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SaltByteSize, HasingIterationsCount))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(HashByteSize);
            }
            byte[] dst = new byte[(SaltByteSize + HashByteSize) + 1];
            Buffer.BlockCopy(salt, 0, dst, 1, SaltByteSize);
            Buffer.BlockCopy(buffer2, 0, dst, SaltByteSize + 1, HashByteSize);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] _passwordHashBytes;

            int _arrayLen = (SaltByteSize + HashByteSize) + 1;

            if (hashedPassword == null)
            {
                return false;
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] src = Convert.FromBase64String(hashedPassword);

            if ((src.Length != _arrayLen) || (src[0] != 0))
            {
                return false;
            }

            byte[] _currentSaltBytes = new byte[SaltByteSize];
            Buffer.BlockCopy(src, 1, _currentSaltBytes, 0, SaltByteSize);

            byte[] _currentHashBytes = new byte[HashByteSize];
            Buffer.BlockCopy(src, SaltByteSize + 1, _currentHashBytes, 0, HashByteSize);

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, _currentSaltBytes, HasingIterationsCount))
            {
                _passwordHashBytes = bytes.GetBytes(SaltByteSize);
            }

            return AreHashesEqual(_currentHashBytes, _passwordHashBytes);

        }

        private static bool AreHashesEqual(byte[] firstHash, byte[] secondHash)
        {
            int _minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
            var xor = firstHash.Length ^ secondHash.Length;
            for (int i = 0; i < _minHashLength; i++)
                xor |= firstHash[i] ^ secondHash[i];
            return 0 == xor;
        }
        public static string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.nome.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    

            public String login(LoginModal loginModal)
                {
                    var usuario = _oTAPPContext.usuarios.FirstOrDefault(u => u.email == loginModal.email);
                    if (usuario != null)
                    {
                        var result = VerifyHashedPassword(usuario.senha, loginModal.senha);
                        if (result != false)
                        {
                            var token = GenerateToken(usuario);                             
                            return token;

                        }
                        return null;
                    }
                    return null;
             }
        public bool validaremail(UsuarioModel usuarioModel)
        {
            var user = _oTAPPContext.usuarios.FirstOrDefault(u => u.email == usuarioModel.email);

            if (user == null)
                return true;
            return false;
        }
        public bool validareCPF(UsuarioModel usuarioModel)
        {
            var user = _oTAPPContext.usuarios.FirstOrDefault(u => u.cpf == usuarioModel.cpf);

            if (user == null)
                return true;
            return false;
        }

    }
}
