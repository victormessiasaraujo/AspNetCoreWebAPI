using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>().
                ForMember(
                    dest => dest.Nome,
                    orig => orig.MapFrom(src => $"{src.Nome}{src.Sobrenome}")
                );

        }
    }
}