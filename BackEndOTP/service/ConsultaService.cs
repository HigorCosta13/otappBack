using AutoMapper;
using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEndOTP.service
{
    public class ConsultaService : IConsultaService
    {
        private readonly OTAPPContext _oTAPPContext;
 
        public ConsultaService(OTAPPContext oTAPPContext)
        {
            _oTAPPContext = oTAPPContext;
        }

        public void create(ConsultaCadastroModal consulta, string header)
        {
            var hospital = _oTAPPContext.hospitals.FirstOrDefault(h => h.id == consulta.hospitalID); 
            Consulta cosul = new Consulta();
            cosul.data = consulta.data;
            cosul.especialidade = consulta.especialidade;
            cosul.hopsital = hospital.hospital;
            cosul.hora = consulta.hora;
            cosul.hospitalID = consulta.hospitalID;
            cosul.usuarioID = Convert.ToInt32(header);
            _oTAPPContext.consultas.Add(cosul);
            _oTAPPContext.SaveChanges();
        }

        public void delete(int id)
        {
            _oTAPPContext.Remove
              (_oTAPPContext.consultas.Single(u => u.id == id));
            _oTAPPContext.SaveChanges();
        }

        public IEnumerable<ConsultaModel> GetConsulta(int Id)
        {
            return (from list in _oTAPPContext.consultas
                    where list.usuarioID.Equals(Id)
                    select new ConsultaModel {
                        UsuarioID = list.usuarioID,
                        hospitalID = list.hospitalID,
                        data = list.data,
                        especialidade = list.especialidade,
                        hopsital = list.hopsital,
                        hora = list.hora
                    }).ToList();
        }

        public ConsultaModel getid(int Id)
        {
            Consulta consulta = _oTAPPContext.consultas.FirstOrDefault(u => u.id == Id);
            ConsultaModel consultaModel = new ConsultaModel();
            consultaModel.UsuarioID = consulta.usuarioID;
            consultaModel.hospitalID = consulta.hospitalID;
            consultaModel.hopsital = consulta.hopsital;
            consultaModel.hora = consulta.hora;
            consultaModel.especialidade = consulta.especialidade;
            return consultaModel;
        }

        public IEnumerable<Consulta> list()
        {
            var consulta = _oTAPPContext.consultas.ToList();
            return consulta;
        }

        public void update(int id, ConsultaCadastroModal consultaModel)
        {
            var consulta = _oTAPPContext.consultas.FirstOrDefault(u => u.id == id);
            consulta.usuarioID = id;
            consulta.hospitalID = consultaModel.hospitalID;
            consulta.data = consultaModel.data;
            _oTAPPContext.consultas.Update(consulta);
            _oTAPPContext.SaveChanges();

        }
        
    }
}
