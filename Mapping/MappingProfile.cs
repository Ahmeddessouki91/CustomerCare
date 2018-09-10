using System.Linq;
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
            CreateMap<Job, KeyValuePairResource>();
            CreateMap<Country, KeyValuePairResource>();
            CreateMap<Governerate, KeyValuePairResource>();
            CreateMap<User,UserSaveResource>();
            CreateMap<User, UserResource>()
                        .ForMember(ur => ur.NumOfCustomers, opt => opt.MapFrom(u => u.Customers.Count))
                        .ForMember(ur => ur.NumOfInteractions, opt => opt.MapFrom(u => u.Interactions.Count))
                        .ForMember(ur => ur.Customers, opt => opt.MapFrom(u => u.Customers.Select(ur => 
                               new CustomerResource
                                   {
                                       Id = ur.Id,
                                       Mobile = ur.Mobile,
                                       Activated = ur.Activated,
                                       Address = ur.Address,
                                       Email = ur.Email,
                                       Name = ur.Name
                                   })))
                        .ForMember(ur => ur.Interactions, opt => opt.MapFrom(u => u.Interactions.Select(ur =>
                               new InteractionResource
                               {
                                   Id = ur.Id,
                                   Status = ur.Status,
                                   Comment = ur.Comment,
                                   Date = ur.Date,
                                   Customer = new CustomerResource { Id = ur.Customer.Id, Name = ur.Customer.Name }
                               })));



            // API Resource to Domain
            CreateMap<UserQueryResource, UserQuery>();
            CreateMap<UserSaveResource, User>()
                        .ForMember(u => u.Id, opt => opt.Ignore());
        }
    }
}