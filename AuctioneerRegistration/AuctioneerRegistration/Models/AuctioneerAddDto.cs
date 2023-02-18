using System.ComponentModel.DataAnnotations;

namespace AuctioneerRegistration.Models
{
    public class AuctioneerAddDto
    {
        /// <summary>
        /// Ime licitera
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Prezime licitera
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Jedinstveni maticni broj licitera
        /// (sadrzi 13 cifara)
        /// </summary>
        [MaxLength(13)]
        public string JMBG { get; set; }

        /// <summary>
        /// Ulica i broj 
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Grad
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Drzava
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Broj pasosa
        /// </summary>
        public string PassportNum { get; set; }

    }
}
