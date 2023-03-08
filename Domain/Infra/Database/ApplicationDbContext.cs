namespace LojaMVC.Domain.Infra.Database;

using Flunt.Notifications;
using LojaMVC.Domain.Product;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //PRODUCT
        builder.Ignore<Notification>();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500).IsRequired(false);
        builder.Entity<Product>().Property(p => p.Name).HasMaxLength(120).IsRequired();

        //CATEGORY
        builder.Entity<Category>().Property(p => p.EditedBy).IsRequired(false);

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .HaveMaxLength(120);
    }

}