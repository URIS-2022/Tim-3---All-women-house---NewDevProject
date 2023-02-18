using AutoMapper;

namespace URIS_Licitacion_IT67_2019.Profiles
{
    public class LicitationProfile: Profile
    {
        public LicitationProfile()
        {
            CreateMap<Entities.Licitation, Models.LicitationDto>()
                .ReverseMap();
        }
    }
}
