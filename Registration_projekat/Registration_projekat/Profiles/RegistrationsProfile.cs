using AutoMapper;

namespace Registration_projekat.Profiles
{
    public class RegistrationsProfile : Profile
    {
        public RegistrationsProfile()
        {
            CreateMap<Models.Registration, Models.DTO.Registration>()
              .ReverseMap();

            CreateMap<Models.RegistrationForm, Models.DTO.RegistrationForm>()
                .ReverseMap();
        }
    }
}
