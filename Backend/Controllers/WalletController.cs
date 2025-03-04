using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly KriptovaluteContext _context;

        public WalletController(KriptovaluteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var wallets = _context.Walleti.Include(w => w.Korisnik).ToList();
                return Ok(wallets);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Greška na serveru: {e.Message}");
            }
        }

        [HttpGet("{walletId:int}")]
        public IActionResult GetByWalletId(int walletId)
        {
            try
            {
                var wallet = _context.Walleti.Include(w => w.Korisnik).FirstOrDefault(w => w.Wallet_id == walletId);
                if (wallet == null)
                {
                    return NotFound(new { poruka = "Wallet nije pronađen." });
                }
                return Ok(wallet);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Greška na serveru: {e.Message}");
            }
        }

        [HttpPut("{walletId:int}")]
        public IActionResult Put(int walletId, [FromBody] Wallet wallet)
        {
            try
            {
                var walleti = _context.Walleti.Find(walletId);
                if (walleti == null)
                {
                    return NotFound(new { poruka = "Wallet nije pronađen." });
                }

                // Ažuriranje podataka
                walleti.Mreza = wallet.Mreza;
                walleti.Kljuc = wallet.Kljuc;

                _context.SaveChanges();

                return Ok(walleti);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Greška na serveru: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Wallet wallet)
        {
            try
            {
                if (wallet == null)
                {
                    return BadRequest(new { poruka = "Podaci nisu ispravni." });
                }

                _context.Walleti.Add(wallet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, wallet);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Greška na serveru: {e.Message}");
            }
        }

        [HttpDelete("{walletId:int}")]
        public IActionResult Delete(int walletId)
        {
            try
            {
                var wallet = _context.Walleti.Find(walletId);
                if (wallet == null)
                {
                    return NotFound(new { poruka = "Wallet nije pronađen." });
                }

                _context.Walleti.Remove(wallet);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano." });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Greška na serveru: {e.Message}");
            }
        }
    }
}
