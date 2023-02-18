namespace Registration_projekat.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }

        public string Name { get; set; }

        public List<User_Role> UserRoles { get; set; }

    }
}
