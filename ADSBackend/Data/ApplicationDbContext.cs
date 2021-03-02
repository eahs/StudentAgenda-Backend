using ADSBackend.Models;
using ADSBackend.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//distinguish from main
namespace ADSBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ConfigurationItem> ConfigurationItem { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<ADSBackend.Models.PersonalEvent> PersonalEvent { get; set; }
        public DbSet<ADSBackend.Models.Assignment> Assignment { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MemberAssignment>()
                         .HasKey(t => new { t.MemberId, t.AssignmentId });

            builder.Entity<MemberAssignment>()
                .HasOne(ma => ma.Member)
                .WithMany(ma => ma.Assignments)
                .HasForeignKey(m => m.MemberId);

        }

    }
}
