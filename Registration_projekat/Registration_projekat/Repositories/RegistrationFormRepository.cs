using Microsoft.EntityFrameworkCore;
using Registration_projekat.Data;
using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public class RegistrationFormRepository : IRegistrationFormRepository
    {
        private readonly RegistrationDBContext registrationDBContext;

        public RegistrationFormRepository(RegistrationDBContext registrationDBContext)
        {
            this.registrationDBContext = registrationDBContext;
        }

        public async Task<RegistrationForm> AddAsync(RegistrationForm registrationForm)
        {
            //Assign New ID
            registrationForm.RegistrationFormId = Guid.NewGuid();
            await registrationDBContext.RegistrationForms.AddAsync(registrationForm);
            await registrationDBContext.SaveChangesAsync();

            return registrationForm;
        }

        public async Task<RegistrationForm> DeleteAsync(Guid id)
        {
            var existingRegistrationForm = await registrationDBContext.RegistrationForms.FindAsync(id);
            if (existingRegistrationForm == null)
            {
                return null;
            }
            registrationDBContext.RegistrationForms.Remove(existingRegistrationForm);

            await registrationDBContext.SaveChangesAsync();
            return existingRegistrationForm;
        }

        public async Task<IEnumerable<RegistrationForm>> GetAllAsync()
        {
            return await registrationDBContext.RegistrationForms.ToListAsync();
        }

        public Task<RegistrationForm> GetAsync(Guid id)
        {
            return registrationDBContext.RegistrationForms
                 .FirstOrDefaultAsync(x => x.RegistrationFormId == id);
        }

        public async Task<RegistrationForm> UpdateAsync(Guid id, RegistrationForm registrationForm)
        {
            var existingRegistrationForm = await registrationDBContext.RegistrationForms.FindAsync(id);

            if (existingRegistrationForm != null)
            {
                existingRegistrationForm.Surname = registrationForm.Surname;
                existingRegistrationForm.Name = registrationForm.Name;
                existingRegistrationForm.Address = registrationForm.Address;
                existingRegistrationForm.JMBG = registrationForm.JMBG;
                existingRegistrationForm.Country = registrationForm.Country;
                existingRegistrationForm.Email = registrationForm.Email;
                existingRegistrationForm.Username = registrationForm.Username;
                existingRegistrationForm.Password = registrationForm.Password;
                await registrationDBContext.SaveChangesAsync();
                return existingRegistrationForm;

            }
            return null;
        }
    }
}
