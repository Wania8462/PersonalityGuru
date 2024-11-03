using System.Text.Json;
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

        public DbSet<UserTestSession> UserTestSessions { get; set; }

        public DbSet<UserTestAnswer> UserTestAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Questionnaire>().HasData(
                new Questionnaire { Id = 1, Name = "OKЭАН" },
                new Questionnaire { Id = 2, Name = "TestQuestionnaire" }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "Я вижу красоту и смыслы там, где другие их не видят", Group = "O", TestId = 1 },
                new Question { Id = 2, Text = "Если человек мне не нравится, я не восприму его аргументы впринципе", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 3, Text = "Мне нравится изучать и постигать что-либо, я с интересом учусь новому", Group = "O", TestId = 1 },
                new Question { Id = 4, Text = "Я постоянно увлекаюсь новыми идеями", Group = "O", TestId = 1 },
                new Question { Id = 5, Text = "Некоторым людям мое мышление может показаться нестандартным и даже странным", Group = "O", TestId = 1 },
                new Question { Id = 6, Text = "Меня больше интересуют конкретика, процессы и детали, нежели общие идеи и концепции", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 7, Text = "Меня редко увлекают произведения искусства и музыки, арт объекты и др.", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 8, Text = "Увлекаясь, я забываю обо всем", Group = "O", TestId = 1 },
                new Question { Id = 9, Text = "Мне нравится мечтать, я наслаждаюсь \"дикими\" полетами фантазии", Group = "O", TestId = 1 },
                new Question { Id = 10, Text = "Люди говорят обо мне как о заземленном и практичном человеке", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 11, Text = "Я всё время что-то придумываю или адаптирую под себя", Group = "O", TestId = 1 },
                new Question { Id = 12, Text = "Мне тяжело найти себя, определить свое направление", Group = "O", TestId = 1 },
                new Question { Id = 13, Text = "Я быстро адаптируюсь к новым обстоятельствам, задачам и изменениям", Group = "O", TestId = 1 },
                new Question { Id = 14, Text = "Я не люблю тратить время на глубокие размышления и филосовствования", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 15, Text = "Я всегда выбираю точные специализации и навыки", Group = "O", InvertedScore = true, TestId = 1 },
                new Question { Id = 16, Text = "Я ценю чистоту и порядок по всем", Group = "К", TestId = 1 },
                new Question { Id = 17, Text = "Я редко читаю что-либо о самоорганизации и менеджменте времени", Group = "К", InvertedScore = true, TestId = 1 },
                new Question { Id = 18, Text = "Мне свойственны настойчивость, скрупулезность и качество в делах", Group = "К", TestId = 1 },
                new Question { Id = 19, Text = "У меня достаточно свободного времени", Group = "К", InvertedScore = true, TestId = 1 },
                new Question { Id = 20, Text = "Я могу быть упертым и настаивать на своем, не люблю компромиссы", Group = "К", TestId = 1 },
                new Question { Id = 21, Text = "Я не люблю ответственность и избегаю ее", Group = "К", InvertedScore = true, TestId = 1 },
                new Question { Id = 22, Text = "Многие считают меня высокомерным(ой) и отстраненным(ой)", Group = "К", TestId = 1 },
                new Question { Id = 23, Text = "Мне легко приступать к действиям и задачам", Group = "К", TestId = 1 },
                new Question { Id = 24, Text = "Я усидчивый, дисциплинированный и последовательный человек", Group = "К", TestId = 1 },
                new Question { Id = 25, Text = "Мне несложно соврать, придумать \"на ходу\" или приукрасить некоторые вещи", Group = "К", InvertedScore = true, TestId = 1 },
                new Question { Id = 26, Text = "Я все делаю быстро", Group = "К", TestId = 1 },
                new Question { Id = 27, Text = "Я добился(лась) в жизни многого своим трудом", Group = "К", TestId = 1 },
                new Question { Id = 28, Text = "Предпочитаю \"двигаться в потоке\", редко планирую и решаю все по ходу", Group = "К", InvertedScore = true, TestId = 1 },
                new Question { Id = 29, Text = "Перед любым выбором я взвешиваю \"за\" и \"против\"	", Group = "К", TestId = 1 },
                new Question { Id = 30, Text = "Мне не нравится иметь четкий план и расписание", Group = "К", InvertedScore = true, TestId = 1 },
                new Question { Id = 31, Text = "Мне нравится чувствовать адреналин", Group = "Э", TestId = 1 },
                new Question { Id = 32, Text = "Я довольно быстро и громко говорю", Group = "Э", TestId = 1 },
                new Question { Id = 33, Text = "У меня спокойный и размеренный ритм мышления и жизни", Group = "Э", InvertedScore = true, TestId = 1 },
                new Question { Id = 34, Text = "Я переписываюсь лучше, чем общаюсь вживую", Group = "Э", InvertedScore = true, TestId = 1 },
                new Question { Id = 35, Text = "Среди людей я чувствую себя как рыба в воде", Group = "Э", TestId = 1 },
                new Question { Id = 36, Text = "Мне нравится необычно одеваться и привлекать к себе внимание", Group = "Э", TestId = 1 },
                new Question { Id = 37, Text = "Мне интересно проводить время с другими людьми", Group = "Э", TestId = 1 },
                new Question { Id = 38, Text = "Я люблю большие компании и хорошие вечеринки", Group = "Э", TestId = 1 },
                new Question { Id = 39, Text = "Я не люблю, когда жизнь течет быстро и каждый день что-то происходит", Group = "Э", InvertedScore = true, TestId = 1 },
                new Question { Id = 40, Text = "Я верю, что все возможно, и у меня все получится", Group = "Э", TestId = 1 },
                new Question { Id = 41, Text = "Между встречей с людьми и уединением я чаще выберу уединение", Group = "Э", InvertedScore = true, TestId = 1 },
                new Question { Id = 42, Text = "Я не очень-то общительный и разговорчивый человек", Group = "Э", InvertedScore = true, TestId = 1 },
                new Question { Id = 43, Text = "Я постоянно в движении, мне сложно усидеть на месте", Group = "Э", TestId = 1 },
                new Question { Id = 44, Text = "Я люблю, когда меня хвалят и отмечают мои достижения", Group = "Э", TestId = 1 },
                new Question { Id = 45, Text = "Я люблю тишину, спокойствие и обособленность", Group = "Э", InvertedScore = true, TestId = 1 },
                new Question { Id = 46, Text = "Я могу пожертвовать своими интересами и временем ради других", Group = "А", TestId = 1 },
                new Question { Id = 47, Text = "Мне неспокойно, когда другие чувствуют себя плохо", Group = "А", TestId = 1 },
                new Question { Id = 48, Text = "Мне легко понять мотивы и боли других людей", Group = "А", TestId = 1 },
                new Question { Id = 49, Text = "Я часто бываю безжалостен(на), требователен(на) к другим", Group = "А", InvertedScore = true, TestId = 1 },
                new Question { Id = 50, Text = "Я не испытываю желания ни о ком заботиться или поддерживать", Group = "А", InvertedScore = true, TestId = 1 },
                new Question { Id = 51, Text = "Я отзывчивый, доброжелательный и терпеливый человек", Group = "А", TestId = 1 },
                new Question { Id = 52, Text = "Мне тяжело спорить с теми, кто выше меня по статусу", Group = "А", TestId = 1 },
                new Question { Id = 53, Text = "Я верю в то, что у большинства людей добрые намерения", Group = "А", TestId = 1 },
                new Question { Id = 54, Text = "Я стараюсь предугадать потребности людей в моем окружении", Group = "А", TestId = 1 },
                new Question { Id = 55, Text = "Я могу намеренно причинить эмоциональную боль другому человеку", Group = "А", InvertedScore = true, TestId = 1 },
                new Question { Id = 56, Text = "На работе я легко подчиняюсь руководителю и становлюсь его доверенным лицом", Group = "А", TestId = 1 },
                new Question { Id = 57, Text = "Мне не особенно важно, что думают и чувствуют другие", Group = "А", InvertedScore = true, TestId = 1 },
                new Question { Id = 58, Text = "Я избегаю конфликтов и стараюсь найти общий язык с людьми, иногда действуя себе в ущерб", Group = "А", TestId = 1 },
                new Question { Id = 59, Text = "Мне интереснее сотрудничать и взаимодействовать, чем конкурировать", Group = "А", TestId = 1 },
                new Question { Id = 60, Text = "Мне легко выражать свое мнение, даже если с ним никто не согласен", Group = "А", InvertedScore = true, TestId = 1 },
                new Question { Id = 61, Text = "Я часто прокручиваю в голове слова людей, которые меня задели", Group = "Н", TestId = 1 },
                new Question { Id = 62, Text = "Я часто представляю худший сценарий", Group = "Н", TestId = 1 },
                new Question { Id = 63, Text = "Меня раздражают уверенные в себе, громкие люди", Group = "Н", TestId = 1 },
                new Question { Id = 64, Text = "У меня в жизни мало поводов для беспокойства", Group = "Н", InvertedScore = true, TestId = 1 },
                new Question { Id = 65, Text = "Я часто себя унижаю, думаю о себе плохо", Group = "Н", TestId = 1 },
                new Question { Id = 66, Text = "Я часто о чем-то переживаю, чувствую тревогу и напряжение", Group = "Н", TestId = 1 },
                new Question { Id = 67, Text = "После сильных негативных эмоций мне нужно время, чтобы прийти в себя. Я медленно отхожу", Group = "Н", TestId = 1 },
                new Question { Id = 68, Text = "Меня легко зацепить, расстроить или обидеть", Group = "Н", TestId = 1 },
                new Question { Id = 69, Text = "У меня часто меняется настроение", Group = "Н", TestId = 1 },
                new Question { Id = 70, Text = "Большую часть времени я расслаблен(а)", Group = "Н", InvertedScore = true, TestId = 1 },
                new Question { Id = 71, Text = "Я легко впадаю в негатив, страдания и депрессию", Group = "Н", TestId = 1 },
                new Question { Id = 72, Text = "Если я злюсь или расстроен(а), это всегда по мне видно", Group = "Н", TestId = 1 },
                new Question { Id = 73, Text = "Я сохраняю спокойствие даже под давлением", Group = "Н", InvertedScore = true, TestId = 1 },
                new Question { Id = 74, Text = "Я склонен(на) описывать происходящее не в свою пользу", Group = "Н", TestId = 1 },
                new Question { Id = 75, Text = "Я часто подозреваю скрытые мотивы у других", Group = "Н", TestId = 1 },

                new Question { Id = 101, Text = "Первый вопрос", Group = "O", TestId = 2 },
                new Question { Id = 102, Text = "Второй вопрос", Group = "К", TestId = 2 },
                new Question { Id = 103, Text = "Третий вопрос", Group = "Э", TestId = 2 },
                new Question { Id = 104, Text = "Четвертый вопрос", Group = "А", TestId = 2 },
                new Question { Id = 105, Text = "Пятый вопрос", Group = "Н", TestId = 2 }
            );
        }
    }

}
