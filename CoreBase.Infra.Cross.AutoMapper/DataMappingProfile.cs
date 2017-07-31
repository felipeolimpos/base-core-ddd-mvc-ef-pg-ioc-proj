using AutoMapper;
using CoreBase.Domain.Entities;
using CoreBase.Infra.Cross.DTO;

namespace CoreBase.Infra.Cross.AutoMapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodDTO>().ReverseMap();
        }
    }
}
