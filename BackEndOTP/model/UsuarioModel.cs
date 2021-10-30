using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.model
{
    public class UsuarioModel
    {   [Required(ErrorMessage ="campo obrigatorio")]
        public string nome { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        public string sobrenome { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        public int cpf { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        public DateTime dateDeNascimento { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        public string senha { get; set; }
        public string imagem { get; set; }
    }
}
