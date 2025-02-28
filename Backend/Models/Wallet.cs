using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Wallet
    {
        [Key]
        public int Wallet_id { get; set; }

        public string? Mreza { get; set; }

        [ForeignKey("korisnik_id")]
        public Korisnik? Korisnik { get; set; }

        public string Kljuc { get; set; } = "";

        public ICollection<Kriptovaluta>? Kriptovalute { get; set; }


    }
}
