using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_BiddingProcess_it24.Models.DTO
{
    public class AddBiddingConditionsRequest
    {
        /// <summary>
        /// The minimum price for the sale to be confirmed for the rental property.
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// The duration of the rental period.
        /// </summary>
        public string? RentalDuration { get; set; }
        /// <summary>
        /// The foreign key of the Bidding entity that this bidding conditions belongs to.
        /// </summary>
        public Guid BiddingId { get; set; }
    }
}
