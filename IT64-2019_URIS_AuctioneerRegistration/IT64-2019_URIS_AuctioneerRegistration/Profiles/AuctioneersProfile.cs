using AutoMapper;

namespace IT64_2019_URIS_AuctioneerRegistration.Profiles
{
    public class AuctioneersProfile : Profile
    {
        public AuctioneersProfile() 
        { 
            CreateMap<Entities.Auctioneer, Models.AuctioneerDto>().ReverseMap();

        }
    }
}
