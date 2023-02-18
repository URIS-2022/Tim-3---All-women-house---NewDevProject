using AutoMapper;

namespace URIS_OGLAS_IT72.Profiles
{
    public class DecisionOfAdvertismentProfile : Profile
    {

        public DecisionOfAdvertismentProfile()
        {
            CreateMap<Models.Domain.DecisionOfAdvertisment, Models.DTO.DecisionOfAdvertisment>()
                .ReverseMap();
        }

    }
}
