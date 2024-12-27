namespace PersonalityGuru.Server.Gateways.Email;

public record MailSettings
{
    public required string EmailId { get; init; }
    public required string Name { get; init; }
    public required string Password { get; init; }
    public required string Host { get; init; }
    public required int Port { get; init; }
    public required string CopyToEmail { get; init; }
}