using System.ComponentModel.DataAnnotations.Schema;

namespace Registration_projekat.Models
{
    public class User
    {
        /// <summary>
        /// ID korisnika
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Email korisnika
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// UserName korisnika
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Lozinka korisnika
        /// </summary>
        public string? Password { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }

       /// <summary>
       /// Navigation property
       /// </summary>
        public List<UserRole> UserRoles { get; set; }
    }
}
