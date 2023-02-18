using AutoMapper;

namespace URIS_BiddingProcess_it24.Profiles
{
    public class PublicBiddingProfile : Profile
    {
        public PublicBiddingProfile()
        {
            CreateMap<Models.entity.PublicBidding,Models.DTO.PublicBidding>()
                .ReverseMap();
        }
    }
}
