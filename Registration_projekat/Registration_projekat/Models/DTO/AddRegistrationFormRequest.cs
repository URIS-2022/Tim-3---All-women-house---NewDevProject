namespace Registration_projekat.Models.DTO
{
    /// <summary>
    /// Zahtev za dodavanje formulara prijave
    /// </summary>
    public class AddRegistrationFormRequest
    {
        /// <summary>
        /// Naziv lica(kupca)
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Prezime lica(kupca)
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Adresa lica(kupca)
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// JMBG lica(kupca)
        /// </summary>
        public string? JMBG { get; set; }

        /// <summary>
        /// Email lica(kupca)
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Username lica(kupca)
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Lozinka lica(kupca)
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Zemlja u kojoj zivi lice(kupac)
        /// </summary>
        public string Country { get; set; }
    }
}
