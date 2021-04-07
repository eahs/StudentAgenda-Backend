using ADSBackend.Models;
using ADSBackend.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ADSBackend.Models.AdminViewModels;

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


        public DbSet<ADSBackend.Models.AboutUs> AboutUs { get; set; }


        public DbSet<ADSBackend.Models.UserNotes> UserNotes { get; set; }


        public DbSet<ADSBackend.Models.AdminViewModels.UserViewModel> UserViewModel { get; set; }

    }
}
