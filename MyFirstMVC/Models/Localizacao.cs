using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Localizacao
    {
        [Key]
        public int idLocalizacao {get; set;}

        public required string cidade {get; set;}

        public required string estado {get; set;}

        public required string cep {get; set;}

        public required string nacionalidade {get; set;}
    }
}