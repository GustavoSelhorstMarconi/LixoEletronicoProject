using AutoMapper;
using LixoEletronico.Application.Dtos;
using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application.Helpers
{
    public class LixoEletronicoProfiler : Profile
    {
        public LixoEletronicoProfiler()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}
