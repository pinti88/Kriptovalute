using Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Data
{
    public class KriptovaluteContext : DbContext
    {
        public KriptovaluteContext(DbContextOptions<KriptovaluteContext> options) : base(options)
        {
            

        }

        public DbSet<Kriptovaluta> Kriptovalute { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }
        public  DbSet<Transakcija> Transakcije { get; set; }
        public DbSet<KriptoWallet> KriptoWalleti { get; set; }
    }
}
