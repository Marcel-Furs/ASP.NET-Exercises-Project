using AutoMapper;
using Strona_Bazy.Data.Models;
using Strona_Bazy.Models;
using Microsoft.AspNetCore.Identity;

namespace Strona_Bazy.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Charakter, CharakterViewModel>();
            CreateMap<CharakterViewModel, Charakter>();
            CreateMap<RegisterViewModel, IdentityUser>();
        }
    }
}
