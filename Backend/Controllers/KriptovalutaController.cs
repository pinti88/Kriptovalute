using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SmjerController : ControllerBase
    {

        private readonly KriptovaluteContext _context;

       
        public SmjerController(KriptovaluteContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Kriptovalute);
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
                return Ok(s);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost]
        public IActionResult Post(Kriptovaluta kriptovaluta)
        {
            try
            {
                _context.Smjerovi.Add(kriptovaluta);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, kriptovaluta);
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

                
                s.Naziv = kriptovaluta.Naziv;
                s.CijenaSmjera = smjer.CijenaSmjera;
                s.IzvodiSeOd = smjer.IzvodiSeOd;
                s.Vaucer = smjer.Vaucer;

                _context.Kriptovalute.Update(s);
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
                var s = _context.Kriptovalute.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                _context.Smjerovi.Remove(s);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
