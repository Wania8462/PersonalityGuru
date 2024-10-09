using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PersonalityGuru.Shared.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<SavedUserAnswers> SavedUserAnswers { get; set; }

        public User(string Id, string FullName, string Email, List<SavedUserAnswers> SavedUserAnswers) 
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Email = Email;
            this.SavedUserAnswers = SavedUserAnswers;
        }
    }
}