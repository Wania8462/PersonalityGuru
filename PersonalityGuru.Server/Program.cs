using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Server;
using PersonalityGuru.Server.Gateways.Email;
using PersonalityGuru.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("PersonalityGuru.Server")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IEmailGateway, EmailGateway>();

builder.Services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
builder.Services.AddScoped<IUserTestSessionRepository, UserTestSessionRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .PartManager.ApplicationParts.Add(new AssemblyPart(typeof(PersonalityGuru.Server.Controllers.UserController).Assembly));

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy => {
            policy.AllowAnyHeader()
                  .AllowAnyMethod()
                  .WithOrigins("https://localhost:7165");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.MapControllers()
    .WithOpenApi();

app.Run();