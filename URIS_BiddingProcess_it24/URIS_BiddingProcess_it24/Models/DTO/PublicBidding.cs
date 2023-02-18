using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_BiddingProcess_it24.Models.DTO
{
    public class PublicBidding
    {
        /// <summary>
        /// The unique identifier of the public bidding.
        /// </summary>
        public Guid PublicBiddingId { get; set; }
        /// <summary>
        /// The price step for the public bidding, which determines the minimum increment for each bid.
        /// </summary>
        public int PriceStep { get; set; }
        //Navigation Properties
        [ForeignKey("Biddings")]
        public Guid BiddingId { get; set; }
        /// <summary>
        /// The Bidding entity that this public bidding belongs to.
        /// </summary>
        public Bidding Bidding { get; set; }
    }
}
