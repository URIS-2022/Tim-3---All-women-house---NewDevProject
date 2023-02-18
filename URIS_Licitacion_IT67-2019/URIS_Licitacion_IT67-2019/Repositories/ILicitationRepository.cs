using Microsoft.EntityFrameworkCore;
using URIS_Licitacion_IT67_2019.Data;
using URIS_Licitacion_IT67_2019.Entities;

namespace URIS_Licitacion_IT67_2019.Repositories
{
    public interface ILicitationRepository
    { 
        Task<IEnumerable<Licitation>> GetAll();

        Task<Licitation> GetById(Guid LicitationId);

        Task<Licitation> AddLicitation(Licitation licitation);

        Task<Licitation> DeleteLicitation(Guid LicitationId);

        Task<Licitation> UpdateLicitation(Guid LicitationId, Licitation licitation);
    }
}
