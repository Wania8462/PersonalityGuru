using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Questionnaire> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Questionnaire>().HasData(
                new Questionnaire { Id = 1, Name = "OKЭАН" }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "q1", Group = "O", TestId = 1 },
                new Question { Id = 2, Text = "q2", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 3, Text = "q3", Group = "O", TestId = 1 }
            );
        }
    }

}
