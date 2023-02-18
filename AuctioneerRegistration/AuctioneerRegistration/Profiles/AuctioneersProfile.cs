using AutoMapper;

namespace AuctioneerRegistration.Profiles
{
    public class AuctioneersProfile : Profile
    {
        public AuctioneersProfile() 
        { 
            CreateMap<Entities.Auctioneer, Models.AuctioneerDto>().ReverseMap();

        }
    }
}
