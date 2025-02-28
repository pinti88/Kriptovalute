﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public class KorisnikDTORead
    {
        public record KorisnikDTOInsertUpdate(
    [Required(ErrorMessage = "Ime je obavezno")] string Ime,
    [Required(ErrorMessage = "Prezime je obavezno")] string Prezime,
    [EmailAddress(ErrorMessage = "Neispravan format email adrese")] string? Email,
    string? TelefonskiBroj);
    }
}
