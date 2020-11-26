﻿using System.Linq;
using AutoMapper;
using ProAgil.Api.Dtos;
using ProAgil.Domain;
using ProAgil.Domain.Identity;

namespace ProAgil.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest=> dest.Palestrantes, opt =>
                {
                    opt.MapFrom(src =>src.PalestranteEventos.Select(x=>x.Palestrante).ToList());
                }).ReverseMap();
            
            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest=>dest.Eventos, opt =>
                {
                    opt.MapFrom(origem=>origem.PalestranteEventos.Select(x=>x.Evento).ToList());
                }).ReverseMap();

            
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            
            
            
            
        }
    }
}