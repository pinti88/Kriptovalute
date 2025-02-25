using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Transakcija
    {
        [Key]
        public int Transakcija_id  { get; set; }

        public int Kolicina { get; set; } 

        public int Kripto_id { get; set; }

        public int Naknada { get; set; }

    }
}
