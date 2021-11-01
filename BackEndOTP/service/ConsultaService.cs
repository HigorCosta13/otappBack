using AutoMapper;
using BackEndOTP.Data;
using BackEndOTP.entity;
using BackEndOTP.Interface;
using BackEndOTP.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.service
{
    public class ConsultaService : IConsultaService
    {
        private readonly OTAPPContext _oTAPPContext;
        private readonly IMapper _mapper;
        public ConsultaService(OTAPPContext oTAPPContext, IMapper mapper)
        {
            _oTAPPContext = oTAPPContext;
            _mapper = mapper;
        }

        public void create(ConsultaModel consulta)
        {
            Consulta cosul = new Consulta();
            cosul.data = consulta.data;
            cosul.especialidade = consulta.especialidade;
            cosul.hopsital = consulta.hopsital;
            cosul.hora = consulta.hora;
            cosul.hospitalID = consulta.hospitalID;
            cosul.usuarioID = consulta.usuarioID;
            
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
                        usuarioID = list.usuarioID,
                        hospitalID = list.hospitalID,
                        data = list.data,
                        especialidade = list.especialidade,
                        hopsital = list.hopsital,
                        hora = list.hora
                    }).ToList();
        }

        public Consulta getid(int Id)
        {
            Consulta consulta = _oTAPPContext.consultas.FirstOrDefault(u => u.id == Id);
            return consulta;
        }

        public IEnumerable<Consulta> list()
        {
            var consulta = _oTAPPContext.consultas.ToList();
            return consulta;
        }

        public void update(int id, ConsultaModel consultaModel)
        {
            var consulta = _oTAPPContext.consultas.FirstOrDefault(u => u.id == id);
            consulta.usuarioID = consultaModel.usuarioID;
            consulta.hospitalID = consultaModel.hospitalID;
            consulta.data = consultaModel.data;
            _oTAPPContext.consultas.Update(consulta);
            _oTAPPContext.SaveChanges();
        }
    }
}
