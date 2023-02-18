using Microsoft.EntityFrameworkCore;
using URIS_Stages_it24.Data;
using URIS_Stages_it24.Models.Entities;

namespace URIS_Stages_it24.Repositories
{
    public class StageRepository : IStageRepository
    {
        private readonly StagesApiDbContext stagesAPIDbContext;

        public StageRepository(StagesApiDbContext stagesAPIDbContext)
        {
            this.stagesAPIDbContext = stagesAPIDbContext;
        }
        public async Task<Stage> AddAsync(Stage stage)
        {
            stage.StageId = Guid.NewGuid();
            await stagesAPIDbContext.AddAsync(stage);
            await stagesAPIDbContext.SaveChangesAsync();
            return stage;
        }

        public async Task<Stage> DeleteAsync(Guid id)
        {
            var stage = await stagesAPIDbContext.Stages.FindAsync(id);
            if (stage == null)
            {
                return null;
            }
            stagesAPIDbContext.Stages.Remove(stage);
            await stagesAPIDbContext.SaveChangesAsync();
            return stage;
        }

        public async Task<IEnumerable<Stage>> GetAllAsync()
        {
            return await stagesAPIDbContext.Stages.ToListAsync();
        }

        public async Task<Stage> GetByIdAsync(Guid id)
        {
            return await stagesAPIDbContext.Stages.FirstOrDefaultAsync(x => x.StageId == id);
        }

        public async Task<Stage> UpdateAsync(Guid id, Stage stage)
        {
            var existingStage = await stagesAPIDbContext.Stages.FirstOrDefaultAsync(x => x.StageId == id);
            if (existingStage == null)
            {
                return null;
            }
            existingStage.StageNumber = stage.StageNumber;
            existingStage.StageDay = stage.StageDay;

            await stagesAPIDbContext.SaveChangesAsync();

            return existingStage;
        }
    }
}
