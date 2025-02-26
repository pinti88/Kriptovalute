using AutoMapper;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class BackendController : ControllerBase
    {

        // dependecy injection
        // 1. definiraš privatno svojstvo
        protected readonly KriptovaluteContext _context;

        protected readonly IMapper _mapper;


        // dependecy injection
        // 2. proslijediš instancu kroz konstruktor
        public BackendController(KriptovaluteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
