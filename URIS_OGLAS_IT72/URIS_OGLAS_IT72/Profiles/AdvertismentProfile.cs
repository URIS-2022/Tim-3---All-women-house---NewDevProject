using AutoMapper;

namespace URIS_OGLAS_IT72.Profiles
{
    public class AdvertismentProfile : Profile
    {

        public AdvertismentProfile()
        {

        CreateMap<Models.Domain.Advertisment, Models.DTO.Advertisment>()
            .ReverseMap();
        }
    }
}
