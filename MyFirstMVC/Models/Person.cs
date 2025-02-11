using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFirstMVC.Models
{
    public class Person
    {
        [Key]
        public int IdPerson {get; set;}
        public required string Nome {get; set;}
        public required int Idade {get; set;}
        public required string Cpf {get; set;}
        public required bool Ativo {get; set;}
        public int IdLocalizacao {get; set;}
        public required char Sexo {get; set;}


    }
}