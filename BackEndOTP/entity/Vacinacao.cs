using System;
using System.ComponentModel.DataAnnotations;

namespace BackEndOTP.entity
{
    public class Vacinacao
    {
        [Key]
        public int id {get; set;}
        public int idUsuario {get; set;}

        public string nameVacina  {get; set;}

        public int dose {get; set;}

        public int atual {get;set;}

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD/MM/YYYY}")]
        public DateTime date {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD/MM/YYYY}")]
        public DateTime dateProx {get; set;}
        
    }
}