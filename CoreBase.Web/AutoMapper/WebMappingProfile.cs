using AutoMapper;
using CoreBase.Infra.Cross.DTO;
using CoreBase.Web.ViewModels;

namespace CoreBase.Web.AutoMapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>()
                .ReverseMap()
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore());
            CreateMap<ProductDTO, ProductViewModel>()
                .ReverseMap()
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore());
            CreateMap<PaymentMethodDTO, PaymentMethodViewModel>()
                .ReverseMap()
                .ForMember(dto => dto.CreatedAt, opt => opt.Ignore());
        }
    }
}
