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
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, KriptoValutaDTOInsertUpdate KriptoValutaDtoRead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                
                Kriptovaluta? kriptovaluta;
                try
                {
                    kriptovaluta = _context.Kriptovalute.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }

                if (kriptovaluta == null)
                {
                    return NotFound(new { poruka = "Kriptovaluta ne postoji u bazi" });
                }

                kriptovaluta = _mapper.Map(KriptoValutaDtoRead, kriptovaluta);

                
                _context.Kriptovalute.Update(kriptovaluta);
                _context.SaveChanges();

                return Ok(new { poruka = "Kriptovaluta uspješno ažurirana" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
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
