using Microsoft.EntityFrameworkCore;
using URIS_Contract_IT67_2019.Entities;

namespace URIS_Contract_IT67_2019.Data
{
    public class ContractDbContext: DbContext
    {
        public ContractDbContext(DbContextOptions<ContractDbContext> options): base(options)
        {

        }
        public DbSet<Contract> Contracts { get; set; }
    }
}
