using ADSBackend.Models;
using ADSBackend.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ADSBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ConfigurationItem> ConfigurationItem { get; set; }
        public DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        
        public DbSet<ADSBackend.Models.AddEvent1> AddEvent { get; set; }

        public DbSet<ADSBackend.Models.AddAssignment> AddAssignment { get; set; }

        public DbSet<ADSBackend.Models.AddAssignment2> AddAssignment2 { get; set; }
    }
}
