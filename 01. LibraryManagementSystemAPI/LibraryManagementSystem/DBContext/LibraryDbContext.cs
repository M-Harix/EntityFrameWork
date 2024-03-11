using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryManagementSystem.DBContext
{
    // Define your DbContext
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Book_Copies> Book_Copies { get; set; }
        public virtual DbSet<Checkouts> Checkouts { get; set; }
        public virtual DbSet<Fine> Fine { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Copies>()
            .HasOne(e => e.Checkouts)
            .WithOne(e => e.Book_Copies)
            .HasForeignKey<Checkouts>(e => e.CopyId)
            .IsRequired();

            modelBuilder.Entity<Checkouts>()
            .HasOne(e => e.Fine)
            .WithOne(e => e.Checkouts)
            .HasForeignKey<Fine>(e => e.CheckoutsId)
            .IsRequired();
        }
    }
}
