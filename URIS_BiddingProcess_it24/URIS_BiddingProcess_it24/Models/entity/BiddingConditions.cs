using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_BiddingProcess_it24.Models.entity
{
    public class BiddingConditions
    {
        public Guid BiddingConditionsId { get; set; }
        public int Price { get; set; }
        public string? RentalDuration { get; set; }
        //Navigation Properties
        [ForeignKey("Biddings")]
        public Guid BiddingId { get; set; }
        public Bidding Bidding { get; set; }

    }
}
