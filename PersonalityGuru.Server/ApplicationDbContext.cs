using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Server.Data;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Questionnaire> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SavedUserAnswers> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Questionnaire>().HasData(
                new Questionnaire { Id = 1, Name = "OKЭАН" }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "Я вижу красоту и смыслы там, где другие их не видят", Group = "O", TestId = 1 },
                new Question { Id = 2, Text = "Если человек мне не нравится, я не восприму его аргументы впринципе", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 3, Text = "Я ценю чистоту и порядок по всем", Group = "К", TestId = 1 },
                new Question { Id = 4, Text = "Я редко читаю что-либо о самоорганизации и менеджменте времени", Group = "К", InvertedScore = true, TestId = 1 },
                new Question { Id = 5, Text = "Мне нравится чувствовать адреналин", Group = "Е", TestId = 1 },
                new Question { Id = 6, Text = "Я довольно быстро и громко говорю", Group = "Е", TestId = 1 },
                new Question { Id = 7, Text = "Я могу пожертвовать своими интересами и временем ради других", Group = "А", TestId = 1 },
                new Question { Id = 8, Text = "Мне неспокойно, когда другие чувствуют себя плохо", Group = "А", TestId = 1 },
                new Question { Id = 9, Text = "Я часто прокручиваю в голове слова людей, которые меня задели", Group = "Н", TestId = 1 },
                new Question { Id = 10, Text = "Я часто представляю худший сценарий", Group = "Н", TestId = 1 }
            );

            var options = new JsonSerializerOptions(JsonSerializerDefaults.General);
            modelBuilder.Entity<SavedUserAnswers>()
                .Property(b => b.Answers)
                .HasConversion(
                    a => JsonSerializer.Serialize(a.OrderBy(k => k.Key).ToArray(), options),
                    a => JsonSerializer.Deserialize<KeyValuePair<int, AnswerOption>[]>(a, options)!.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        }
    }

}
