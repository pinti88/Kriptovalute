using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KriptovaluteController : BackendController
    {
        public KriptovaluteController(KriptovaluteContext context, IMapper mapper) : base(context, mapper) { }

        [HttpGet]
        public ActionResult<List<KriptoValutaDTORead>> Get()
        {
            try
            {
                var kriptovalute = _context.Kriptovalute.ToList();
                return Ok(_mapper.Map<List<KriptoValutaDTORead>>(kriptovalute));
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
                var s = _context.Kriptovalute.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<KriptoValutaDTORead>(s));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(KriptoValutaDTOInsertUpdate kriptoValutaDTORead)
        {
            try
            {
                var Kriptovaluta = _mapper.Map<Kriptovaluta>(kriptoValutaDTORead);
                _context.Kriptovalute.Add(Kriptovaluta);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,Kriptovaluta);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Kriptovaluta kriptovaluta)
        {
            try
            {
                var s = _context.Kriptovalute.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }

                s.Ime = kriptovaluta.Ime;
                s.Cijena = kriptovaluta.Cijena;
                s.Volumen = kriptovaluta.Volumen;
                s.Trzisna_vrjednost = kriptovaluta.Trzisna_vrjednost;
                s.Simbol = kriptovaluta.Simbol;

                _context.Kriptovalute.Update(s);
                _context.SaveChanges();
                return Ok(_mapper.Map<KriptoValutaDTORead>(s));
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
                var s = _context.Kriptovalute.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                _context.Kriptovalute.Remove(s);
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
