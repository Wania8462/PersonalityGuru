using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PersonalityGuru.Shared.Models
{
    public class User
    {
        [JsonInclude]
        public string Id { get; set; }
        [JsonInclude]
        public string FullName { get; set; }
        [JsonInclude]
        public string Email { get; set; }
        [JsonInclude]
        public SavedUserAnswers SavedUserAnswers { get; set; }

        public User(string Id, string FullName, string Email, SavedUserAnswers SavedUserAnswers) 
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Email = Email;
            this.SavedUserAnswers = SavedUserAnswers;
        }
    }
}