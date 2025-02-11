using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.data;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{   
    [ApiController]
    [Route("Departamento")]
    public class ControllerDepartamento : Controller
    {
        private readonly AppDbContext _context;

        public ControllerDepartamento(AppDbContext context) {

            _context = context;
        }

        [HttpPost("Create")]
        public IActionResult Create (Departamento departamento) {

            if (ModelState.IsValid)
            {
                _context.Departamento.Add(departamento);

                return Ok(new {message = "Dados inseridos com sucesso"});
            }
            else
            {
               return BadRequest(new {message = "Error: Verificar requisição"}); 
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {

            var existsResults = _context.Departamento.ToList();

            if (existsResults.Any())
            {
               return NotFound(new {message = "Error: Dados não encontrados"}); 
            }
            else
            {
                return Ok(existsResults);
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get (int id) {

            var existsResults = _context.Departamento.Find(id);

            if (existsResults != null)
            {
                return Ok(existsResults);
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }

        [HttpPut("UpdateQuantidadeFunc/{id}")]
        public IActionResult UpdateQuantidadeFunc (int id, [FromBody] int novaQuantidade) {

            var existsResults = _context.Departamento.Find(id);

            if (existsResults != null)
            {
                existsResults.QuantidadeFuncionarios = novaQuantidade;

                _context.Departamento.Update(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados atualizados com sucesso"});
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }

        [HttpPut("UpdateAtivo/{id}")]
        public IActionResult UpdateAtivo (int id, [FromBody] bool ativo) {

            var existsResults = _context.Departamento.Find(id);

            if (existsResults != null)
            {
                existsResults.Ativo = ativo;

                _context.Departamento.Update(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados atualizados com sucesso"});
            }
            else
            {
                return NotFound(new {message = "Error: Dados não encontrados"});
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete (int id) {

            var existsResults = _context.Pagamento.Find(id);

            if (existsResults != null)
            {
                _context.Pagamento.Remove(existsResults);
                _context.SaveChanges();

                return Ok(new { message = "Dados deletados com sucesso"});
            }
            else
            {
                return Ok(new {message = "Não foi possível deletar dados"});
            }
        }
    }
}