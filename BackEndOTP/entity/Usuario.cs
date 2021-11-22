using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.entity
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD/MM/YYYY}")]
        public DateTime dateDeNascimento { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string imagem { get; set; }
    }
}
