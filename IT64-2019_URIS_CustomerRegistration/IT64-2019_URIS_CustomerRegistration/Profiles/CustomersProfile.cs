using AutoMapper;

namespace IT64_2019_URIS_CustomerRegistration.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Entities.Customer, Models.CustomerDto>().ReverseMap();
        }
    }
}
