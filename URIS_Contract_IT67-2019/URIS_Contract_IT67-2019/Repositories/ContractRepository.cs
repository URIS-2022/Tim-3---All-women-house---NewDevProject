using Microsoft.EntityFrameworkCore;
using URIS_Contract_IT67_2019.Data;
using URIS_Contract_IT67_2019.Entities;

namespace URIS_Contract_IT67_2019.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ContractDbContext contractDbContext;

        public ContractRepository(ContractDbContext contractDbContext )
        {
            this.contractDbContext = contractDbContext;
        }

        public async Task<Contract> AddContract(Contract contract)
        {
            contract.ContractId= Guid.NewGuid();
            await contractDbContext.Contracts.AddAsync( contract );
            await contractDbContext.SaveChangesAsync();
            return contract;
            
        }

        public async Task<Contract> DeleteContract(Guid ContractId)
        {
            var existingContract = await contractDbContext.Contracts.FindAsync(ContractId);
            if(existingContract == null)
            {
                return null;
            }
            contractDbContext.Contracts.Remove(existingContract);
            await contractDbContext.SaveChangesAsync();
            return existingContract;
            
        }

        public async Task<IEnumerable<Contract>> GetAllContracts()
        {
            return await contractDbContext.Contracts.ToListAsync();
        }

        public async Task<Contract> GetContract(Guid ContractId)
        {
            return await contractDbContext.Contracts.FirstOrDefaultAsync(x => x.ContractId == ContractId);
        }

        public async Task<Contract> UpdateContract(Guid ContractId, Contract contract)
        {
            var existingContract = await contractDbContext.Contracts.FindAsync(ContractId);
            
            if (existingContract == null) 
            {
                return null;
            }

            existingContract.PaymentGuarantor = contract.PaymentGuarantor;
            existingContract.ReferenceNumber= contract.ReferenceNumber;
            existingContract.DateOfSeduction = contract.DateOfSeduction;
            existingContract.PlaceOfSigning = contract.PlaceOfSigning;
            existingContract.DateOfSigning = contract.DateOfSigning;
            await contractDbContext.SaveChangesAsync();
            return existingContract;
        
        }
    }
}
