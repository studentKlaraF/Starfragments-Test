using SeminarskaNaloga.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SeminarskaNaloga.Data
{   
    public class TrgovinaContext : IdentityDbContext<AppUser>
    {
        public TrgovinaContext(DbContextOptions<TrgovinaContext> options) : base(options)
        {
        }

        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<ArtikelKosarice> ArtikelKosarice { get; set; }
        public DbSet<Trgovina> Trgovina { get; set; }
        public DbSet<Kosarica> Kosarica { get; set; }
        public DbSet<Narocilo> Narocilo { get; set; }
        public DbSet<InfoONarocilu> InfoONarocilu { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Kosarica>().ToTable("Kosarica");
            modelBuilder.Entity<Artikel>().ToTable("Artikel");
            modelBuilder.Entity<Trgovina>().ToTable("Trgovina");
            modelBuilder.Entity<ArtikelKosarice>().ToTable("ArtikelKosarice");
            modelBuilder.Entity<Narocilo>().ToTable("Narocilo");
            modelBuilder.Entity<InfoONarocilu>().ToTable("InfoONarocilu");
        }
    }
}