using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class WalletiController
    {
        [ApiController]
        [Route("api/v1/[controller]")]
        public class WalletsController : ControllerBase
        {
            private readonly KriptovaluteContext _context;

            public WalletsController(KriptovaluteContext context)
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
                    return BadRequest(e);
                }
            }

            [HttpGet]
            [Route("{walletId:int}")]
            public IActionResult GetByWalletId(int walletId)
            {
                try
                {
                    var wallet = _context.Walleti.Include(w => w.Korisnik).FirstOrDefault(w => w.Wallet_id == walletId);
                    if (wallet == null)
                    {
                        return NotFound();
                    }
                    return Ok(wallet);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            [HttpPut]
            [Route("{sifra:int}")]
            [Produces("application/json")]
            public IActionResult Put(int sifra, Wallet wallet)
            {
                try
                {
                    
                    var walleti = _context.Walleti.Find(sifra);

                    
                    if (wallet == null)
                    {
                        return NotFound();
                    }

                    
                    wallet.Mreza = wallet.Mreza;
                    wallet.Kljuc = wallet.Kljuc;

                   
                    _context.SaveChanges();

                    
                    return Ok(wallet);
                }
                catch (Exception ex)
                {
                   
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }



            [HttpPost]
            public IActionResult Post(Wallet wallet)
            {
                try
                {
                    _context.Walleti.Add(wallet);
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, wallet);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            
         

            
            [HttpDelete]
            [Route("{walletId:int}")]
            public IActionResult Delete(int walletId)
            {
                try
                {
                    var wallet = _context.Walleti.Find(walletId);
                    if (wallet == null)
                    {
                        return NotFound();
                    }

                    _context.Walleti.Remove(wallet);
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
}
