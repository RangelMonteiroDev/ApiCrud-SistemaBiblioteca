using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Multa
    {
        [Key]
        public int IdMulta {get; set;}

        public required DateOnly DataEmpresyimo {get; set;}

        public required bool AumentoMulta {get; set;}

        public required float ValorAumento {get; set;}

        public required bool DescontoMulta {get; set;}

        public required float ValorDesconto {get; set;}

        public required bool Ativa {get; set;}

        public required string CodigoMulta {get; set;}

        public required float ValorTotalMulta {get; set;}
    }
}