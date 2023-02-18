using AutoMapper;
using URIS_ProtectedZone_IT67_2019.Entities;
using URIS_ProtectedZone_IT67_2019.Models;

namespace URIS_ProtectedZone_IT67_2019.Profiles
{
    public class DocumentProtectedZoneProfile: Profile
    {
        public DocumentProtectedZoneProfile()
        {
            CreateMap<DocumentProtectedZone, DocumentProtectedZoneDto>()
                .ReverseMap();
        }
    }
    
}
