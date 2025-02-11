using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.data;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{   
    [Route("Pagamento")]
    [ApiController]
    public class ControllerPagamento : Controller
    {
        private readonly AppDbContext _context;

        public ControllerPagamento (AppDbContext context) {

            _context = context;
        }

        [HttpPost("Create")]
        public IActionResult Create (Pagamento pagamento) {

            if (ModelState.IsValid)
            {
                _context.Pagamento.Add(pagamento);
                _context.SaveChanges();

                return Ok(new {message = "Dados cadastrados com sucesso"});
            }
            else
            {
               return BadRequest(new { message = "Erro na operação"}); 
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll () {

            var resultado = _context.Pagamento.ToList();

            if (resultado.Any())
            {
                return NotFound(new { message = "Dados não encontrados"});
            }
            else
            {
                return Ok(resultado);
            }
        }


        [HttpGet("GetId")]
        public IActionResult GetId (DateOnly data, int IdUsuario) {

            var existsResults = _context.Pagamento.FirstOrDefault(p => p.DataPagamento == data && p.IdUsuario == IdUsuario);

            if (existsResults != null)
            {
                return Ok(existsResults.IdPagamento);
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }

        }


        [HttpGet("Get/{id}")]
        public IActionResult Get(int id) {

             var resultado = _context.Pagamento.Find(id);    

            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        } 

        [HttpPut("UpdateAumento/{id}")]
        public IActionResult UpdateAumento (int id, bool aumentoPagamento, float ValorAumento, float ValorTotalPagamento) {

            var existsResults = _context.Pagamento.Find(id);

            if (existsResults != null)
            {
                existsResults.Aumento = aumentoPagamento;
                existsResults.ValorAumento = ValorAumento;
                existsResults.ValorTotalPagamento = ValorTotalPagamento;

                _context.Pagamento.Update(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados atualizados com sucesso"});    
                
            }
            else
            {
                return NotFound(new {message = "Não foi possível atualizar os dados"});
            }
        }

        [HttpPut("UpdateDesconto/{id}")]
        public IActionResult UpdateDesconto (int id, bool descontoPagamento, float ValorDesconto, float ValorTotalPagamento) {

            var existsResults = _context.Pagamento.Find(id);

            if (existsResults != null)
            {
                existsResults.Desconto = descontoPagamento;
                existsResults.ValorDesconto = ValorDesconto;
                existsResults.ValorTotalPagamento = ValorTotalPagamento;

                _context.Pagamento.Update(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados atualizados com sucesso"});    
                
            }
            else
            {
                return NotFound(new {message = "Não foi possível atualizar os dados"});
            }
        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete (int id) {

            var existsResults = _context.Pagamento.Find(id);

            if (existsResults != null)
            {
                _context.Pagamento.Remove(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados deletados com sucesoo"});
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }
    }
}