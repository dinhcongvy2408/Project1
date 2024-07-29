using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterVM,KhachHang>().ForMember(kh=>kh.HoTen,option=>option.MapFrom(RegisterVM=>RegisterVM.HoTen))
                .ReverseMap();
        }

    }
}
