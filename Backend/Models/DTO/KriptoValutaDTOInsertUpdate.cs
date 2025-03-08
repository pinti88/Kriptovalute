using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
        public record KriptoValutaDTOInsertUpdate(
    [Required(ErrorMessage = "Ime je obavezno")] string Ime,
    [Required(ErrorMessage = "Simbol je obavezan")] string Simbol,
    [Range(0, double.MaxValue, ErrorMessage = "Cijena mora biti pozitivna")] decimal? Cijena,
    [Range(0, double.MaxValue, ErrorMessage = "Tržišna vrijednost mora biti pozitivna")] decimal? Trzisna_vrijednost,
    [Range(0, double.MaxValue, ErrorMessage = "Volumen mora biti pozitivan")] decimal? Volumen
);

    
}
