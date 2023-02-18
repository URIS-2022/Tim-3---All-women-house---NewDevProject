using IT64_2019_URIS_ExpertCommission.Entities;
using Microsoft.EntityFrameworkCore;

namespace IT64_2019_URIS_ExpertCommission.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ExpertCommissionAPIDbContext dbContext;

        public MemberRepository(ExpertCommissionAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

      
        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await dbContext.Members
                .Include(x => x.ExpertCommission)
                .ToListAsync();
        }

        public async Task<Member> GetAsync(Guid memberId)
        {
            return await dbContext.Members
                .Include(x => x.ExpertCommission)
                .FirstOrDefaultAsync(x => x.MemberId == memberId);
        }

        public async Task<Member> AddAsync(Member member)
        {
            member.MemberId = Guid.NewGuid();
            await dbContext.Members.AddAsync(member);
            await dbContext.SaveChangesAsync();
            return member;
        }

        public async Task<Member> UpdateAsync(Guid memberId, Member member)
        {
            var existingMember = await dbContext.Members.FindAsync(memberId);

            if(existingMember == null)
            {
                return null;
            }
            existingMember.FirstName = member.FirstName;
            existingMember.LastName = member.LastName;
            existingMember.Phone = member.Phone;
            existingMember.Email = member.Email;
            existingMember.ExpertCommissionId = member.ExpertCommissionId;

            await dbContext.SaveChangesAsync();
            return existingMember;
        }

        public async Task<Member> DeleteAsync(Guid memberId)
        {
            var existingMember = await dbContext.Members.FindAsync(memberId);
            if(existingMember != null)
            {
                dbContext.Members.Remove(existingMember);
                await dbContext.SaveChangesAsync();
                return existingMember;
            }
            return null;
        }
    }
}
