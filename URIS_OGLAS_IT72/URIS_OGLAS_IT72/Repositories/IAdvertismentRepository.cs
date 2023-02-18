using System.Reflection.Metadata;
using URIS_OGLAS_IT72.Models.Domain;

namespace URIS_OGLAS_IT72.Repositories
{
    public interface IAdvertismentRepository
    {

        Task<IEnumerable<Advertisment>> GetAllAsync();

        Task<Advertisment> GetAsync(Guid id);


        Task<Advertisment> AddAsync(Advertisment advertisment);

        Task<Advertisment> DeleteAsync(Guid id);

        Task<Advertisment> UpdateAsync(Guid id, Advertisment advertisment);
    }
}
