using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }

        //passando parametro por rota
        //api/professor/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetAllProfessorById(id, false);

            if (professor == null)
            {
                return BadRequest("O professor não foi encontrado");
            }

            return Ok(professor);
        }

        //passando parametro por queryString
        //api/professor/byId?id=1
        [HttpGet("byId")]
        public IActionResult GetByIdQueryString(int id)
        {
            var professor = _repo.GetAllProfessorById(id, false);

            if (professor == null)
            {
                return BadRequest("O professor não foi encontrado");
            }

            return Ok(professor);
        }

        // //passando parametro por rota
        // //api/professor/Maria
        // [HttpGet("{nome}")]
        // public IActionResult GetByNome(string nome)
        // {
        //     var professor = _context.Professores.Where(p => p.Nome.Equals(nome));

        //     if (professor == null)
        //     {
        //         return BadRequest("Professor não encontrado");
        //     }

        //     return Ok(professor);
        // }

        // //passando parametro por queryString
        // //api/aluno/ByName?nome=Maria
        // [HttpGet("ByName")]
        // public IActionResult GetByNomeQueryString(string nome)
        // {
        //     var professor = _context.Professores.Where(p => p.Nome.Contains(nome));

        //     if (professor == null)
        //     {
        //         return BadRequest("Professor não encontrado");
        //     }

        //     return Ok(professor);
        // }

        //Salvar novo registro
        //api/professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetAllProfessorById(id, false);

            if (prof != null)
            {
                _repo.Update(professor);

                if (_repo.SaveChanges())
                {
                    return Ok(professor);
                }

                return BadRequest("Professor não atualizado");
            }

            return BadRequest("O professor não foi encontrado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetAllProfessorById(id, false);
            if (prof != null)
            {
                _repo.Update(professor);

                if (_repo.SaveChanges())
                {
                    return Ok(professor);
                }

                return BadRequest("Professor não atualizado");
            }

            return BadRequest("O professor não foi encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetAllProfessorById(id);

            if (prof != null)
            {
                _repo.Delete(prof);

                if (_repo.SaveChanges())
                {
                    return Ok("Professor deletado com SUCESSO");
                }

                return BadRequest("Professor não deletado");
            }

            return BadRequest("O professor não foi encontrado");
        }
    }
}