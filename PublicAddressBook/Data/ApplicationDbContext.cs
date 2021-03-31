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
            modelBuilder.Entity<Contact>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<Contact>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<Contact>().Property(x => x.Address).IsRequired();
            modelBuilder.Entity<Contact>().HasIndex(p => new { p.FirstName, p.LastName, p.Address }).IsUnique();
        }
    }
}
