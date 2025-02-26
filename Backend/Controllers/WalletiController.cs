using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

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

            // GET api/v1/wallets
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

            // GET api/v1/wallets/{walletId}
            [HttpGet]
            [Route("{walletId:int}")]
            public IActionResult GetByWalletId(int walletId)
            {
                try
                {
                    var wallet = _context.Walleti.Include(w => w.Korisnik).FirstOrDefault(w => w.WalletId == walletId);
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

            // POST api/v1/wallets
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

            // PUT api/v1/wallets/{walletId}
            [HttpPut]
            [Route("{walletId:int}")]
            public IActionResult Put(int walletId, Wallet wallet)
            {
                try
                {
                    var existingWallet = _context.Walleti.Find(walletId);
                    if (existingWallet == null)
                    {
                        return NotFound();
                    }

                    Wallet.Mreza = wallet.Mreza;
                    Wallet.KorisnikId = wallet.KorisnikId;
                    Wallet.Kljuc = wallet.Kljuc;

                    _context.Wallets.Update(existingWallet);
                    _context.SaveChanges();
                    return Ok(new { poruka = "Uspješno promijenjeno" });
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
