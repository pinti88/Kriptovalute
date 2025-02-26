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
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, Transakcija transakcija)
        {
            try
            {
                var t = _context.Transakcije.Find(id);

                if (t == null)
                {
                    return NotFound();
                }

                t.Kolicina = transakcija.Kolicina;
                t.Kripto_id = transakcija.Kripto_id;
                t.Naknada = transakcija.Naknada;

                _context.Transakcije.Update(t);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno promijenjeno" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
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
