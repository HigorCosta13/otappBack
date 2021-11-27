using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.model
{
    public class ConsultaCadastroModal
    {
        public string hospital { get; set; }
        public string exame { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD/MM/YYYY}")]
        public DateTime data { get; set; }
         public string avatar {get; set;}
    }
}