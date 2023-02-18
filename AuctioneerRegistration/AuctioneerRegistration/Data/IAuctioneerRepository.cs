using AuctioneerRegistration.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuctioneerRegistration.Data
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
