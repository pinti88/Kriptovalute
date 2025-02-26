using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace Backend.Data
{
    public class KriptovaluteContext : DbContext
    {
        public KriptovaluteContext(DbContextOptions<KriptovaluteContext> options) : base(options)
        {
            

        }

        public DbSet<Kriptovaluta> Kriptovalute { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Wallet> Walleti { get; set; }
        public  DbSet<Transakcija> Transakcije { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>().HasOne(g => g.Korisnik);
            modelBuilder.Entity<Transakcija>().HasOne(g => g.KriptoValuta);
            modelBuilder.Entity<Wallet>()
               .HasMany(g => g.Kriptovalute)
               .WithMany(p => p.Walleti)
               .UsingEntity<Dictionary<string, object>>("kriptowalleti",
               c => c.HasOne<Kriptovaluta>().WithMany().HasForeignKey("kripto_id"),
               c => c.HasOne<Wallet>().WithMany().HasForeignKey("wallet_id"),
               c => c.ToTable("kriptowalleti")
               );
        }

    }
}
