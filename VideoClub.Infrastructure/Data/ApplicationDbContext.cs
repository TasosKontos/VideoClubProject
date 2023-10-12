using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoClub.Core.Entities;

namespace VideoClub.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCopy> MovieCopies { get; set; }
        public DbSet<MovieRent> MovieRents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "auth");
            builder.Entity<IdentityRole>().ToTable("Roles", "auth");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "auth");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "auth");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "auth");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "auth");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "auth");

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "User", NormalizedName = "USER" },
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
                );
        }

    }
}