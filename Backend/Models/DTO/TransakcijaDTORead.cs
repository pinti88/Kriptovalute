namespace Backend.Models.DTO
{    
    public record TransakcijaDTORead(
    int TransakcijaId,
    decimal Kolicina,
    int KriptoId,
    decimal? Naknada
);
    
}
