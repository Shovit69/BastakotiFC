using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShovitBastakoti.Models
{
    public partial class BastakotiFCContext : DbContext
    {
        public BastakotiFCContext()
        {
        }

        public BastakotiFCContext(DbContextOptions<BastakotiFCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Performance> Performances { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.MatchId).HasColumnName("Match Id");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MatchDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Match Date");

                entity.Property(e => e.Opponent)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Score)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("Payment Id");

                entity.Property(e => e.PaymentAmount).HasColumnName("Payment Amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Payment Date");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Payment Method");

                entity.Property(e => e.PlayerId).HasColumnName("Player Id");

                entity.Property(e => e.ValidTill)
                    .HasColumnType("datetime")
                    .HasColumnName("Valid Till");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Players");
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Player Id");

                entity.Property(e => e.MatchId).HasColumnName("Match Id");

                entity.Property(e => e.MinutesPlayed).HasColumnName("Minutes Played");

                entity.Property(e => e.Opponent)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Performances)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Performances_Matches");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).HasColumnName("Player ID");

                entity.Property(e => e.ContactNumber).HasColumnName("Contact Number");

                entity.Property(e => e.Guardian)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredPosition)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Preferred Position");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
