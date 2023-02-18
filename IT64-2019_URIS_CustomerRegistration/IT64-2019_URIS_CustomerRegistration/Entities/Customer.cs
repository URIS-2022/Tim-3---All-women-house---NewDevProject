namespace IT64_2019_URIS_CustomerRegistration.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string? Person { get; set; }
        public int RealizedArea { get; set; }
        public string? AuthorizedPerson { get; set; }
        public double Payments { get; set; }
        public int Priority { get; set; }
        public string? Guarantor { get; set; }
        public Guid RegistrationFormId { get; set; }


        public IEnumerable<NaturalPerson> NaturalPersons { get; set; }
        public IEnumerable<LegalPerson> LegalPersons { get; set; }
    }
}
