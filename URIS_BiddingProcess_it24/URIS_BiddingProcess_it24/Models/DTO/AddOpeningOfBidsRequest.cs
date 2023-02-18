namespace URIS_BiddingProcess_it24.Models.DTO
{
    public class AddOpeningOfBidsRequest
    {
        /// <summary>
        /// The date when bids should arrive for the opening of bids.
        /// </summary>
        public DateTime ArrivingDate { get; set; }
        /// <summary>
        /// The hour when bids should arrive for the opening of bids.
        /// </summary>
        public DateTime ArrivingHour { get; set; }
        /// <summary>
        /// The foreign key of the Bidding entity that this bidding conditions belongs to.
        /// </summary>
        public Guid BiddingId { get; set; }
    }
}
