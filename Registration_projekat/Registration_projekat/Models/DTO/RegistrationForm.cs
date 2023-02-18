namespace Registration_projekat.Models.DTO
{
    /// <summary>
    /// Predstavlja formular prijave
    /// </summary>
    public class RegistrationForm
    {
        /// <summary>
        /// ID formulara prijave
        /// </summary>
        public Guid RegistrationFormId { get; set; }

        /// <summary>
        /// Ime lica(kupca) koji popunjava formular
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Prezime lica(kupca) koji popunjava formular
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Adresa lica(kupca) koji popunjava formular
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// JMBG lica(kupca) koji popunjava formular
        /// </summary>
        public string? JMBG { get; set; }

        /// <summary>
        /// Email lica(kupca) koji popunjava projekat
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Username lica(kupca) koji popunjava projekat
        /// </summary>
        public string? Username { get; set; }
        
        /// <summary>
        /// Lozinka lica(kupca) koji popunjava projekat
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Drzava u kojoj zivi lice(kupac) 
        /// </summary>
        public string? Country { get; set; }
    }
}
