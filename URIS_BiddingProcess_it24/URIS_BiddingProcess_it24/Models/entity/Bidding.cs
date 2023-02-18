namespace URIS_BiddingProcess_it24.Models.entity
{
    public class Bidding
    {
        public Guid BiddingId { get; set; }
        public string? BiddingCode { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public bool Excepted { get; set; }
        public int StartingPrice { get; set; }
        public DateTime DateOfMaintenance { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        //Navigation Properties
        public IEnumerable<PublicBidding> PublicBidding { get; set; }
        public IEnumerable<OpeningOfBids> OpeningOfBids { get; set; }
        public IEnumerable<BiddingConditions> BiddingConditions { get; set; }
    }
}
