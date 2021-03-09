
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CertificatesController : ControllerBase
    {

        private readonly StoreContext _context;
        public CertificatesController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Certificate>>> GetCertificates()
        {

            var certs = await _context.Certificates.ToListAsync();

            return Ok(certs);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> GetCertificates(int id)
        {
            return await _context.Certificates.FindAsync(id);
        }


    }
}
