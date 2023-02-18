namespace Registration_projekat.Models
{
    public class UserRole
    {
        public Guid User_RoleId { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }


    }
}
