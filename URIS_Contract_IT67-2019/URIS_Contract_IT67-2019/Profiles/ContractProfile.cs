using AutoMapper;
using URIS_Contract_IT67_2019.Entities;
using URIS_Contract_IT67_2019.Models;

namespace URIS_Contract_IT67_2019.Profiles
{
    public class ContractProfile: Profile
    {
        public ContractProfile()
        {
            CreateMap<Contract, ContractDto>()
                .ReverseMap();
        }
    }
}
