using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KorisniciController : ControllerBase
    {
        private readonly KorisniciContext _context;

        public KorisniciController(KorisniciContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Korisnici);
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
                return Ok(s);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(Korisnici korisnici)
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
        public IActionResult Put(int sifra, Korisnici korisnici)
        {
            try
            {
                var s = _context.Korisnici.Find(sifra);

                if (s == null)
                {
                    return NotFound();
                }

                s.ime = korisnici.ime; 
                s.prezime = korisnici.prezime; 
                s.email = korisnici.email; 
                s.telefonski_broj = korisnici.telefonski_broj; 

                _context.Korisnici.Update(s);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno promijenjeno" });
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
