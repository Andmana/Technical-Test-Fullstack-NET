using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NET_API.Models;

public partial class Technical_Test_Context : DbContext
{
    public Technical_Test_Context()
    {
    }

    public Technical_Test_Context(DbContextOptions<Technical_Test_Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Technical_Test;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3213E83F187764A9");

            entity.ToTable("Company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DirectorName)
                .HasMaxLength(255)
                .HasColumnName("director_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.InvitationAccess)
                .HasDefaultValue(false)
                .HasColumnName("invitation_access");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Npwp)
                .HasMaxLength(50)
                .HasColumnName("NPWP");
            entity.Property(e => e.NpwpSrc)
                .HasMaxLength(255)
                .HasColumnName("NPWP_src");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.PicName)
                .HasMaxLength(255)
                .HasColumnName("PIC_name");
            entity.Property(e => e.PowerOfAttoreySrc)
                .HasMaxLength(255)
                .HasColumnName("power_of_attorey_src");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
