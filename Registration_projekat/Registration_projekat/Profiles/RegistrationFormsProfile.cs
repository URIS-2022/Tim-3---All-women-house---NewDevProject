using AutoMapper;

namespace Registration_projekat.Profiles
{
    public class RegistrationFormsProfile : Profile
    {
        public RegistrationFormsProfile()
        {
            CreateMap<Models.RegistrationForm, Models.DTO.RegistrationForm>()
                .ReverseMap();
        }
    }
}
