using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Pagamento
    {
        [Key]
        public int IdPagamento {get; set;}
        
        public required DateOnly DataPagamento {get; set;}

        public required bool Aumento {get; set;}

        public required float ValorAumento {get; set;}

        public required bool  Desconto {get; set;}

        public required float ValorDesconto {get; set;}

        public required float ValorTotalPagamento {get; set;}

        public required int IdUsuario {get; set;}
    }
}