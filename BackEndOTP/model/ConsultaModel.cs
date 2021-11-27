using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.model
{
    public class ConsultaModel
    {
        public int id { get; set; }
        public string hopsital { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD/MM/YYYY}")]
        public DateTime data { get; set; }
        public string exame {get; set;}
        public string avatar {get; set;}

    }
}
