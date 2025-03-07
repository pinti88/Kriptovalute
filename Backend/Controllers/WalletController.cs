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
    public class WalletController : ControllerBase
    {
        private readonly KriptovaluteContext _context;
        private readonly IMapper _mapper; 

        public WalletController(KriptovaluteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        [HttpGet]
        public ActionResult<List<WalletDTORead>> Get()
        {
            try
            {
                var wallets = _context.Walleti.Include(w => w.Korisnik).ToList();
                var walletDTOs = _mapper.Map<List<WalletDTORead>>(wallets); 
                return Ok(walletDTOs);
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
                var walletDTO = _mapper.Map<WalletDTORead>(wallet); 
                return Ok(walletDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Greška na serveru: {e.Message}");
            }
        }

        [HttpPut("{walletId:int}")]
        public IActionResult Put(int walletId, WalletDTOInsertUpdate walletDto)
        {
            try
            {
                var walleti = _context.Walleti.Find(walletId);
                if (walleti == null)
                {
                    return NotFound(new { poruka = "Wallet nije pronađen." });
                }

                // dovrsiti



                _context.SaveChanges();

                var updatedWalletDTO = _mapper.Map<WalletDTORead>(walleti);
                return Ok(updatedWalletDTO);
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

                var walletDTO = _mapper.Map<WalletDTORead>(wallet); 
                return StatusCode(StatusCodes.Status201Created, walletDTO);
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

