using System.ComponentModel.DataAnnotations;

namespace AuctioneerRegistration.Entities
{
    public class Auctioneer
    {
        public Guid AuctioneerId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }

        [MaxLength(13)]
        public string JMBG { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PassportNum { get; set; }
    }
}
