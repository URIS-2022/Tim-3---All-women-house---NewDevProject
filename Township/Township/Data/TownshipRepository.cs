using Township.Entities;
using Township.Models;

namespace Township.Data
{
    public class TownshipRepository : ITownshipRepository
    {
        private readonly TownshipContext context;

        public TownshipRepository(TownshipContext context)
        {
            this.context = context;
        }

        public List<TownshipDto> GetTownships()
        {
            Console.WriteLine(context.Township.ToList());
            return context.Township.ToList();
        }

        public TownshipDto CreateTownship(TownshipDto township)
        {
            var createdEntity = context.Add(township);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public TownshipDto? GetTownshipById(Guid townshipId)
        {
            return context.Township.FirstOrDefault(e => e.IdTownship == townshipId);
        }

        public void DeleteTownship(Guid townshipId)
        {
            var township = GetTownshipById(townshipId);

            if (township != null)
            {
                context.Remove(township);
                context.SaveChanges();
            }
        }

        public TownshipDto UpdateTownship(TownshipDto township, TownshipDto newTownship)
        {
            township.NameOfTownship = newTownship.NameOfTownship;
            context.SaveChanges();
            return township;
        }
    }
}
