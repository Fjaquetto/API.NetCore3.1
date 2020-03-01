using APIEstudoAngular.API.DTOs;
using APIEstudoAngular.Business.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEstudoAngular.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuarios, UsuarioDTO>().ReverseMap();
            CreateMap<TipoUsuarios, TipoUsuarioDTO>().ReverseMap();
        }
    }
}
