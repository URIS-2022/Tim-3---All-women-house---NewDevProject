using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT64_2019_URIS_CustomerRegistration.Entities
{
    public class LegalPerson
    {
        public Guid LegalPersonId { get; set; }
        public string? NameLP { get; set; }

        [MaxLength(8)]
        public string? IdentificationNumLP { get; set; }
        public string? StreetLP { get; set; }
        public string? CityLP { get; set; }
        public string? StateLP { get; set; }
        public string? ContactPerson { get; set; }
        public string? Positions { get; set; }
        public string? Phone { get; set; }
        public string? EmailLP { get; set; }
        public string? Fax { get; set; }
        public int AccountNumLP { get; set; }

        //[ForeignKey("Customers")]
        public Guid CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}
