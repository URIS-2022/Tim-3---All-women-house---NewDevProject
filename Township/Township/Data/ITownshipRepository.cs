using Township.Models;
using Township.Entities;
using System.Collections.Generic;


namespace Township.Data
{
    public interface ITownshipRepository
    {
        List<TownshipDto> GetTownships();

        TownshipDto CreateTownship(TownshipDto township);

        TownshipDto? GetTownshipById(Guid townshipId);

        void DeleteTownship(Guid townshipId);

        TownshipDto UpdateTownship(TownshipDto township, TownshipDto newTownship);
    }
}
