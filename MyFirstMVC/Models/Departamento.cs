using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVC.Models
{
    public class Departamento : Controller
    {   
        [Key]
        public int IdDepartamento {get; set;}

        public required String NomeDepartamento {get; set;}

        public required String TipoDepartamento {get; set;}

        public int QuantidadeFuncionarios {get; set;}

        public bool Ativo {get; set;}
    }
}