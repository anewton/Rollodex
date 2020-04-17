using Data.Models;
using Data.Models.Contacts;
using Data.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options)
            : base(options)
        {
        }

        public DbSet<SiteUser> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=Rollodex.sqlite");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SiteUser>(b =>
            {
                // Each User can have many Contacts
                b.HasMany(e => e.UserContacts)
                        .WithOne()
                        .HasForeignKey(uc => uc.Id)
                        .IsRequired();

                b.ToTable("Users");
            });

            builder.Entity<Contact>(b =>
            {
                b.ToTable("Contacts");
            });

            builder.Entity<UserContact>(b =>
            {
                b.ToTable("UserContacts");
            });
        }
    }
}
