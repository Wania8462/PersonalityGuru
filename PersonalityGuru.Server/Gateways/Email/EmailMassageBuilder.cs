namespace PersonalityGuru.Server.Gateways.Email
{
    public class EmailMassageBuilder {
        public async Task<string> BuildTestResultsMessage(string userName, Dictionary<string, double> results, string url) {
            var template = await File.ReadAllTextAsync("./Resources/TestResultEmail.html");
            var message = template
                .Replace("{{UserName}}", userName)
                .Replace("{{OResult}}", results["O"].ToString())
                .Replace("{{KResult}}", results["К"].ToString())
                .Replace("{{EResult}}", results["Э"].ToString())
                .Replace("{{AResult}}", results["А"].ToString())
                .Replace("{{HResult}}", results["Н"].ToString())
                .Replace("{{ResultsLink}}", url);

            return message;
        }
    }
}
