using IT64_2019_URIS_CustomerRegistration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace IT64_2019_URIS_CustomerRegistration.Data
{
    public class LegalPersonRepository : ILegalPersonRepository
    {
        private readonly CustomerRegistrationApiDbContext dbContext;

        public LegalPersonRepository(CustomerRegistrationApiDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<LegalPerson>> GetAllAsync()
        {
            return await 
                dbContext.LegalPersons
                .Include(x => x.Customers)
                .ToListAsync();
        }

        public async Task<LegalPerson> GetAsync(Guid legalPersonId)
        {
            return await dbContext.LegalPersons
                .Include(x => x.Customers)
                .FirstOrDefaultAsync(x => x.LegalPersonId == legalPersonId);
        }
        public async Task<LegalPerson> AddAsync(LegalPerson legalPerson)
        {
            legalPerson.LegalPersonId = Guid.NewGuid();
            await dbContext.LegalPersons.AddAsync(legalPerson);
            await dbContext.SaveChangesAsync();
            return legalPerson;
        }

        public async Task<LegalPerson> UpdateAsync(Guid legalPersonId, LegalPerson legalPerson)
        {
            var existingLegalPerson = await dbContext.LegalPersons.FindAsync(legalPersonId);

            if(existingLegalPerson != null)
            {
                existingLegalPerson.NameLP = legalPerson.NameLP;
                existingLegalPerson.IdentificationNumLP = legalPerson.IdentificationNumLP;
                existingLegalPerson.CityLP = legalPerson.CityLP;
                existingLegalPerson.StateLP = legalPerson.StateLP;
                existingLegalPerson.ContactPerson = legalPerson.ContactPerson;
                existingLegalPerson.Positions = legalPerson.Positions;
                existingLegalPerson.Phone = legalPerson.Phone;
                existingLegalPerson.EmailLP = legalPerson.EmailLP;
                existingLegalPerson.Fax = legalPerson.Fax;
                existingLegalPerson.AccountNumLP = legalPerson.AccountNumLP;
                existingLegalPerson.CustomerId = legalPerson.CustomerId;

                await dbContext.SaveChangesAsync();
                return existingLegalPerson;
            }

            return null;
        }

        public async Task<LegalPerson> DeleteAsync(Guid legalPersonId)
        {
            var existingLegalPerson = await dbContext.LegalPersons.FindAsync(legalPersonId);
            
            if(existingLegalPerson == null) 
            {
                return null;
            }

            dbContext.LegalPersons.Remove(existingLegalPerson);
            await dbContext.SaveChangesAsync();
            return existingLegalPerson;

        }
    }
}
