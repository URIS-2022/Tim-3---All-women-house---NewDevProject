using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_BiddingProcess_it24.Models.entity
{
    public class OpeningOfBids
    {
        public Guid OpeningOfBidsId { get; set; }
        public DateTime ArrivingDate { get; set; }
        public DateTime ArrivingHour { get; set; }

        //Navigation Properties
        [ForeignKey("Biddings")]
        public Guid BiddingId { get; set; }
        public Bidding Bidding { get; set; }
    }
}
