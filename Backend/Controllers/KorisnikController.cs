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
        public IActionResult Post(KorisnikDTOInsertUpdate korisnikDTORead)
        {
            try
            {
                var korisnik = _mapper.Map<Korisnik>(korisnikDTORead);
                _context.Korisnici.Add(korisnik);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<KorisnikDTORead>(korisnik));


            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, KorisnikDTOInsertUpdate korisnikDTORead)
        {
            try
            {
                var s = _context.Korisnici.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }

                s.Ime = korisnikDTORead.Ime;
                s.Prezime = korisnikDTORead.Prezime;
                s.Email =korisnikDTORead.Email;
                s.Telefonski_broj = korisnikDTORead.TelefonskiBroj;

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