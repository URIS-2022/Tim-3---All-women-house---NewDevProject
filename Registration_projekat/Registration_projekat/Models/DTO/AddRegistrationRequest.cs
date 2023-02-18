namespace Registration_projekat.Models.DTO
{
    /// <summary>
    /// Zahtev za dodavanje prijave
    /// </summary>
    public class AddRegistrationRequest
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
        /// Strani kljuc, odnosno primarni kljuc u formularu prijave
        /// </summary>
        public Guid RegistrationFormId { get; set; }
    }
}
