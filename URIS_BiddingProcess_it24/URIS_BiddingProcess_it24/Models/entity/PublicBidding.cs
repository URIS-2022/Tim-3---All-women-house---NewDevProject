using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_BiddingProcess_it24.Models.entity
{
    public class PublicBidding
    {
        public Guid PublicBiddingId { get; set; }
        public int PriceStep { get; set; }
        //Navigation Properties
        [ForeignKey("Biddings")]
        public Guid BiddingId { get; set; }
        public Bidding Bidding { get; set; }
    }
}
