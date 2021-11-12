using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndOTP.model
{
    public class ConsultaCadastroModal
    {
        public int hospitalID { get; set; }
        public string especialidade { get; set; }
        public DateTime data { get; set; }
        public DateTime hora { get; set; }
    }
}