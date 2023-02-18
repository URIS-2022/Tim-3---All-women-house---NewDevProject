using Microsoft.EntityFrameworkCore;
using URIS_Licitacion_IT67_2019.Data;
using URIS_Licitacion_IT67_2019.Entities;

namespace URIS_Licitacion_IT67_2019.Repositories
{
    public class LicitationRepository: ILicitationRepository
    {
        private readonly LicitationDbContext licitationDbContext;

        public LicitationRepository(LicitationDbContext licitationDbContext)
        {
            this.licitationDbContext = licitationDbContext;
        }

        public async Task<Licitation> AddLicitation(Licitation licitation)
        {
            licitation.LicitationId = Guid.NewGuid();
            await licitationDbContext.AddAsync(licitation);
            await licitationDbContext.SaveChangesAsync();
            return licitation;
        }

        public async Task<Licitation> DeleteLicitation(Guid LicitationId)
        {
            var licitation = await licitationDbContext.Licitacions.FirstOrDefaultAsync(x => x.LicitationId == LicitationId);

            if(licitation == null)
            {
                return null;
            }

            licitationDbContext.Licitacions.Remove(licitation);
            await licitationDbContext.SaveChangesAsync();
            return licitation;


        }

        public async Task<Licitation> GetById(Guid LicitationId)
        {
           return await licitationDbContext.Licitacions.FirstOrDefaultAsync(x => x.LicitationId == LicitationId);
        }

        public async Task<Licitation> UpdateLicitation(Guid LicitationId, Licitation licitation)
        {
            var existingLicitation = await licitationDbContext.Licitacions.FirstOrDefaultAsync(x => x.LicitationId == LicitationId);
            
            if(existingLicitation == null)
            {
                return null;
            }

            existingLicitation.NumberOfLic = licitation.NumberOfLic;
            existingLicitation.Year = licitation.Year;
            existingLicitation.DateOfAnnouncment = licitation.DateOfAnnouncment;
            existingLicitation.ListOfIndividuals = licitation.ListOfIndividuals;
            existingLicitation.ListOfLegalEntity = licitation.ListOfLegalEntity;
            existingLicitation.DeadlineForSubmission = licitation.DeadlineForSubmission;
            existingLicitation.DecisionId = licitation.DecisionId;
            existingLicitation.secondRound = licitation.secondRound;

            await licitationDbContext.SaveChangesAsync();
            return existingLicitation;

        }

        async Task<IEnumerable<Licitation>> ILicitationRepository.GetAll()
        {
           return await licitationDbContext.Licitacions.ToListAsync();
        }
    }
}
