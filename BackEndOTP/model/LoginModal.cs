using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.model
{
    public class LoginModal
    {
        [Required(ErrorMessage = "campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string email { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "senha deve ter de 8 a 20 caracteres")]
        public string senha { get; set; }
    }
}
