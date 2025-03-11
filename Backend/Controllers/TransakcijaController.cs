using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransakcijaController(KriptovaluteContext context, IMapper mapper) : BackendController(context, mapper)
    {
 

        [HttpGet]
        public ActionResult<List<TransakcijaDTORead>> Get()
        {
            try
            {
            
                return Ok(_mapper.Map<List<TransakcijaDTORead>>(_context.Transakcije.Include(t => t.KriptoValuta)));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                try
                {
                    var s = _context.Transakcije.Find(id);
                    if (s == null)
                    {
                        return NotFound();
                    }
                    return Ok(_mapper.Map<TransakcijaDTORead>(s));
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(TransakcijaDTOInsertUpdate dto)
        {
            try
            {

                var kriptovaluta = _context.Kriptovalute.Find(dto.KriptoId);

                var Transakcija = _mapper.Map<Transakcija>(dto);
                Transakcija.KriptoValuta = kriptovaluta;
                _context.Transakcije.Add(Transakcija);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<TransakcijaDTORead>(Transakcija));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra,TransakcijaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Transakcija? e;
                try
                {
                    e = _context.Transakcije.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Transakcija ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Transakcije.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }





        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var t = _context.Transakcije.Find(id);
                if (t == null)
                {
                    return NotFound();
                }
                _context.Transakcije.Remove(t);
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
