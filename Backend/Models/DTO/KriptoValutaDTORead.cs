namespace Backend.Models.DTO
{
    public record KriptoValutaDTORead(
     int Kripto_id ,
     string Ime ,
     string Simbol,
     decimal? Cijena,
     decimal? Trzisna_vrijednost,
     decimal Volumen 
        );
}
