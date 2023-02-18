using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_BiddingProcess_it24.Models.DTO
{
    public class OpeningOfBids
    {
        /// <summary>
        /// The unique identifier of the opening of bids entity.
        /// </summary>
        public Guid OpeningOfBidsId { get; set; }
        /// <summary>
        /// The date when bids should arrive for the opening of bids.
        /// </summary>
        public DateTime ArrivingDate { get; set; }
        /// <summary>
        /// The hour when bids should arrive for the opening of bids.
        /// </summary>
        public DateTime ArrivingHour { get; set; }

        //Navigation Properties
        [ForeignKey("Biddings")]
        public Guid BiddingId { get; set; }
        /// <summary>
        /// The bidding entity associated with this opening of bids.
        /// </summary>
        public Bidding Bidding { get; set; }
    }
}
