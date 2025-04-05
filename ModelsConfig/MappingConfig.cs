using AutoMapper;
using MyProject.Web.Models.Dto;

namespace MyProject.Web.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<InfoProductDto, ProductUpdateDto>().ReverseMap();
            CreateMap<DetailProductDto, ProductUpdateDto>().ReverseMap();
        }
    }
}
