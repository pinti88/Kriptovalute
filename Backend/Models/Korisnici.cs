using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Korisnici
    {
        [Key]
        public int korisnik_id  { get; set; }

        public string ime { get; set; } = "";

        public string prezime { get; set; } = "";

        public string email { get; set; } = "";

        public int telefonski_broj { get; set; }

    }
}
