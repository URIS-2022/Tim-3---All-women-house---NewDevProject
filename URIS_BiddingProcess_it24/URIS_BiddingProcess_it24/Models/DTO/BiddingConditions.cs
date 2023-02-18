using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_BiddingProcess_it24.Models.DTO
{
    public class BiddingConditions
    {
        /// <summary>
        /// The unique identifier for the bidding conditions.
        /// </summary>
        public Guid BiddingConditionsId { get; set; }
        /// <summary>
        /// The minimum price for the sale to be confirmed for the rental property.
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// The duration of the rental period.
        /// </summary>
        public string? RentalDuration { get; set; }
        //Foreign Key
        [ForeignKey("Biddings")]
        public Guid BiddingId { get; set; }
        /// <summary>
        /// The associated bidding for these conditions.
        /// </summary>
        public Bidding Bidding { get; set; }
    }
}
