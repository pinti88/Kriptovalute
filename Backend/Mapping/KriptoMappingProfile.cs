using AutoMapper;
using Backend.Models;
using Backend.Models.DTO;
using System.Text.RegularExpressions;

namespace Backend.Mapping
{
    public class KriptoMappingProfile : Profile
    {
        public KriptoMappingProfile()
        {
            // kreiramo mapiranja: izvor, odredište
            CreateMap<Kriptovaluta, KriptoValutaDTORead>();
            CreateMap<Korisnik, KorisnikDTORead>().ForCtorParam(
                   "KorisnikId",
                   opt => opt.MapFrom(src => src.Korisnik_id)
               ); ;
            CreateMap<KorisnikDTOInsertUpdate, Korisnik>();
            CreateMap<Transakcija, TransakcijaDTORead>()
               .ForCtorParam(
                   "KriptoValutaIme",
                   opt => opt.MapFrom(src => src.KriptoValuta.Ime)
               ); 
            CreateMap<TransakcijaDTOInsertUpdate, Transakcija>();
            CreateMap<Wallet, WalletDTORead>().ForCtorParam(
                   "KorisnikImePrezime",
                   opt => opt.MapFrom(src => src.Korisnik.Ime + " " + src.Korisnik.Prezime)
               ); ;
            CreateMap<WalletDTOInsertUpdate, Wallet>();
        }


    }
    
}
