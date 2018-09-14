using System.Linq;
using AutoMapper;
using CustomerCare.Controllers.Resources;
using CustomerCare.Controllers.Resources.CustomerResources;
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
            CreateMap<Job, KeyValuePairResource>();
            CreateMap<Country, KeyValuePairResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<Governerate, KeyValuePairResource>();

            CreateMap<User, UserSaveResource>();
            CreateMap<Customer, CustomerSaveResource>();

            CreateMap<User, UserResource>()
                        .ForMember(ur => ur.NumOfInteractions, opt => opt.MapFrom(u => u.Interactions.Count));
            CreateMap<Customer, CustomerResource>()
             .ForMember(cr => cr.Country, opt => opt.MapFrom(v => v.Governerate.Country))
            .ForMember(cr => cr.Interactions, opt => opt.MapFrom(c => c.Interactions.Count));


            // API Resource to Domain
            CreateMap<UserQueryResource, UserQuery>();
            CreateMap<UserSaveResource, User>()
                        .ForMember(u => u.Id, opt => opt.Ignore());

            CreateMap<CustomerSaveResource, Customer>()
                        .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}