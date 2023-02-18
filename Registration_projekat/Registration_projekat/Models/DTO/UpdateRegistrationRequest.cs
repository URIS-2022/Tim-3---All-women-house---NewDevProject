namespace Registration_projekat.Models.DTO
{
    /// <summary>
    /// Zahtev za modifikaciju prijave
    /// </summary>
    public class UpdateRegistrationRequest
    {
        /// <summary>
        /// Datum i vreme prijave
        /// </summary>
        public DateTime DateOfRegistration { get; set; }

        /// <summary>
        /// Lokacija prijave
        /// </summary>
        public string? Location { get; set; }


        /// <summary>
        /// Strani kljuc, odnosno primarni kljuc u RegistrationForm
        /// </summary>
        public Guid RegistrationFormId { get; set; }
    }
}
