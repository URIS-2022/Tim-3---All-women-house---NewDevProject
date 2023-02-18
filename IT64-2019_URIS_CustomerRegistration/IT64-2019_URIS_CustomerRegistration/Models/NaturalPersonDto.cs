using IT64_2019_URIS_CustomerRegistration.Entities;
using System.ComponentModel.DataAnnotations;

namespace IT64_2019_URIS_CustomerRegistration.Models
{
    public class NaturalPersonDto
    {
        /// <summary>
        /// ID fizickog lica
        /// </summary>
        public Guid NaturalPersonId { get; set; }
        /// <summary>
        /// Ime fizickog lica
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Prezime fizickog lica
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Jedinstveni maticni broj fizickog lica
        /// </summary>
        [MaxLength(13)]
        public string? JMBG { get; set; }
        /// <summary>
        /// Ulica i broj
        /// </summary>
        public string? StreetNP { get; set; }
        /// <summary>
        /// Grad
        /// </summary>
        public string? CityNP { get; set; }
        /// <summary>
        /// Drzava
        /// </summary>
        public string? StateNP { get; set; }
        /// <summary>
        /// Postanski broj
        /// </summary>
        public string? ZipNP { get; set; }
        /// <summary>
        /// Broj telefona 1
        /// </summary>
        public string? Tel1 { get; set; }
        /// <summary>
        /// Broj telefona 2
        /// </summary>
        public string? Tel2 { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? EmailNP { get; set; }
        /// <summary>
        /// Broj racuna fizickog lica
        /// </summary>
        public int AccountNumNP { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}
