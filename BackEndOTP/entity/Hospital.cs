using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.entity
{
    public class Hospital
    {
        [Key]
        public int id { get; set; }
        public string hospital { get; set; }
        public DateTime dataconsulta { get; set; }
        public DateTime horaConslta { get; set; }



    }
}
