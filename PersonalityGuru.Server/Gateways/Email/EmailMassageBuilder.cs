namespace PersonalityGuru.Server.Gateways.Email
{
    public class EmailMassageBuilder {
        public async Task<string> BuildTestResultsMessage(string name, Dictionary<string, double> result) {
            var template = await File.ReadAllTextAsync("./Resources/TestResultEmail.html");
            var message = template
                .Replace("{{UserName}}", name)
                .Replace("{{OResult}}", result["O"].ToString())
                .Replace("{{KResult}}", result["К"].ToString())
                .Replace("{{EResult}}", result["Э"].ToString())
                .Replace("{{AResult}}", result["А"].ToString())
                .Replace("{{HResult}}", result["Н"].ToString())
                .Replace("{{ResultsLink}}", result["O"].ToString());

            return message;
        }
    }
}
