using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Laba3new.Models
{
    public class SageBookDbContext : DbContext
    {
        public SageBookDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Sage> Sages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Sage
            modelBuilder
                .Entity<Sage>()
                .HasKey<int>(x => x.IdSage);

            modelBuilder
                .Entity<Sage>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            modelBuilder
                .Entity<Sage>()
                .Property(x => x.Age)
                .IsRequired();

            modelBuilder
                .Entity<Sage>()
                .Property(x => x.City)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(true);

            modelBuilder
                .Entity<Sage>()
                .Property(x => x.Photo)
                .HasColumnType("VARBINARY(MAX)");

            modelBuilder
                .Entity<Sage>()
                .HasMany(x => x.Books)
                .WithMany(x => x.Sages)
                .Map(m =>
                {
                    m.ToTable("SageBook");
                    m.MapLeftKey("IdSage");
                    m.MapRightKey("IdBook");
                });

            // Book
            modelBuilder
                .Entity<Book>()
                .HasKey<int>(x => x.IdBook);

            modelBuilder
                .Entity<Book>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            modelBuilder
                .Entity<Book>()
                .Property(x => x.Description)
                .IsOptional()
                .IsUnicode(true);

            // BookOrder
            modelBuilder
                .Entity<BookOrder>()
                .HasKey<int>(x => x.BookOrderId);

            modelBuilder
                .Entity<BookOrder>()
                .HasRequired<Book>(x => x.Book)
                .WithMany(x => x.BookOrders)
                .HasForeignKey<int>(s => s.BookId);


            base.OnModelCreating(modelBuilder);
        }
    }
}