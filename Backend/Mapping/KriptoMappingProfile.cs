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
            CreateMap<Korisnik, KorisnikDTORead>();
            CreateMap<KorisnikDTOInsertUpdate, Korisnik>();

            CreateMap<Transakcija, TransakcijaDTORead>();
            CreateMap<TransakcijaDTOInsertUpdate, Transakcija>();

            CreateMap<Wallet, WalletDTORead>();
            CreateMap<WalletDTOInsertUpdate, Wallet>();
        }


    }
    
}
