namespace Backend.Models.DTO
{
    public record KorisnikDTORead(
        int KorisnikId,
        string Ime,
        string Prezime,
        string? Email,
        string? TelefonskiBroj
    );
}
