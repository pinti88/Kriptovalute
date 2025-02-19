using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class KorisniciContext : DbContext
    {

        public KorisniciContext(DbContextOptions<KorisniciContext> options) : base(options)
        {


        }
         public DbSet<Korisnici> Korisnici { get; set; }


      


    }
}
