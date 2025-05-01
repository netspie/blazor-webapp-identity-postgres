using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyAppName.WebApp.Data;

public class ApplicationDbContext(
                DbContextOptions<ApplicationDbContext> options,
                IConfiguration _configuration) : DbContext(options), IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext() : this(new DbContextOptions<ApplicationDbContext>(), null!) { }

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention();

        return new ApplicationDbContext(optionsBuilder.Options, configuration);
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<IdentityRole>().ToTable("roles").HasKey(x => new { x.Id });
        builder.Entity<IdentityUser>().ToTable("users").HasKey(x => x.Id);
        builder.Entity<IdentityUserRole<string>>().ToTable("user_roles").HasKey(x => new { x.UserId, x.RoleId });
        builder.Entity<IdentityUserClaim<string>>().ToTable("user_claims").HasKey(x => x.Id);
        builder.Entity<IdentityUserLogin<string>>().ToTable("user_logins").HasKey(x => new { x.LoginProvider, x.ProviderKey });
        builder.Entity<IdentityRoleClaim<string>>().ToTable("role_claims").HasKey(x => x.Id);
        builder.Entity<IdentityUserToken<string>>().ToTable("user_tokens").HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
    public DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }
}