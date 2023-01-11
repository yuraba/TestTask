using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Incident>().HasIndex(u => u.IncidentName).IsUnique();
        builder.Entity<Contact>().HasIndex(u => u.Email).IsUnique();
    }
   

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Incident> Incidents { get; set; }
}