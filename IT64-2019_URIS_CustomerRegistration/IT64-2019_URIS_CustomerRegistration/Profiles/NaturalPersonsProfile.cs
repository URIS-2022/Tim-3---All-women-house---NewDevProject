using AutoMapper;

namespace IT64_2019_URIS_CustomerRegistration.Profiles
{
    public class NaturalPersonsProfile : Profile
    {
        public NaturalPersonsProfile()
        {
            CreateMap<Entities.NaturalPerson, Models.NaturalPersonDto>().ReverseMap();

            CreateMap<Entities.Customer, Models.CustomerDto>().ReverseMap();
        }
    }
}
