using Microsoft.EntityFrameworkCore;
using URIS_DEOPARCELE_IT72.Data;
using URIS_DEOPARCELE_IT72.Models.Domain;

namespace URIS_DEOPARCELE_IT72.Repositories
{
    public class PartOfParcelRepository:IPartOfParcelRepository
    {
        private readonly PartParcelAPIDbContext partParcelAPIDbContext;
        public PartOfParcelRepository(PartParcelAPIDbContext partParcelAPIDbContext) 
        {
            this.partParcelAPIDbContext = partParcelAPIDbContext;
        }


        public async Task<IEnumerable<PartOfParcel>> GetAllAsync()
        {
            return await partParcelAPIDbContext.PartOfParcels.ToListAsync();
        }

        public async Task<PartOfParcel> GetAsync(Guid id)
        {
            return await partParcelAPIDbContext.PartOfParcels.FirstOrDefaultAsync(x => x.PartOfParcelID == id);


        }

        public async Task<PartOfParcel> AddAsync(PartOfParcel partOfParcel)
        {

            partOfParcel.PartOfParcelID = Guid.NewGuid();
            await partParcelAPIDbContext.PartOfParcels.AddAsync(partOfParcel);
            await partParcelAPIDbContext.SaveChangesAsync();

            return partOfParcel;
        }

        public async Task<PartOfParcel> DeleteAsync(Guid id)
        {
            var partOfParcel = await partParcelAPIDbContext.PartOfParcels.FirstOrDefaultAsync(x => x.PartOfParcelID == id);

            if (partOfParcel == null)
            {
                return null;

            }

            partParcelAPIDbContext.PartOfParcels.Remove(partOfParcel);
            await partParcelAPIDbContext.SaveChangesAsync();

            return partOfParcel;
        }



        public async Task<PartOfParcel> UpdateAsync(Guid id, PartOfParcel partOfParcel)
        {
            var existingpartOfParcel = await partParcelAPIDbContext.PartOfParcels.FirstOrDefaultAsync(x => x.PartOfParcelID == id);

            if (existingpartOfParcel == null)
            {
                return null;
            }
            existingpartOfParcel.KvalitetZemljiste = partOfParcel.KvalitetZemljiste;
            existingpartOfParcel.PovrsinaDelaParcele = partOfParcel.PovrsinaDelaParcele;

            await partParcelAPIDbContext.SaveChangesAsync();

            return existingpartOfParcel;

        }
    }
}
