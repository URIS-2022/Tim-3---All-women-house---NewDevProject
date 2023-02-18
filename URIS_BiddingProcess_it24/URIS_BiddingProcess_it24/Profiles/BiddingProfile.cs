using AutoMapper;

namespace URIS_BiddingProcess_it24.Profiles
{
    public class BiddingProfile:Profile
    {
        public BiddingProfile()
        {
            CreateMap<Models.entity.Bidding,Models.DTO.Bidding>()
                .ReverseMap();
        }
    }
}
