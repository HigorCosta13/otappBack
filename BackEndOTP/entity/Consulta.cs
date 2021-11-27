using BackEndOTP.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.entity
{
    public class Consulta
    {
        [Key]
        public int id { get; set; }
        public int usuarioID { get; set; }
        public string hopsital { get; set; }
        public string exame { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD/MM/YYYY}")]
        public DateTime data { get; set; }
        public string avatar {get; set;}
        
    }
}
