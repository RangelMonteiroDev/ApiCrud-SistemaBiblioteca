using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.data;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{   
    [Route("Usuario")]
    [ApiController]
    public class ControllerUsuario : Controller
    {
        private readonly AppDbContext _context;


        public ControllerUsuario (AppDbContext context) {

            _context = context;
        }

       [HttpPost("Create")]
       public IActionResult Create (Usuario usuario) {

            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();

                return Ok(new {message = "Dados inseridos com sucesso"});
            }
            else
            {
                return BadRequest(new {message = "Operação invalida"});
            }
       }

       [HttpGet("GetAll")]
       public IActionResult GetAll () {

            var resultado = _context.Usuario.ToList();

            if (resultado.Any())
            {
                return NotFound(new {message = "dados não encontrados"});
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get (int id) {

            var resultado = _context.Usuario.Find(id);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }


        [HttpGet("GetId")]
        public IActionResult GetId (string email, string senha) {

            var existsResults = _context.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (existsResults != null)
            {
                return Ok(existsResults.IdUsuario);
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }

        //Nesse método usando UPDATE vamos atualizar apenas a quantidade de Empréstimo
        [HttpPut("UpdateQuantEmprestimo/{id}")]
        public IActionResult UpdateQuantEmprestimo (int id, [FromBody] int novaQuantidade) {

            var existsResults = _context.Usuario.Find(id);

            if (existsResults != null)
            {
                existsResults.QuantidadeEmprestimo = novaQuantidade;

                _context.Usuario.Update(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Quantidade de Empréstimos Atualizada com Sucesso"});    
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            } 

        }


        //Essa rota atualiza todas as informações
        [HttpPut("Update/{id}")]
        public IActionResult Update (int id, [FromBody] Usuario usuario) {

            var existsResults = _context.Usuario.Find(id);

            if (existsResults != null)
            {
                existsResults.Email = usuario.Email;
                existsResults.Senha = usuario.Senha;
                existsResults.NickName = usuario.NickName;
                existsResults.EmprestimoLivro = usuario.EmprestimoLivro;
                existsResults.QuantidadeEmprestimo = usuario.QuantidadeEmprestimo;

                _context.Usuario.Update(existsResults);
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

            var existsResults = _context.Usuario.Find(id);

            if (existsResults != null)
            {
                _context.Usuario.Remove(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados deletados com sucesso"});
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }
    }
}