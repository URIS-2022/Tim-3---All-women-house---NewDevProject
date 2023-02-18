using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT64_2019_URIS_CustomerRegistration.Entities
{
    public class NaturalPerson
    {
        public Guid NaturalPersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [MaxLength(13)]
        public string? JMBG { get; set; }
        public string? StreetNP { get; set; }
        public string? CityNP { get; set; }
        public string? StateNP { get; set; }
        public string? ZipNP { get; set; }
        public string? Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public string? EmailNP { get; set; }
        public int AccountNumNP { get; set; }

        //[ForeignKey("Customers")]
        public Guid CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}
