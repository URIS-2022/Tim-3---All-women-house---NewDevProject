using IT64_2019_URIS_AuctioneerRegistration.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IT64_2019_URIS_AuctioneerRegistration.Data
{
    public interface IAuctioneerRepository
    {
        Task<IEnumerable<Auctioneer>> GetAllAsync();
        Task<Auctioneer> GetAsync(Guid auctioneerId);
        Task<Auctioneer> AddAsync(Auctioneer auctioneer);
        Task<Auctioneer> UpdateAsync(Guid auctioneerId, Auctioneer auctioneer);
        Task<Auctioneer> DeleteAsync(Guid auctioneerId);
    }
}
