using System.Text.Json.Serialization;

namespace PersonalityGuru.Shared.Models
{
    public enum Role
    {
        User,
        Admin
    }

    public class User
    {
        [JsonInclude]
        public string Id { get; set; }
        [JsonInclude]
        public string FullName { get; set; }
        [JsonInclude]
        public string Email { get; set; }
        [JsonInclude]
        public List<SavedUserAnswers> SavedUserAnswers { get; set; }
        [JsonInclude]
        private Role Role;

        public User(string Id, string FullName, string Email, List<SavedUserAnswers> SavedUserAnswers, Role Role) 
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Email = Email;
            this.SavedUserAnswers = SavedUserAnswers;
            this.Role = Role;
        }
    }
}