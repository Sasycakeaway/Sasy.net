using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sasy.NET.Model;

public partial class SasyContext : DbContext
{
    public SasyContext()
    {
    }

    public SasyContext(DbContextOptions<SasyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Newsletter> Newsletters { get; set; }

    public virtual DbSet<Ordini> Ordinis { get; set; }

    public virtual DbSet<RecoveryPassword> RecoveryPasswords { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Newsletter>(entity =>
        {
            entity.HasKey(e => new { e.FkEmail, e.PkToken });

            entity.ToTable("Newsletter");

            entity.Property(e => e.FkEmail)
                .HasMaxLength(100)
                .HasColumnName("FK_Email");
            entity.Property(e => e.PkToken).HasColumnName("PK_Token");

            entity.HasOne(d => d.FkEmailNavigation).WithMany(p => p.Newsletters)
                .HasForeignKey(d => d.FkEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Newsletter_Utenti");
        });

        modelBuilder.Entity<Ordini>(entity =>
        {
            entity.HasKey(e => new { e.PkId, e.FkEmail });

            entity.ToTable("Ordini");

            entity.Property(e => e.PkId).HasColumnName("PK_ID");
            entity.Property(e => e.FkEmail)
                .HasMaxLength(100)
                .HasColumnName("FK_Email");
            entity.Property(e => e.Cap).HasMaxLength(256);
            entity.Property(e => e.Cognome).HasMaxLength(256);
            entity.Property(e => e.Indirizzo).HasMaxLength(256);
            entity.Property(e => e.Nome).HasMaxLength(256);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.FkEmailNavigation).WithMany(p => p.Ordinis)
                .HasForeignKey(d => d.FkEmail)
                .HasConstraintName("FK_Ordini_Utenti");
        });

        modelBuilder.Entity<RecoveryPassword>(entity =>
        {
            entity.HasKey(e => e.FkEmail);

            entity.ToTable("RecoveryPassword");

            entity.Property(e => e.FkEmail)
                .HasMaxLength(100)
                .HasColumnName("FK_Email");
            entity.Property(e => e.Uuid).HasColumnName("UUID");

            entity.HasOne(d => d.FkEmailNavigation).WithOne(p => p.RecoveryPassword)
                .HasForeignKey<RecoveryPassword>(d => d.FkEmail)
                .HasConstraintName("FK_RecoveryPassword_Utenti");
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.PkEmail);

            entity.ToTable("Utenti");

            entity.Property(e => e.PkEmail)
                .HasMaxLength(100)
                .HasColumnName("PK_Email");
            entity.Property(e => e.Cf)
                .HasMaxLength(256)
                .HasColumnName("CF");
            entity.Property(e => e.Nascita).HasMaxLength(256);
            entity.Property(e => e.News)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Telefono).HasMaxLength(256);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
