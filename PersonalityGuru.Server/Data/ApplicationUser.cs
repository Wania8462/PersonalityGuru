using Microsoft.AspNetCore.Identity;

namespace PersonalityGuru.Server.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? FullName { get; set; }
    }

}
