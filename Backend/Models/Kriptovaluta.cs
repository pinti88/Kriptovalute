namespace Backend.Models
{
    public class Kriptovaluta : Entitet
    {
        public string Naziv { get; set; } = "";

        public string Simbol { get; set; }

        public decimal? Cijena { get; set; }

        public decimal? TrzisnaVrijednost { get; set; }

        public decimal Volumen { get; set; }

    }
}
