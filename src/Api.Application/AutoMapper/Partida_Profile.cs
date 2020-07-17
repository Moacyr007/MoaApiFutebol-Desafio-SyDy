using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class Partida_Profile : Profile
    {

        public Partida_Profile()
        {
            CreateMap<PartidaEntity, PartidaViewModel>()
                .ForMember(x => x.Times, y => y.MapFrom(src => src.Time1.Nome + " x " + src.Time2.Nome))
                .ForMember(x => x.Resultado, y => y.MapFrom(src => src.Gols1 + " x " + src.Gols2));
        }
       
    }
}
