using URIS_Contract_IT67_2019.Entities;

namespace URIS_Contract_IT67_2019.Repositories
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> GetAllContracts();

        Task<Contract> GetContract(Guid ContractId);

        Task<Contract> AddContract(Contract contract);

        Task<Contract> UpdateContract(Guid ContractId, Contract contract);

        Task<Contract> DeleteContract(Guid ContractId);
    }
}
