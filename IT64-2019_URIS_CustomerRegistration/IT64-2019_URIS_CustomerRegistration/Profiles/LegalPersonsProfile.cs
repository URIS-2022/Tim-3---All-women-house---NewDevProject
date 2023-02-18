using AutoMapper;

namespace IT64_2019_URIS_CustomerRegistration.Profiles
{
    public class LegalPersonsProfile : Profile
    {
        public LegalPersonsProfile()
        {
            CreateMap<Entities.LegalPerson, Models.LegalPersonDto>().ReverseMap();

            CreateMap<Entities.Customer, Models.CustomerDto>().ReverseMap();


        }
    }
}
