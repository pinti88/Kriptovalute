using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Kriptovaluta 
    {
        [Key]
        public int Kripto_id { get; set; }
        public string Ime { get; set; } = "";
        public string Simbol { get; set; }

        public decimal? Cijena { get; set; }

        public decimal? Trzisna_vrjednost { get; set; }

        public decimal Volumen { get; set; }

    }
}
