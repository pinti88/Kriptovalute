namespace Backend.Models.DTO
{    
    public record TransakcijaDTORead(
    int Transakcija_id,
    decimal Kolicina,
    string KriptoValutaIme,
    decimal? Naknada
);
    
}
