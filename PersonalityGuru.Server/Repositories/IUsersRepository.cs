using PersonalityGuru.Server.Data;

namespace PersonalityGuru.Server.Repositories;

public interface IUsersRepository
{
    Task<List<ApplicationUser>> GetAllUsersAsync();
    Task<ApplicationUser?> GetUserByIdAsync(string userId);
}
