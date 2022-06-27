namespace CC2.Models;

using Microsoft.EntityFrameworkCore;
// using CC2.Models;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("UserDatabase"));
    }

    public DbSet<Users> Users { get; set; }
}