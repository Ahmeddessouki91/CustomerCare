using AutoMapper;
using CustomerCare.Controllers.Resources.UserResouce;
using CustomerCare.Core.Models;

namespace CustomerCare.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // From Resource Api to Domain
            CreateMap<UserSaveResource, User>()
                        .ForMember(u => u.Id, opt => opt.Ignore())
                        .ForMember(u => u.Name, opt => opt.MapFrom(ur => ur.Name))
                        .ForMember(u => u.Name, opt => opt.MapFrom(ur => ur.Email));
            CreateMap<UserUpdateResouce, User>()
                        .ForMember(u => u.Id, opt => opt.Ignore())
                        .ForMember(u => u.Name, opt => opt.MapFrom(ur => ur.Name))
                        .ForMember(u => u.Name, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}