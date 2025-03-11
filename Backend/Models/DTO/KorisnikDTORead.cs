namespace Backend.Models.DTO
{
    public record KorisnikDTORead
    {
        public int KorisnikId { get; init; }
        public string? Ime { get; init; }
        public string? Prezime { get; init; }
        public string? Email { get; init; }
        public string? TelefonskiBroj { get; init; }

        
        public KorisnikDTORead() { }

        
        public KorisnikDTORead(int korisnikId, string ime, string prezime, string? email = null, string? telefonskiBroj = null)
        {
            KorisnikId = korisnikId;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            TelefonskiBroj = telefonskiBroj;
        }
    }
}
