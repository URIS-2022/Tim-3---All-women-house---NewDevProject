namespace IT64_2019_URIS_ExpertCommission.Entities
{
    public class ExpertCommission
    {
        public Guid ExpertCommissionId { get; set; }
        public string ExpertCommissionName { get; set; }
        public string PresidentName { get; set; }
        public int NumberOfMembers { get; set; }

        public IEnumerable<Member> Members { get; set; }
    }
}
