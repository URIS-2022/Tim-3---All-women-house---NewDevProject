using IT64_2019_URIS_ExpertCommission.Entities;

namespace IT64_2019_URIS_ExpertCommission.Data
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member> GetAsync(Guid memberId);
        Task<Member> AddAsync(Member member);
        Task<Member> UpdateAsync(Guid memberId, Member member);
        Task<Member> DeleteAsync(Guid memberId);
    }
}
