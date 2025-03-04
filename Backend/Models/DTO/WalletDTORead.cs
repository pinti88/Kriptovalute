namespace Backend.Models.DTO
{
    public record WalletDTORead(
    int Wallet_id,
    string? Mreza,
    string KorisnikImePrezime,
    string Kljuc
);

}
