using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
        
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        //passando parametro por rota
        //api/aluno/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAllAlunoById(id, false);

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
            var aluno = _repo.GetAllAlunoById(id, true);

            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado");
            }

            return Ok(aluno);
        }

        // //passando parametro por rota
        // //api/aluno/Maria
        // [HttpGet("{nome}")]
        // public IActionResult GetByNome(string nome)
        // {
        //     var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

        //     if (aluno == null)
        //     {
        //         return BadRequest("O aluno não foi encontrado");
        //     }

        //     return Ok(aluno);
        // }

        // //passando parametro por queryString
        // //api/aluno/ByName?nome=Maria&sobrenome=Julia
        // [HttpGet("ByName")]
        // public IActionResult GetByNomeQueryString(string nome, string sobrenome)
        // {
        //     var aluno = _context.Alunos.FirstOrDefault(a =>
        //         a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
        //     );

        //     if (aluno == null)
        //     {
        //         return BadRequest("O aluno não foi encontrado");
        //     }

        //     return Ok(aluno);
        // }

        //Salvar novo registro
        //api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não encontrado");
        }

        //Atualizar registro
        //api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAllAlunoById(id);

            if (alu != null)
            {
                _repo.Update(aluno);

                if (_repo.SaveChanges())
                {
                    return Ok(aluno);
                }

                return BadRequest("Aluno não foi atualizado");
            }

            return BadRequest("O aluno não foi encontrado");
        }

        //api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAllAlunoById(id);

            if (alu != null)
            {
                _repo.Update(aluno);

                if (_repo.SaveChanges())
                {
                    return Ok(aluno);
                }

                return BadRequest("Aluno não foi atualizado");
            }

            return BadRequest("O aluno não foi encontrado");
        }

        //api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAllAlunoById(id);

            if (aluno != null)
            {
                _repo.Delete(aluno);

                if (_repo.SaveChanges())
                {
                    return Ok("Aluno deletado com SUCESSO");
                }

                return BadRequest("Aluno não foi deletado");
            }

            return BadRequest("O aluno não foi encontrado");
        }
    }
}