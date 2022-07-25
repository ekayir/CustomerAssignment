using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AssignmentSigortamNet.Data
{
    public partial class AssignmentSigortamNetDBContext : DbContext
    {
        public AssignmentSigortamNetDBContext()
        {
        }

        public AssignmentSigortamNetDBContext(DbContextOptions<AssignmentSigortamNetDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-POLLSKE\\SQLEXPRESS;Database=AssignmentSigortamNetDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.NationalIdNumber, "UIX_Customer_NationalIdNumber")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
