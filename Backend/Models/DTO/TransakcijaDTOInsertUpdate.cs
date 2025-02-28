using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public record TransakcijaDTOInsertUpdate(
    [Required(ErrorMessage = "Količina je obavezna")]
    [Range(0, double.MaxValue, ErrorMessage = "Količina mora biti pozitivna")] decimal Kolicina,
    [Required(ErrorMessage = "Kripto ID je obavezan")] int KriptoId,
    [Range(0, double.MaxValue, ErrorMessage = "Naknada mora biti pozitivna")] decimal? Naknada
);


}
