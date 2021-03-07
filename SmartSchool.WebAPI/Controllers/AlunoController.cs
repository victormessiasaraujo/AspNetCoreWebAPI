using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                Id = 1,
                Nome = "João",
                Sobrenome = "Paulo",
                Telefone = "01010101010"
            },
            new Aluno(){
                Id = 2,
                Nome = "Maria",
                Sobrenome = "Julia",
                Telefone = "020202020202"
            },
            new Aluno(){
                Id = 3,
                Nome = "Rafael",
                Sobrenome = "Medeiros",
                Telefone = "0303030300303"
            },
            new Aluno(){
                Id = 4,
                Nome = "Paulo",
                Sobrenome = "Melo",
                Telefone = "0404040404040"
            }
        };
        public AlunoController(){}

        [HttpGet]
        public IActionResult Get ()
        { 
            return Ok(Alunos);
        }

        //passando parametro por rota
        //api/aluno/1
        [HttpGet("{id:int}")]
        public IActionResult GetById (int id)
        { 
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null)
            {
                return BadRequest("O aluno não foi encontrado");
            }

            return Ok(aluno);
        }

        //passando parametro por queryString
        //api/aluno/byId?id=1
        [HttpGet("byId")]
        public IActionResult GetByIdQuerystring (int id)
        { 
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null)
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
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

            if(aluno == null)
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
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );

            if(aluno == null)
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