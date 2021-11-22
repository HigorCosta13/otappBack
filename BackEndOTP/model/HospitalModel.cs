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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD/MM/YYYY}")]
        public DateTime dataconsulta { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        public DateTime horaConslta { get; set; }

    }
}
