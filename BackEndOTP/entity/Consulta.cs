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
        public int hospitalID { get; set; }
        [ForeignKey("hospitalID")]
        public virtual Hospital hospital { get; set; }
        [ForeignKey("usuarioID")]
        public virtual Usuario Usuario { get; set; }
    }
}
