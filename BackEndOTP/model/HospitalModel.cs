using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.model
{
    public class HospitalModel
    {
        [Required(ErrorMessage = "campo obrigatorio")]
        public string hospital { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        public DateTime dataconsulta { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        public DateTime horaConslta { get; set; }

    }
}
