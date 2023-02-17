using Land.Entities;
using Land.Models;

namespace Land.Data
{
    public class LandRepository : ILandRepository
    {
        private readonly LandContext context;

        public LandRepository(LandContext context)
        {
            this.context = context;
        }

        public List<LandDto> GetLand()
        {
            Console.WriteLine(context.Land.ToList());
            return context.Land.ToList();
        }

        public LandDto CreateLand(LandDto land)
        {
            var createdEntity = context.Add(land);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public LandDto? GetLandById(Guid labelLand)
        {
            return context.Land.FirstOrDefault(e => e.LabelLand == labelLand);
        }

        public void DeleteLand(Guid labelLand)
        {
            var land = GetLandById(labelLand);

            if (land != null) 
            {
                context.Remove(land);
                context.SaveChanges();
            }
        }

        public LandDto UpdateLand(LandDto land, LandDto newLand)
        {
            land.Surface = newLand.Surface;
            land.SoilCulture = newLand.SoilCulture;
            land._Class = newLand._Class;
            land.Workability = newLand.Workability;
            land.FormOfProperty = newLand.FormOfProperty;
            land.Drainage = newLand.Drainage;
            context.SaveChanges();
            return land;
        }
    }
}
