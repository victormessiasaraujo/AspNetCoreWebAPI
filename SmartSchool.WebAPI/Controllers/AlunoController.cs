using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //passando parametro por rota
        //api/aluno/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado");
            }

            return Ok(aluno);
        }

        //passando parametro por queryString
        //api/aluno/byId?id=1
        [HttpGet("byId")]
        public IActionResult GetByIdQuerystring(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado");
            }

            return Ok(aluno);
        }

        //passando parametro por rota
        //api/aluno/Maria
        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado");
            }

            return Ok(aluno);
        }

        //passando parametro por queryString
        //api/aluno/ByName?nome=Maria&sobrenome=Julia
        [HttpGet("ByName")]
        public IActionResult GetByNomeQueryString(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a =>
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );

            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado");
            }

            return Ok(aluno);
        }

        //api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}