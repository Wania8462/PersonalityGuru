﻿using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Server.Data;

namespace PersonalityGuru.Server.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext appDbContext;
    public UsersRepository(ApplicationDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<List<ApplicationUser>> GetAllUsersAsync()
    {
        var users = await appDbContext.Users.ToListAsync();
        return users;
    }
}