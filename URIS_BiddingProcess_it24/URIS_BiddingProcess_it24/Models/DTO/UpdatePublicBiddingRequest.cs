namespace URIS_BiddingProcess_it24.Models.DTO
{
    public class UpdatePublicBiddingRequest
    {
        /// <summary>
        /// The price step for the public bidding, which determines the minimum increment for each bid.
        /// </summary>
        public int PriceStep { get; set; }
        /// <summary>
        /// The foreign key of the Bidding entity that this public bidding belongs to.
        /// </summary>
        public Guid BiddingId { get; set; }
    }
}
