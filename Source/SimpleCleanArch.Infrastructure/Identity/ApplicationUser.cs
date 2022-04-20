
using Microsoft.AspNetCore.Identity;

namespace SimpleCleanArch.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
        public ApplicationRole(string id, string roleName, string displayName) : base(roleName)
        {
            Id = id;
            DisplayName = displayName;
            Name = roleName;
        }
        public string? DisplayName { get; set; }
    }
}
