using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KorisnikController : ControllerBase
    {
        private readonly KriptovaluteContext _context;
        private readonly IMapper _mapper;

        public KorisnikController(KriptovaluteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<KorisnikDTORead>> Get()
        {
            try
            {
                var korisnici = _context.Korisnici.ToList();
                return Ok(_mapper.Map<List<KorisnikDTORead>>(korisnici));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            try
            {
                var s = _context.Korisnici.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
               return Ok(_mapper.Map<KorisnikDTORead>(s));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }


        }

        [HttpPost]
        public IActionResult Post(Korisnik korisnici)
        {
            try
            {
                _context.Korisnici.Add(korisnici);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, korisnici);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Korisnik korisnik)
        {
            try
            {
                var s = _context.Korisnici.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }

                s.Ime = korisnik.Ime;
                s.Prezime = korisnik.Prezime;
                s.Email = korisnik.Email;
                s.Telefonski_broj = korisnik.Telefonski_broj;

                _context.Korisnici.Update(s);
                _context.SaveChanges();
                return Ok(_mapper.Map<KorisnikDTORead>(s));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        public IActionResult Delete(int sifra)
        {
            try
            {
                var s = _context.Korisnici.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }

                _context.Korisnici.Remove(s);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}