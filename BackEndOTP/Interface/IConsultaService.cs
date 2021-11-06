using BackEndOTP.entity;
using BackEndOTP.model;
using System.Collections.Generic;

namespace BackEndOTP.Interface
{
    public interface IConsultaService
    {
        IEnumerable<Consulta> list();
        void create(ConsultaCadastroModal consulta);
        void update(int id, ConsultaModel usuario);
        void delete(int id);
        Consulta getid(int Id);
        IEnumerable<ConsultaModel> GetConsulta(int Id);
    }
}
