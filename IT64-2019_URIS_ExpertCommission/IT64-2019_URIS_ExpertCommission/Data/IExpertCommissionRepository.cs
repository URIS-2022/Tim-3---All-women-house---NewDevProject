using IT64_2019_URIS_ExpertCommission.Entities;

namespace IT64_2019_URIS_ExpertCommission.Data
{
    public interface IExpertCommissionRepository
    {
        Task<IEnumerable<ExpertCommission>> GetAllAsync();
        Task<ExpertCommission> GetAsync(Guid expertCommissionId);
        Task<ExpertCommission> AddAsync(ExpertCommission expertCommission);
        Task<ExpertCommission> DeleteAsync(Guid expertCommissionId);
        Task<ExpertCommission> UpdateAsync(Guid expertCommissionId, ExpertCommission expertCommission);
    }
}
