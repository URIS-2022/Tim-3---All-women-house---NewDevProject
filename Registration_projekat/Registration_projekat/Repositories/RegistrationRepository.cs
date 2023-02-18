using Microsoft.EntityFrameworkCore;
using Registration_projekat.Data;
using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly RegistrationDBContext registrationDBContext;

        public RegistrationRepository(RegistrationDBContext registrationDBContext)
        {
            this.registrationDBContext = registrationDBContext;
        }

        public async Task<Registration> AddAsync(Registration registration)
        {
            //Assign New ID
            registration.RegistrationId = Guid.NewGuid();
            await registrationDBContext.Registrations.AddAsync(registration);
            await registrationDBContext.SaveChangesAsync();

            return registration;
        }

        public async Task<Registration> DeleteAsync(Guid id)
        {
            var existingRegistration = await registrationDBContext.Registrations.FindAsync(id);
            if(existingRegistration == null)
            {
                return null;
            }
            registrationDBContext.Registrations.Remove(existingRegistration);

            await registrationDBContext.SaveChangesAsync();
            return existingRegistration;
        }

        public async Task<IEnumerable<Registration>> GetAllAsync()
        {
            return await 
                registrationDBContext.Registrations
                .Include(x => x.RegistrationForm)
                .ToListAsync();
        }

        public Task<Registration> GetAsync(Guid id)
        {
           return registrationDBContext.Registrations
                .Include(x => x.RegistrationForm)
                .FirstOrDefaultAsync(x => x.RegistrationId == id);
        }

        public async Task<Registration> UpdateAsync(Guid id, Registration registration)
        {
           var existingRegistration = await registrationDBContext.Registrations.FindAsync(id);

            if(existingRegistration != null)
            {
                existingRegistration.DateOfRegistration = registration.DateOfRegistration;
                existingRegistration.Location = registration.Location;
                existingRegistration.RegistrationFormId = registration.RegistrationFormId;
                await registrationDBContext.SaveChangesAsync();
                return existingRegistration;

            }
            return null;
        }
    }
}
