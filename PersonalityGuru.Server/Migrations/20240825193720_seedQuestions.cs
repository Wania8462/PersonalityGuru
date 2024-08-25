using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalityGuru.Server.Migrations
{
    /// <inheritdoc />
    public partial class seedQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Group", "Text" },
                values: new object[] { "O", "Мне нравится изучать и постигать что-либо, я с интересом учусь новому" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "O", false, "Я постоянно увлекаюсь новыми идеями" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Group", "Text" },
                values: new object[] { "O", "Некоторым людям мое мышление может показаться нестандартным и даже странным" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "O", true, "Меня больше интересуют конкретика, процессы и детали, нежели общие идеи и концепции" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "O", true, "Меня редко увлекают произведения искусства и музыки, арт объекты и др." });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Group", "Text" },
                values: new object[] { "O", "Увлекаясь, я забываю обо всем" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Group", "Text" },
                values: new object[] { "O", "Мне нравится мечтать, я наслаждаюсь \"дикими\" полетами фантазии" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "O", true, "Люди говорят обо мне как о заземленном и практичном человеке" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Group", "InvertedScore", "TestId", "Text" },
                values: new object[,]
                {
                    { 11, "O", false, 1, "Я всё время что-то придумываю или адаптирую под себя" },
                    { 12, "O", false, 1, "Мне тяжело найти себя, определить свое направление" },
                    { 13, "O", false, 1, "Я быстро адаптируюсь к новым обстоятельствам, задачам и изменениям" },
                    { 14, "O", true, 1, "Я не люблю тратить время на глубокие размышления и филосовствования" },
                    { 15, "O", true, 1, "Я всегда выбераю точные специализации и навыки" },
                    { 16, "К", false, 1, "Я ценю чистоту и порядок по всем" },
                    { 17, "К", true, 1, "Я редко читаю что-либо о самоорганизации и менеджменте времени" },
                    { 18, "К", false, 1, "Мне свойственны настойчивость, скрупулезность и качество в делах" },
                    { 19, "К", true, 1, "У меня достаточно свободного времени" },
                    { 20, "К", false, 1, "Я могу быть упертым и настаивать на своем, не люблю компромиссы" },
                    { 21, "К", true, 1, "Я не люблю ответственность и избегаю ее" },
                    { 22, "К", false, 1, "Многие считают меня высокомерным(ой) и отстраненным(ой)" },
                    { 23, "К", false, 1, "Мне легко приступать к действиям и задачам" },
                    { 24, "К", false, 1, "Я усидчивый, дисциплинированный и последовательный человек" },
                    { 25, "К", true, 1, "Мне несложно соврать, придумать \"на ходу\" или приукрасить некоторые вещи" },
                    { 26, "К", false, 1, "Я все делаю быстро" },
                    { 27, "К", false, 1, "Я добился(лась) в жизни многого своим трудом" },
                    { 28, "К", true, 1, "Предпочитаю \"двигаться в потоке\", редко планирую и решаю все по ходу" },
                    { 29, "К", false, 1, "Перед любым выбором я взвешиваю \"за\" и \"против\"	" },
                    { 30, "К", true, 1, "Мне не нравится иметь четкий план и расписание" },
                    { 31, "Э", false, 1, "Мне нравится чувствовать адреналин" },
                    { 32, "Э", false, 1, "Я довольно быстро и громко говорю" },
                    { 33, "Э", true, 1, "У меня спокойный и размеренный ритм мышления и жизни" },
                    { 34, "Э", true, 1, "Я переписываюсь лучше, чем общаюсь вживую" },
                    { 35, "Э", false, 1, "Среди людей я чувствую себя как рыба в воде" },
                    { 36, "Э", false, 1, "Мне нравится необычно одеваться и привлекать к себе внимание" },
                    { 37, "Э", false, 1, "Мне интересно проводить время с другими людьми" },
                    { 38, "Э", false, 1, "Я люблю большие компании и хорошие вечеринки" },
                    { 39, "Э", true, 1, "Я не люблю, когда жизнь течет быстро и каждый день что-то происходит" },
                    { 40, "Э", false, 1, "Я верю, что все возможно, и у меня все получится" },
                    { 41, "Э", true, 1, "Между встречей с людьми и уединением я чаще выберу уединение" },
                    { 42, "Э", true, 1, "Я не очень-то общительный и разговорчивый человек" },
                    { 43, "Э", false, 1, "Я постоянно в движении, мне сложно усидеть на месте" },
                    { 44, "Э", false, 1, "Я люблю, когда меня хвалят и отмечают мои достижения" },
                    { 45, "Э", true, 1, "Я люблю тишину, спокойствие и обособленность" },
                    { 46, "А", false, 1, "Я могу пожертвовать своими интересами и временем ради других" },
                    { 47, "А", false, 1, "Мне неспокойно, когда другие чувствуют себя плохо" },
                    { 48, "А", false, 1, "Мне легко понять мотивы и боли других людей" },
                    { 49, "А", true, 1, "Я часто бываю безжалостен(на), требователен(на) к другим" },
                    { 50, "А", true, 1, "Я не испытываю желания ни о ком заботиться или поддерживать" },
                    { 51, "А", false, 1, "Я отзывчивый, доброжелательный и терпеливый человек" },
                    { 52, "А", false, 1, "Мне тяжело спорить с теми, кто выше меня по статусу" },
                    { 53, "А", false, 1, "Я верю в то, что у большинства людей добрые намерения" },
                    { 54, "А", false, 1, "Я стараюсь предугадать потребности людей в моем окружении" },
                    { 55, "А", true, 1, "Я могу намеренно причинить эмоциональную боль другому человеку" },
                    { 56, "А", false, 1, "На работе я легко подчиняюсь руководителю и становлюсь его доверенным лицом" },
                    { 57, "А", true, 1, "Мне не особенно важно, что думают и чувствуют другие" },
                    { 58, "А", false, 1, "Я избегаю конфликтов и стараюсь найти общий язык с людьми, иногда действуя себе в ущерб" },
                    { 59, "А", false, 1, "Мне интереснее сотрудничать и взаимодействовать, чем конкурировать" },
                    { 60, "А", true, 1, "Мне легко выражать свое мнение, даже если с ним никто не согласен" },
                    { 61, "Н", false, 1, "Я часто прокручиваю в голове слова людей, которые меня задели" },
                    { 62, "Н", false, 1, "Я часто представляю худший сценарий" },
                    { 63, "Н", false, 1, "Меня раздражают уверенные в себе, громкие люди" },
                    { 64, "Н", true, 1, "У меня в жизни мало поводов для беспокойства" },
                    { 65, "Н", false, 1, "Я часто себя унижаю, думаю о себе плохо" },
                    { 66, "Н", false, 1, "Я часто о чем-то переживаю, чувствую тревогу и напряжение" },
                    { 67, "Н", false, 1, "После сильных негативных эмоций мне нужно время, чтобы прийти в себя. Я медленно отхожу" },
                    { 68, "Н", false, 1, "Меня легко зацепить, расстроить или обидеть" },
                    { 69, "Н", false, 1, "У меня часто меняется настроение" },
                    { 70, "Н", true, 1, "Большую часть времени я расслаблен(а)" },
                    { 71, "Н", false, 1, "Я легко впадаю в негатив, страдания и депрессию" },
                    { 72, "Н", false, 1, "Если я злюсь или расстроен(а), это всегда по мне видно" },
                    { 73, "Н", true, 1, "Я сохраняю спокойствие даже под давлением" },
                    { 74, "Н", false, 1, "Я склонен(на) описывать происходящее не в свою пользу" },
                    { 75, "Н", false, 1, "Я часто подозреваю скрытые мотивы у других" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Group", "Text" },
                values: new object[] { "К", "Я ценю чистоту и порядок по всем" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "К", true, "Я редко читаю что-либо о самоорганизации и менеджменте времени" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Group", "Text" },
                values: new object[] { "Е", "Мне нравится чувствовать адреналин" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "Е", false, "Я довольно быстро и громко говорю" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "А", false, "Я могу пожертвовать своими интересами и временем ради других" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Group", "Text" },
                values: new object[] { "А", "Мне неспокойно, когда другие чувствуют себя плохо" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Group", "Text" },
                values: new object[] { "Н", "Я часто прокручиваю в голове слова людей, которые меня задели" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Group", "InvertedScore", "Text" },
                values: new object[] { "Н", false, "Я часто представляю худший сценарий" });
        }
    }
}
