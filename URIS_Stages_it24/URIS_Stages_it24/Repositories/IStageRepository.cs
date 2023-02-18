using URIS_Stages_it24.Models.Entities;

namespace URIS_Stages_it24.Repositories
{
    public interface IStageRepository
    {
        Task<IEnumerable<Stage>> GetAllAsync();

        Task<Stage> GetByIdAsync(Guid id);

        Task<Stage> AddAsync(Stage stage);

        Task<Stage> DeleteAsync(Guid id);

        Task<Stage> UpdateAsync(Guid id, Stage stage);
    }
}
