namespace IT64_2019_URIS_CustomerRegistration.Models
{
    public class CustomerDto
    {
        /// <summary>
        /// ID kupca (lica)
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Lice
        /// </summary>
        public string? Person { get; set; }

        /// <summary>
        /// Ostvarena povrsina koju je kupac zakupio.
        /// </summary>
        public int RealizedArea { get; set; }

        /// <summary>
        /// Ovlasceno lice
        /// </summary>
        public string? AuthorizedPerson { get; set; }

        /// <summary>
        /// Uplata
        /// </summary>
        public double Payments { get; set; }

        /// <summary>
        /// Prioritet
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Garant placanja
        /// </summary>
        public string? Guarantor { get; set; }
        public Guid RegistrationFormId { get; set; }

        public RegistrationFormDto RegistrationForm { get; set; }
    }
}
