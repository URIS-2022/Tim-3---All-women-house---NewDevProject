using AutoMapper;

namespace URIS_BiddingProcess_it24.Profiles
{
    public class OpeningOfBidsProfile : Profile
    {
        public OpeningOfBidsProfile()
        {
            CreateMap<Models.entity.OpeningOfBids,Models.DTO.OpeningOfBids>()
                .ReverseMap();
        }
    }
}
