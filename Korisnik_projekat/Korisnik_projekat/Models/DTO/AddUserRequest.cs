namespace Korisnik_projekat.Models.DTO
{
    /// <summary>
    /// Zahtev za dodavanje korisnika
    /// </summary>
    public class AddUserRequest
    {
        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string ?Name { get; set; }

        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string ?Surname { get; set; }

        /// <summary>
        /// Email korisnika
        /// </summary>
        public string ?Email { get; set; }

        /// <summary>
        /// UserName korisnika
        /// </summary>
        public string ?UserName { get; set; }

        /// <summary>
        /// Lozinka korisnika
        /// </summary>
        public string ?Password { get; set; }
    }
}
