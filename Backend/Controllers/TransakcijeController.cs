using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransakcijeController : ControllerBase
    {
        private readonly KriptovaluteContext _context;

        public TransakcijeController(KriptovaluteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Transakcije);
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
                var transakcija = _context.Transakcije.Find(id);
                if (transakcija == null)
                {
                    return NotFound();
                }
                return Ok(transakcija);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(Transakcija transakcija)
        {
            try
            {
                _context.Transakcije.Add(transakcija);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, transakcija);
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
                transakcija.Kripto_id = transakcija.Kripto_id;

                
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
