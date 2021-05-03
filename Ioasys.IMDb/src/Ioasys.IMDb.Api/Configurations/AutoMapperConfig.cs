using AutoMapper;
using Ioasys.IMDb.Api.ViewModels;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Administrador, UsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Filme, FilmeCadastro>().ReverseMap();
            CreateMap<Filme, FilmeVisao>().ReverseMap();
            CreateMap<Voto, VotoViewModel>().ReverseMap();
        }
    }
}
