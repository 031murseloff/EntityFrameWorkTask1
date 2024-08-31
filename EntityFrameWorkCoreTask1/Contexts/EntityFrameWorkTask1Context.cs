using System;
using System.Collections.Generic;
using EntityFrameWorkCoreTask1.Enties;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCoreTask1.Contexts;

public partial class EntityFrameWorkTask1Context : DbContext
{
    public EntityFrameWorkTask1Context()
    {
    }

    public EntityFrameWorkTask1Context(DbContextOptions<EntityFrameWorkTask1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStudent> BookStudents { get; set; }

    public virtual DbSet<BookType> BookTypes { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-T3OFGQN;Database=EntityFrameWorkTask1;User Id=elsan;Password=admin1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC075338599F");
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(15);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07B51581C8");

            entity.Property(e => e.Name).HasMaxLength(15);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Author");

            entity.HasOne(d => d.BookType).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookType");
        });

        modelBuilder.Entity<BookStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookStud__3214EC0756D63A35");

            entity.ToTable("BookStudent");

            entity.HasOne(d => d.Book).WithMany(p => p.BookStudents)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book");

            entity.HasOne(d => d.Student).WithMany(p => p.BookStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student");
        });

        modelBuilder.Entity<BookType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookType__3214EC07BF2ACAA2");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07D624C2F0");
            entity.Property(e=>e.Gender).HasConversion<string>();
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(15);
            entity.Property(e => e.SchoolNumber);
            entity.Property(e=>e.PhoneNumber).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
