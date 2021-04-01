using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublicAddressBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicAddressBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<PhoneNumber> PhoneNumbers{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasMany(x => x.PhoneNumbers).WithOne(y => y.Contact).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Contact>().Property(x => x.Address).IsRequired();
            modelBuilder.Entity<Contact>().HasIndex(p => new { p.Name, p.Address }).IsUnique();

        }
    }
}
