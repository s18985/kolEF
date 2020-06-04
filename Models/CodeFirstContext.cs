using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Klientt> Klientt { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
        public DbSet<Pracownikk> Pracownikk { get; set; }
        public DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public DbSet<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }


        public CodeFirstContext() { }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klientt>(entity =>
            {
                entity.HasKey(e => e.IdKlientt).HasName("Klientt_PK");

                entity.Property(e => e.Imie).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Nazwisko).HasMaxLength(60).IsRequired();

            });

            modelBuilder.Entity<Pracownikk>(entity =>
            {
                entity.HasKey(e => e.IdPracownikk).HasName("Pracownikk_PK");

                entity.Property(e => e.Imie).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Nazwisko).HasMaxLength(60).IsRequired();

            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia).HasName("Zamowienie_PK");

                entity.Property(e => e.DataPrzyjecia).IsRequired();
                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(d => d.Klientt)
                    .WithMany(p => p.Zamowienia)
                    .HasForeignKey(d => d.IdKlientt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klientt");

                entity.HasOne(d => d.Pracownikk)
                    .WithMany(p => p.Zamowienia)
                    .HasForeignKey(d => d.IdPracownikk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pracownikk");

            });

            modelBuilder.Entity<WyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => e.IdWyrobuCukierniczego).HasName("WyrobCukierniczy_PK");

                entity.Property(e => e.Nazwa).HasMaxLength(200).IsRequired();
                entity.Property(e => e.CenaZaSzt).IsRequired();
                entity.Property(e => e.Typ).HasMaxLength(40).IsRequired();

            });

            modelBuilder.Entity<ZamowienieWyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => new { e.IdWyrobuCukierniczego, e.IdZamowienia }).HasName("Zamowienie_WyrobCukierniczy_PK");

                entity.ToTable("Zamowienie_WyrobCukierniczy");

                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(d => d.WyrobCukierniczy)
                    .WithMany(p => p.ZamowienieWyrobCukierniczy)
                    .HasForeignKey(d => d.IdWyrobuCukierniczego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_WyrobCukierniczy_WyrobCukierniczy");

                entity.HasOne(d => d.Zamowienie)
                    .WithMany(p => p.ZamowienieWyrobCukierniczy)
                    .HasForeignKey(d => d.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_WyrobCukierniczy_Zamowienie");
            });
        }
    }
}
