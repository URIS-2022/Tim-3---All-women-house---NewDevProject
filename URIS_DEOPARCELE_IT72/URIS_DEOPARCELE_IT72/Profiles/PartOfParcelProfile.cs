using AutoMapper;

namespace URIS_DEOPARCELE_IT72.Profiles
{
    public class PartOfParcelProfile :Profile
    {

        public PartOfParcelProfile()
        {

            CreateMap<Models.Domain.PartOfParcel, Models.DTO.PartOfParcel>()
                .ReverseMap();
        }


    }
}
