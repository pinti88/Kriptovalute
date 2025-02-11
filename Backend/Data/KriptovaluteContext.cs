using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Backend.Data
{
    public class KriptovaluteContext
    {
        public KriptovaluteContext(DbContextOptions<KriptovaluteContext> options) : base(options)
        {
            

        }

        public DbSet<Kriptovaluta> Smjerovi { get; set; } 


    }
}
