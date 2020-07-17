using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.AutoMapper
{
    public class Time_Profile : Profile
    {
        public Time_Profile()
        {
            CreateMap<TimeEntity, TimeViewModel>();
                //.ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
                //.ForMember(x => x.Nome, y => y.MapFrom(src => src.Nome)).ReverseMap();
        }
    }
}
