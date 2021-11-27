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
            Consulta cosul = new Consulta();
            cosul.data = consulta.data;
            cosul.exame = consulta.exame;
            cosul.hopsital = consulta.hospital;
            cosul.avatar = consulta.avatar;
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
                        id = list.id,
                        data = list.data,
                        exame = list.exame,
                        hopsital = list.hopsital,
                        avatar = list.avatar
                    }).ToList();
        }

        public ConsultaModel getid(int Id)
        {
            Consulta consulta = _oTAPPContext.consultas.FirstOrDefault(u => u.id == Id);
            ConsultaModel consultaModel = new ConsultaModel();
            consultaModel.hopsital = consulta.hopsital;
            consultaModel.exame = consulta.exame;
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
            consulta.exame = consultaModel.exame;
            consulta.data = consultaModel.data;
            consulta.avatar = consultaModel.avatar;
            _oTAPPContext.consultas.Update(consulta);
            _oTAPPContext.SaveChanges();
        }
         public void CreateVacinacao(int id,VacinacaoModel vacinacaoModel)
         {
            Vacinacao vacinacao = new Vacinacao
            {
                dose = vacinacaoModel.dose,
                atual = vacinacaoModel.atual,
                nameVacina = vacinacaoModel.nameVacina,
                date = vacinacaoModel.date,
                dateProx = vacinacaoModel.dateProx,
                idUsuario = id
            };
            _oTAPPContext.vacinacaos.Add(vacinacao);
            _oTAPPContext.SaveChanges();
         }
          public void UpdateVacinacao(int id,VacinacaoModel vacinacaoModel)
         {
            Vacinacao vacinacao =_oTAPPContext.vacinacaos.FirstOrDefault(v => v.id == id);
            vacinacao.id = id;
            vacinacao.nameVacina = vacinacaoModel.nameVacina;
            vacinacao.dose = vacinacaoModel.dose;
            vacinacao.dateProx = vacinacaoModel.dateProx;
            vacinacao.date = vacinacaoModel.date;
            vacinacao.atual = vacinacaoModel.atual;

            _oTAPPContext.vacinacaos.Update(vacinacao);
            _oTAPPContext.SaveChanges();
         }
             public void deleteVacinacao(int id)
        {
            _oTAPPContext.Remove
              (_oTAPPContext.vacinacaos.Single(v => v.id == id));
            _oTAPPContext.SaveChanges();
        }
         public Vacinacao getIdVacinacao(int Id)
        {
            Vacinacao vacinacao = _oTAPPContext.vacinacaos.FirstOrDefault(v => v.id == Id);
            return vacinacao;
        }
        public IEnumerable<Vacinacao> listVacinacao(int Id)
        {
             return (from list in _oTAPPContext.vacinacaos
                    where list.idUsuario.Equals(Id)
                    select new Vacinacao {
                        id = list.id,
                        idUsuario= list.idUsuario,
                        atual = list.atual,
                        date = list.date,
                        dateProx = list.dateProx,
                        dose = list.dose,
                        nameVacina = list.nameVacina
                    }).ToList();
        }
        
    }
}
