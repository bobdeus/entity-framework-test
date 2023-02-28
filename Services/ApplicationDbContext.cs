using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var databaseCredentials = GetDatabaseCredentials();
        optionsBuilder.UseSqlServer(
            $"Server=localhost;Database={databaseCredentials.Database};User Id={databaseCredentials.Username};Password={databaseCredentials.Password};TrustServerCertificate=true");
    }

    private DatabaseCredentials GetDatabaseCredentials()
    {
        var database = Environment.GetEnvironmentVariable("DB_DATABASE") ??
                       throw new InvalidOperationException("No Database environment variable was found.");
        var username = Environment.GetEnvironmentVariable("DB_USERNAME") ??
                       throw new InvalidOperationException("No Username environment variable was found.");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ??
                       throw new InvalidOperationException("No Password environment variable was found.");
        return new DatabaseCredentials(database, username, password);
    }
}

internal class DatabaseCredentials
{
    public DatabaseCredentials(string database, string username, string password)
    {
        Database = database;
        Username = username;
        Password = password;
    }

    public string Database { get; }
    public string Username { get; }
    public string Password { get; }
}