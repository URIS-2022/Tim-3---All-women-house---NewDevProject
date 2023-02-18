using IT64_2019_URIS_CustomerRegistration.Entities;
using System.ComponentModel.DataAnnotations;

namespace IT64_2019_URIS_CustomerRegistration.Models
{
    public class LegalPersonAddDto
    {
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string? NameLP { get; set; }

        /// <summary>
        /// Maticni broj pravnog lica (sadrzi 8 cifara)
        /// </summary>

        [MaxLength(8)]
        public string? IdentificationNumLP { get; set; }
        
        /// <summary>
        /// Ulica i broj
        /// </summary>
        public string? StreetLP { get; set; }

        /// <summary>
        /// Grad
        /// </summary>
        public string? CityLP { get; set; }
        /// <summary>
        /// Drzava
        /// </summary>
        public string? StateLP { get; set; }

        /// <summary>
        /// Kontakt osoba
        /// </summary>
        public string? ContactPerson { get; set; }

        /// <summary>
        /// Pozicija pravnog lica
        /// </summary>
        public string? Positions { get; set; }
        /// <summary>
        /// Broj telefona
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? EmailLP { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        public string? Fax { get; set; }

        /// <summary>
        /// Broj racuna
        /// </summary>
        public int AccountNumLP { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid CustomerId { get; set; }
      
    }
}
