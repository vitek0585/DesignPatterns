using Microsoft.EntityFrameworkCore;
using Specification.After.Models;

namespace Specification.After
{

    //    Query filters
    //    Find all users with active phones
    //    Find all users by login prefix
    //    Find all users by phone number
    public sealed class Context : DbContext
    {
        public User Users { get; set; }

        public Context(DbContextOptions builderOptions)
            : base(builderOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(o => o.Contacts).WithOne();
            modelBuilder.Entity<Contact>()
                .HasDiscriminator<int>("ContactType")
                .HasValue<Phone>(1)
                .HasValue<Email>(2);
        }
    }
}