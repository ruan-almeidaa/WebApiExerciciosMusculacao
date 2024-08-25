using AutoMapper;
using Entities.Entities;
using Entities.Enums.Uteis;
using Entities.Dtos;
using Entities.Enums.Exercicio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exercicio, ExercicioDTO>()
                .ForMember(dest => dest.GrupoMuscularDescricao, opt => opt.MapFrom(src => UteisEnums.BuscaDescricao(src.GrupoMuscular)))
                .ForMember(dest => dest.GrupoMuscular, opt => opt.MapFrom(src => (int)src.GrupoMuscular));
        }
    }
}
