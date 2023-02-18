using AutoMapper;
using URIS_Ministry_IT67_2019.Entities;
using URIS_Ministry_IT67_2019.Models;

namespace URIS_Ministry_IT67_2019.Profiles
{
    public class MinistryProfile: Profile
    {
        public MinistryProfile()
        {
            CreateMap<Ministry, MinistryDto>()
                .ReverseMap();
        }
    }
}
