using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LibraryProject.Database;

public partial class Bjijvrrjr8fpicdo4p4kContext : DbContext
{
    public Bjijvrrjr8fpicdo4p4kContext()
    {
    }

    public Bjijvrrjr8fpicdo4p4kContext(DbContextOptions<Bjijvrrjr8fpicdo4p4kContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<LoanBook> LoanBooks { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=bjijvrrjr8fpicdo4p4k-mysql.services.clever-cloud.com;port=3306;database=bjijvrrjr8fpicdo4p4k;user=ukvro0oxck6l1dhm;password=yVbBg8zFQq3GDL2flu9b", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.15-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.Isbn, "isbn_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(45)
                .HasColumnName("author");
            entity.Property(e => e.Available)
                .HasColumnType("tinyint(4)")
                .HasColumnName("available");
            entity.Property(e => e.Category)
                .HasMaxLength(45)
                .HasColumnName("category");
            entity.Property(e => e.Isbn)
                .HasMaxLength(45)
                .HasColumnName("isbn");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");
        });

        modelBuilder.Entity<LoanBook>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.PersonsId, e.BooksId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("loan_books");

            entity.HasIndex(e => e.BooksId, "fk_loan_books_books1_idx");

            entity.HasIndex(e => e.PersonsId, "fk_loan_books_persons1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.PersonsId)
                .HasColumnType("int(11)")
                .HasColumnName("persons_id");
            entity.Property(e => e.BooksId)
                .HasColumnType("int(11)")
                .HasColumnName("books_id");
            entity.Property(e => e.ReturnDate)
                .HasMaxLength(45)
                .HasColumnName("return_date");
            entity.Property(e => e.StarDate)
                .HasMaxLength(45)
                .HasColumnName("star_date");

            entity.HasOne(d => d.Books).WithMany(p => p.LoanBooks)
                .HasForeignKey(d => d.BooksId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_loan_books_books1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.RolesId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("persons");

            entity.HasIndex(e => e.DocumentNumber, "document_number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.RolesId, "fk_users_roles_idx");

            entity.HasIndex(e => e.PhoneNumber, "phone_number_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.RolesId)
                .HasColumnType("int(11)")
                .HasColumnName("roles_id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(45)
                .HasColumnName("document_number");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(45)
                .HasColumnName("phone_number");
            entity.Property(e => e.TypeOfDocument)
                .HasMaxLength(45)
                .HasColumnName("type_of_document");

            entity.HasOne(d => d.Roles).WithMany(p => p.People)
                .HasForeignKey(d => d.RolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_roles");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
