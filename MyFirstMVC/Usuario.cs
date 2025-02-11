using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario {get; set;}

        public required string Email {get; set;}

        public required string Senha {get; set;}

        public required string NickName {get; set;}

        public required bool EmprestimoLivro {get; set;}

        public required int QuantidadeEmprestimo {get; set;}

        public required int IdMulta {get; set;}
    }
}