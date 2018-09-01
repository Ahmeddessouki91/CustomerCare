using AutoMapper;
using CustomerCare.Controllers.Resources;
using CustomerCare.Controllers.Resources.UserResouce;
using CustomerCare.Core.Models;

namespace CustomerCare.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resources
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            

            // API Resource to Domain
            CreateMap<UserQueryResource, UserQuery>();
            CreateMap<UserSaveResource, User>()
                        .ForMember(u => u.Id, opt => opt.Ignore())
                        .ForMember(u => u.Name, opt => opt.MapFrom(ur => ur.Name))
                        .ForMember(u => u.Email, opt => opt.MapFrom(ur => ur.Email));
                        
            CreateMap<UserUpdateResouce, User>()
                        .ForMember(u => u.Id, opt => opt.Ignore())
                        .ForMember(u => u.Name, opt => opt.MapFrom(ur => ur.Name))
                        .ForMember(u => u.Email, opt => opt.MapFrom(ur => ur.Email))
                        .ForMember(u => u.Deactive, opt => opt.MapFrom(ur => ur.Deactive));
        }
    }
}