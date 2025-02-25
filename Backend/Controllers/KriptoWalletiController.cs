using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KriptoWalletController:ControllerBase
    {
        private readonly KriptovaluteContext _context;

        KriptoWalletController(KriptovaluteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.KriptoWalleti);
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
                var s = _context.KriptoWalleti.Find(sifra);
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
        public IActionResult Post(KriptoWallet KriptoWalleti)
        {
            try
            {
                _context.Korisnici.Add(KriptoWalleti);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, kriptoWalleti);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, KriptoWallet korisnik)
        {
            try
            {
                var s = _context.KriptoWallet.Find(sifra);

                if (s == null)
                {
                    return NotFound();
                }

                w.Wallet_id = KriptoWallet.Wallet_id;
                w.Kripto_id = KriptoWallet.Kripto_id;
                
                _context.KriptoWalleti.Update(s);
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
                var s = _context.KriptoWalleti.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                _context.KriptoWalleti.Remove(s);
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
