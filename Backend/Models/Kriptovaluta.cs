using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Kriptovaluta
    {
        [Key]
        public int Kripto_id { get; set; } 
        [Required]
        public string Ime { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string Simbol { get; set; } = string.Empty;
        public decimal? Cijena { get; set; }
        public decimal? Trzisna_vrijednost { get; set; }
        public decimal Volumen { get; set; }
        public ICollection<Transakcija>? Transakcije { get; set; } = new List<Transakcija>(); 
        public ICollection<Wallet>? Walleti { get; set; } = new List<Wallet>();
    }
}
