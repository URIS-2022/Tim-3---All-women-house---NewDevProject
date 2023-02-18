namespace Registration_projekat.Models.DTO
{
    /// <summary>
    /// Predstavlja prijavu
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// ID prijave
        /// </summary>
        public Guid RegistrationId { get; set; }

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

        /// <summary>
        /// Lista formulara prijave
        /// </summary>
        public RegistrationForm RegistrationForm { get; set; }
    }
}
