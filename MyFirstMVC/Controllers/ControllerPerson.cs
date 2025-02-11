using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFirstMVC.data;
using MyFirstMVC.Models;


namespace MyFirstMVC.Controllers
{   [Route("Person")]
    [ApiController]
    public class ControllerPerson : Controller
    {   
        private readonly AppDbContext _context;

        public ControllerPerson (AppDbContext context) {

            _context = context;
        }

        [HttpPost("Create")]
        public IActionResult Create (Person person) {

            if (ModelState.IsValid)
            {
                _context.Person.Add(person);
                _context.SaveChanges();

                return Ok(new { message = "Dados inseridos com sucesso"});
            }
            else
            {
                return BadRequest(new {message = "Error ao adicionar dados"});   
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {

            var resultado = _context.Person.ToList();

            if (resultado.Any())
            {
                return Ok(new {data = resultado});
            }
            else
            {
                return NotFound(new {message = "Dados não Encontrados"});
            }

        }


        [HttpGet("GetId")]
        public IActionResult GetId (string cpf) {

            var idPerson = _context.Person.FirstOrDefault(p => p.Cpf == cpf );

            if (idPerson != null)
            {
                return Ok(new {id = idPerson.IdPerson});
            }
            else
            {
                return NotFound(new {message = "Dados não Encontrados"});
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get (int id) {

            var resultado = _context.Person.Find(id);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return NotFound(new { message = "Dados não encontrados"});
            }

        }


        [HttpPut("Update/{id}")]
        public IActionResult Update (int id , [FromBody] Person person) {

            var existePerson = _context.Person.Find(id);

            if (existePerson != null)
            {
                existePerson.Nome = person.Nome;
                existePerson.Idade = person.Idade;
                existePerson.Cpf = person.Cpf;
                existePerson.Ativo = person.Ativo;
                existePerson.IdLocalizacao = person.IdLocalizacao;
                existePerson.Sexo = person.Sexo;


                _context.Person.Update(existePerson);
                _context.SaveChanges();

                return Ok(new {message = "Dados atualizados com sucesso"});
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }

        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete (int id) {

            var resultado = _context.Person.Find(id);

            if (resultado != null)
            {
                _context.Person.Remove(resultado);
                _context.SaveChanges();

                return Ok(new {message = "Dados deletados com sucesso"});
            }
            else
            {
                return NotFound(new {message = "Não foi possível deletar os dados"});
            }
        }
    }
}