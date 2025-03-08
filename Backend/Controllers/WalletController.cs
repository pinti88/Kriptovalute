using AutoMapper;
using Backend.Data;
using Backend.Models.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly KriptovaluteContext _context;
        private readonly IMapper _mapper;

        public FileController(KriptovaluteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<WalletDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var wallets = _context.Walleti.ToList();
                return Ok(_mapper.Map<List<WalletDTORead>>(wallets));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<WalletDTORead> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var wallet = _context.Walleti.Find(id);
                if (wallet == null)
                {
                    return NotFound(new { poruka = "Novčanik ne postoji" });
                }
                return Ok(_mapper.Map<WalletDTORead>(wallet));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post(WalletDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var wallet = _mapper.Map<Wallet>(dto);
                _context.Walleti.Add(wallet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<WalletDTORead>(wallet));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put(int id, WalletDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var wallet = _context.Walleti.Find(id);
                if (wallet == null)
                {
                    return NotFound(new { poruka = "Novčanik ne postoji" });
                }

                _mapper.Map(dto, wallet);
                _context.Walleti.Update(wallet);
                _context.SaveChanges();

                return Ok(new { poruka = "Novčanik uspješno ažuriran" });
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
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var wallet = _context.Walleti.Find(id);
                if (wallet == null)
                {
                    return NotFound(new { poruka = "Novčanik ne postoji" });
                }

                _context.Walleti.Remove(wallet);
                _context.SaveChanges();

                return Ok(new { poruka = "Novčanik uspješno obrisan" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}


