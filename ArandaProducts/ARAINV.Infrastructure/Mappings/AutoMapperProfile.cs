using ARAINV.Core.Entities;
using ARAINV.Infrastructure.DTOs;
using ARAINV.Infrastructure.DTOs.Products;
using ARAINV.Infrastructure.DTOs.Users;
using AutoMapper;

namespace ARAINV.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /* Productos */
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, CreateProductDTO>();
            CreateMap<Product, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, DeleteProductDTO>();
            CreateMap<DeleteProductDTO, Product>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<User, UserTokenDTO>();
            CreateMap<UserTokenDTO, User>();

            /* Categorias */
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
