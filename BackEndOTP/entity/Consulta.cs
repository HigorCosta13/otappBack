﻿using BackEndOTP.model;
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
        public string hopsital { get; set; }
        public string especialidade { get; set; }
        public DateTime data { get; set; }
        public DateTime hora { get; set; }
        [ForeignKey("hopsitalname")]
        public virtual Hospital hospitalid { get; set; }
        [ForeignKey("usuarioID")]
        public virtual Usuario Usuarioid { get; set; }
        
    }
}
