using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.data;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{
    [Route("Localizacao")]
    [ApiController]    
    public class ControllerLocalizacao : Controller
    {
        private readonly AppDbContext _context;
        public ControllerLocalizacao(AppDbContext context) {

            _context = context;

        }

        [HttpPost("Create")]
        public IActionResult Create (Localizacao localizacao) {

            if (ModelState.IsValid)
            {
                _context.Localizacao.Add(localizacao);
                _context.SaveChanges();

                return Ok(new {message = "Dados inseridos com sucesso"});
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll () {

            var resultado = _context.Localizacao.ToList();

            if (resultado.Any())
            {
                return Ok(resultado);
            }
            else
            {
                return NotFound(new {message = "Não foram encontrados dados"});
            }
        }

        [HttpGet("Get/{id}")]

        public IActionResult GetId (int id) {

            var resultado = _context.Localizacao.Find(id);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return NotFound(new {message = "Erro, dados não encontrados"});
            }
        }


        [HttpPut("Update/{id}")]
        public IActionResult Update ( int id , [FromBody] Localizacao localizacao) {

            var existeLocalizacao = _context.Localizacao.Find(id);

            if (existeLocalizacao != null)
            {
                existeLocalizacao.cidade = localizacao.cidade;

                existeLocalizacao.estado = localizacao.estado;

                existeLocalizacao.cep = localizacao.cep;

                existeLocalizacao.nacionalidade = localizacao.nacionalidade;

                _context.Localizacao.Update(existeLocalizacao);
                _context.SaveChanges();

                return Ok(new {message = "Dados inseridos com sucesso"});
            }
            else
            {
               return NotFound(); 
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete (int id) {

            var localizacao = _context.Localizacao.Find(id);

            if (localizacao == null)
            {
                return NotFound(new { message = "Dados não encontrados"});
            }
            else
            {
                _context.Localizacao.Remove(localizacao);
                _context.SaveChanges();

                return Ok(new {message = "Dados deletados com sucesso"});

            }
        }


        [HttpGet("GetId")]
        public IActionResult GetId (string cep) {

            var idLocalizacao = _context.Localizacao.FirstOrDefault(l => l.cep == cep);

            if (idLocalizacao != null)
            {
                return Ok( new { IdLocalizacao = idLocalizacao.idLocalizacao});
            }
            else
            {
               return NotFound(new {message = "Dados não encontrados"}); 
            }
        }
    }
}