namespace Backend.Models.DTO
{
  

        
        public record KorisnikDTORead(
            int KorisnikId, 
            string Ime, 
            string Prezime, 
            string? Email = null, 
            string? TelefonskiBroj = null);
       
    
}
