using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.data;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{   
    [Route("Multa")]
    [ApiController]
    public class ControllerMulta : Controller
    {
        private readonly AppDbContext _context;

        public ControllerMulta (AppDbContext context) {

            _context = context;
        }

        [HttpPost("Create")]
        public IActionResult Create (Multa multa) {

            if (ModelState.IsValid)
            {
                _context.Multa.Add(multa);
                _context.SaveChanges();

                return Ok(new { message = "Dados recebidos com sucesso"});
        
            }
            else
            {
                  return BadRequest(ModelState);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {

            var resultado = _context.Multa.ToList();

            if (resultado.Any())
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
            else
            {
                return Ok(resultado);
            }

        }

        [HttpGet("GetId")]
        public IActionResult GetId (string CodigoMulta) {

            var existisIdMulta = _context.Multa.FirstOrDefault(m => m.CodigoMulta == CodigoMulta);

            if (existisIdMulta != null)
            {
                return Ok(new { id = existisIdMulta.IdMulta});
            }
            else
            {
                return NotFound(new {message = "Dados não Encontrados"});
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get (int id) {

            var resultado = _context.Multa.Find(id);

            if (resultado != null)
            {
                return Ok(new { results = resultado});
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update (int id, [FromBody] Multa multa) {

            var resultado = _context.Multa.Find(id);

            if (resultado != null)
            {
                resultado.DataEmpresyimo = multa.DataEmpresyimo;
                resultado.AumentoMulta = multa.AumentoMulta;
                resultado.ValorAumento = multa.ValorAumento;
                resultado.DescontoMulta = multa.DescontoMulta;
                resultado.ValorDesconto = multa.ValorDesconto;
                resultado.Ativa = multa.Ativa;
                resultado.CodigoMulta = multa.CodigoMulta;    
                resultado.ValorTotalMulta = multa.ValorTotalMulta;

                _context.Multa.Update(resultado);
                _context.SaveChanges();

                return Ok(new {message = "Dados atualizados com sucesso"});
            }
            else
            {
                return NotFound(new { message = "Erro ao atualizar dados"});
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete (int id) {

            var resultado = _context.Multa.Find(id);

            if (resultado != null)
            {
                _context.Multa.Remove(resultado);
                _context.SaveChanges();

                return Ok(new {message = "Dados deletados com sucesso"});
            }
            else
            {
                return NotFound(new {message = "Erro ao deletar dados"});
            }
        }
    }
}