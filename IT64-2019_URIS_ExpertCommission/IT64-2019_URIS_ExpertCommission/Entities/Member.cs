namespace IT64_2019_URIS_ExpertCommission.Entities
{
    public class Member
    {
        public Guid MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid ExpertCommissionId { get; set; }
        public ExpertCommission ExpertCommission { get; set; }
    }
}
