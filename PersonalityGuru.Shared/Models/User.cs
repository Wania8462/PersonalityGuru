using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalityGuru.Shared.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public SavedUserAnswers SavedUserAnswers { get; set; }

        public User(string id, string fullName, string email, SavedUserAnswers savedUserAnswer) 
        {
            Id = id;
            FullName = fullName;
            Email = email;
            SavedUserAnswers = savedUserAnswer;
        }
    }
}