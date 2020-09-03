using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI_SWT.Models
{
    public partial class STTPContext : DbContext
    {
        public STTPContext()
        {
        }

        public STTPContext(DbContextOptions<STTPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aktivnost> Aktivnost { get; set; }
        public virtual DbSet<Fakultet> Fakultet { get; set; }
        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Mjesto> Mjesto { get; set; }
        public virtual DbSet<Projekt> Projekt { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Zadatak> Zadatak { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-54TD9N4\\IVAN;Initial Catalog=STTP;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aktivnost>(entity =>
            {
                entity.Property(e => e.AktivnostId).HasColumnName("Aktivnost_ID");

                entity.Property(e => e.DatumKreiranja)
                    .HasColumnName("datum_kreiranja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkKorisnik).HasColumnName("Fk_Korisnik");

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.ZadatakId).HasColumnName("Zadatak_ID");

                entity.HasOne(d => d.FkKorisnikNavigation)
                    .WithMany(p => p.Aktivnost)
                    .HasForeignKey(d => d.FkKorisnik)
                    .HasConstraintName("FK_Aktivnost_Korisnik");

                entity.HasOne(d => d.Zadatak)
                    .WithMany(p => p.Aktivnost)
                    .HasForeignKey(d => d.ZadatakId)
                    .HasConstraintName("FK_Aktivnost_Zadatak");
            });

            modelBuilder.Entity<Fakultet>(entity =>
            {
                entity.Property(e => e.FakultetId).HasColumnName("Fakultet_ID");

                entity.Property(e => e.Adresa).HasMaxLength(200);

                entity.Property(e => e.FakultetIme)
                    .HasColumnName("Fakultet_ime")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkMjesto).HasColumnName("Fk_mjesto");

                entity.HasOne(d => d.FkMjestoNavigation)
                    .WithMany(p => p.Fakultet)
                    .HasForeignKey(d => d.FkMjesto)
                    .HasConstraintName("FK_Fakultet_Fakultet");
            });

            modelBuilder.Entity<Firma>(entity =>
            {
                entity.Property(e => e.FirmaId).HasColumnName("Firma_ID");

                entity.Property(e => e.Adresa).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirmaIme)
                    .HasColumnName("Firma_ime")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkMjesto).HasColumnName("FK_mjesto");

                entity.HasOne(d => d.FkMjestoNavigation)
                    .WithMany(p => p.Firma)
                    .HasForeignKey(d => d.FkMjesto)
                    .HasConstraintName("FK_Firma_Mjesto");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.KorisnikId).HasColumnName("Korisnik_ID");

                entity.Property(e => e.BrojTelefona).HasColumnName("broj_telefona");

                entity.Property(e => e.Ime).HasMaxLength(255);

                entity.Property(e => e.IsAuthenticated).HasColumnName("isAuthenticated");

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(20);

                entity.Property(e => e.Lozinka)
                    .HasColumnName("lozinka")
                    .HasMaxLength(30);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(200);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("passwordHash")
                    .HasMaxLength(1024);

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("passwordSalt")
                    .HasMaxLength(1024);

                entity.HasOne(d => d.FakultetNavigation)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.Fakultet)
                    .HasConstraintName("FK_Korisnik_Fakultet");

                entity.HasOne(d => d.FirmaNavigation)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.Firma)
                    .HasConstraintName("FK_Korisnik_Firma");

                entity.HasOne(d => d.ProjektNavigation)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.Projekt)
                    .HasConstraintName("FK_Korisnik_Projekt");

                entity.HasOne(d => d.UlogaNavigation)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.Uloga)
                    .HasConstraintName("FK_Korisnik_Uloga");
            });

            modelBuilder.Entity<Mjesto>(entity =>
            {
                entity.Property(e => e.MjestoId).HasColumnName("Mjesto_ID");

                entity.Property(e => e.Ime)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.Property(e => e.ProjektId).HasColumnName("Projekt_ID");

                entity.Property(e => e.DatumPocetka)
                    .HasColumnName("Datum_pocetka")
                    .HasColumnType("date");

                entity.Property(e => e.DatumZavrsetka)
                    .HasColumnName("Datum_zavrsetka")
                    .HasColumnType("date");

                entity.Property(e => e.FkFirma).HasColumnName("Fk_firma");

                entity.Property(e => e.Ime).HasMaxLength(100);

                entity.Property(e => e.IsOver).HasColumnName("isOver");

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.HasOne(d => d.FkFirmaNavigation)
                    .WithMany(p => p.Projekt)
                    .HasForeignKey(d => d.FkFirma)
                    .HasConstraintName("FK_Projekt_Firma");
            });

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.Property(e => e.RecenzijaId).HasColumnName("Recenzija_ID");

                entity.Property(e => e.AktivnostId).HasColumnName("Aktivnost_ID");

                entity.Property(e => e.DatumKreiranja)
                    .HasColumnName("datum_kreiranja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkKorisnik).HasColumnName("Fk_Korisnik");

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.ZadatakId)
                    .HasColumnName("Zadatak_ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Aktivnost)
                    .WithMany(p => p.Recenzija)
                    .HasForeignKey(d => d.AktivnostId)
                    .HasConstraintName("FK_Recenzija_Aktivnost");

                entity.HasOne(d => d.FkKorisnikNavigation)
                    .WithMany(p => p.Recenzija)
                    .HasForeignKey(d => d.FkKorisnik)
                    .HasConstraintName("FK__Recenzija__Fk_Ko__76969D2E");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.Property(e => e.UlogaId).HasColumnName("Uloga_ID");

                entity.Property(e => e.Ime)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zadatak>(entity =>
            {
                entity.Property(e => e.ZadatakId).HasColumnName("Zadatak_ID");

                entity.Property(e => e.DatumKreiranja)
                    .HasColumnName("datum_kreiranja")
                    .HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("Korisnik_ID");

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Zadatak)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Zadatak_Korisnik");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
