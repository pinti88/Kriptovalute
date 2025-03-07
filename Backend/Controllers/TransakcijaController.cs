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
        public IActionResult Post(TransakcijaDTOInsertUpdate transakcijaDTORead)
        {
            try
            {
                var Transakcija = _mapper.Map<Transakcija>(transakcijaDTORead);
                _context.Transakcije.Add(Transakcija);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, Transakcija);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Transakcija transakcija)
        {
            try
            {
                
                var transakcije = _context.Transakcije.Find(sifra);

                
                if (transakcija == null)
                {
                    return NotFound();
                }

               
                transakcija.Kolicina = transakcija.Kolicina;
                transakcija.Naknada = transakcija.Naknada;

                
                _context.SaveChanges();

                
                return Ok(transakcija);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
