using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{

        public record KorisnikDTORead(
    [Required(ErrorMessage = "Ime je obavezno")] string Ime,
    [Required(ErrorMessage = "Prezime je obavezno")] string Prezime,
    [EmailAddress(ErrorMessage = "Neispravan format email adrese")] string? Email,
    string? TelefonskiBroj);
    
}
