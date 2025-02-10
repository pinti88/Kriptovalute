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


    }
}
