using IT64_2019_URIS_CustomerRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace IT64_2019_URIS_CustomerRegistration.Data
{
    public class NaturalPersonRepository : INaturalPersonRepository
    {
        private readonly CustomerRegistrationApiDbContext dbContext;

        public NaturalPersonRepository(CustomerRegistrationApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

     
        public async Task<IEnumerable<NaturalPerson>> GetAllAsync()
        {
            return await 
                dbContext.NaturalPersons
                .Include(x => x.Customers)
                .ToListAsync();
        }

        public async Task<NaturalPerson> GetAsync(Guid naturalPersonId)
        {
            return await dbContext.NaturalPersons
                .Include(x => x.Customers)
                .FirstOrDefaultAsync(x => x.NaturalPersonId == naturalPersonId);

        }
        public async Task<NaturalPerson> AddAsync(NaturalPerson naturalPerson)
        {
            naturalPerson.NaturalPersonId = Guid.NewGuid();
            await dbContext.NaturalPersons.AddAsync(naturalPerson);
            await dbContext.SaveChangesAsync();
            return naturalPerson;

        }

        public async Task<NaturalPerson> UpdateAsync(Guid naturalPersonId, NaturalPerson naturalPerson)
        {
            var existingNaturalPerson = await dbContext.NaturalPersons.FindAsync(naturalPersonId);

            if(existingNaturalPerson != null)
            {
                existingNaturalPerson.FirstName = naturalPerson.FirstName;
                existingNaturalPerson.LastName = naturalPerson.LastName;
                existingNaturalPerson.JMBG = naturalPerson.JMBG;
                existingNaturalPerson.StreetNP = naturalPerson.StreetNP;
                existingNaturalPerson.CityNP = naturalPerson.CityNP;
                existingNaturalPerson.StateNP = naturalPerson.StateNP;
                existingNaturalPerson.ZipNP = naturalPerson.ZipNP;
                existingNaturalPerson.Tel1 = naturalPerson.Tel1;
                existingNaturalPerson.Tel2 = naturalPerson.Tel2;
                existingNaturalPerson.EmailNP = naturalPerson.EmailNP;
                existingNaturalPerson.AccountNumNP = naturalPerson.AccountNumNP;
                existingNaturalPerson.CustomerId = naturalPerson.CustomerId;

                await dbContext.SaveChangesAsync();

                return existingNaturalPerson;

            }
            return null;
        }

        public async Task<NaturalPerson> DeleteAsync(Guid naturalPersonId)
        {
            var existingNaturalPerson = await dbContext.NaturalPersons.FindAsync(naturalPersonId);

            if(existingNaturalPerson == null) 
            {
                return null;
            }

            dbContext.NaturalPersons.Remove(existingNaturalPerson);
            await dbContext.SaveChangesAsync();
            return existingNaturalPerson;

        }
    }
}
