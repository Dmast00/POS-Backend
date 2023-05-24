using AutoMapper;
using POS.Application.Dtos.Response;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Mappers
{
    public class CategoriesMappingProfile : Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<Category, CategoryResponseDTO>()
                .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active)? "Activo" : "inactivo")).ReverseMap();
            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDTO>>()
                .ReverseMap();

            CreateMap<CategoryResponseDTO, Category>();
            CreateMap<Category, CategorySelectResponseRequest>();

        }
    }
}
