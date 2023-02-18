using AutoMapper;

namespace URIS_BiddingProcess_it24.Profiles
{
    public class BiddingConditionsProfile : Profile
    {
        public BiddingConditionsProfile()
        {
            CreateMap<Models.entity.BiddingConditions,Models.DTO.BiddingConditions>()
                .ReverseMap();
        }
    }
}
