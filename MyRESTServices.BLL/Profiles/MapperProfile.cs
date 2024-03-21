using AutoMapper;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.BLL.Profiles
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();

            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<ArticleCreateDTO, Article>();
            CreateMap<ArticleUpdateDTO, Article>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleCreateDTO, Role>();


        }
    }
}
