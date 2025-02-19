using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Korisnik
    {
        [Key]
        public int Korisnik_id  { get; set; }

        public string Ime { get; set; } = "";

        public string Prezime { get; set; } = "";

        public string? Email { get; set; }

        public string? Telefonski_broj { get; set; }

    }
}
