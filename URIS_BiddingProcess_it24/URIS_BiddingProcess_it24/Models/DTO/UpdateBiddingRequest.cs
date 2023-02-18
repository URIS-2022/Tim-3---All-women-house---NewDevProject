namespace URIS_BiddingProcess_it24.Models.DTO
{
    public class UpdateBiddingRequest
    {
        /// <summary>
        /// The code that identifies the Bidding entity.
        /// \
        /// Values should be in format: 001,002, etc
        /// </summary>
        public string? BiddingCode { get; set; }
        /// <summary>
        /// The type of Bidding, such as public bidding.
        /// \
        /// Allowed values:
        /// \
        /// 1."Javna licitacija"
        /// \
        /// 2."Otvaranje zatvorenih ponuda"
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// The current status of the Bidding, such as first round.
        /// \
        /// Allowed values:
        /// \
        /// 1."Prvi krug"
        /// \
        /// 2."Drugi krug sa starim uslovima"
        /// \
        /// 3."Drugi krug sa novim uslovima"
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// Indicates whether the Bidding is excepted or not.
        /// </summary>
        public bool Excepted { get; set; }
        /// <summary>
        /// The starting price for the Bidding.
        /// </summary>
        public int StartingPrice { get; set; }
        /// <summary>
        /// The date when the Bidding will be maintained.
        /// </summary>
        public DateTime DateOfMaintenance { get; set; }
        /// <summary>
        /// The start time for the Bidding.
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// The end time for the Bidding.
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
