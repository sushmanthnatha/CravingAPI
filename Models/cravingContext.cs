using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CravingAPI.Models;

#nullable disable

namespace CravingAPI.Models
{
    public partial class cravingContext : DbContext
    {
        public cravingContext()
        {
        }

        public cravingContext(DbContextOptions<cravingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Userdetail> Userdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=craving;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Userdetail>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__userdeta__CBA1B2574C821072");

                entity.ToTable("userdetails");

                entity.Property(e => e.Userid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userid")
                    .HasDefaultValueSql("(format(NEXT VALUE FOR [userseq],'AJ00000#'))");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Imageurl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("imageurl");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('U')")
                    .IsFixedLength(true);
            });

            modelBuilder.HasSequence<int>("USERSEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<CravingAPI.Models.Item> Item { get; set; }

        public DbSet<CravingAPI.Models.Cart> Cart { get; set; }
    }
}
