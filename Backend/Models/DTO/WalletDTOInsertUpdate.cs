using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{   
    public record WalletDTOInsertUpdate(
    [Required(ErrorMessage = "Mreža je obavezna")] string Mreza,
    [Required(ErrorMessage = "Korisnik ID je obavezan")] int KorisnikId,
    [Required(ErrorMessage = "Ključ je obavezan")] string Kljuc);
    
}
