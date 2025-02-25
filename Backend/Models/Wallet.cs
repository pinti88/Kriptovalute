using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Wallet
    {
        [Key]
        public int wallet_id { get; set; }

        public int mreza { get; set; }

        public int korisnik_id { get; set; }

        public int kljuc { get; set; }
    }
}
