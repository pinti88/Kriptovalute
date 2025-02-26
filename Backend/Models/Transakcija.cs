using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Transakcija
    {
        [Key]
        public int Transakcija_id  { get; set; }

        public decimal Kolicina { get; set; }

        [ForeignKey("kripto_id")]
        public Kriptovaluta KriptoValuta { get; set; }

        public decimal Naknada { get; set; }
        public object Kripto_id { get; internal set; }
    }
}
