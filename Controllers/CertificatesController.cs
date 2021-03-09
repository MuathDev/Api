
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CertificatesController : ControllerBase
    {

        private readonly ICertificateRepository _repo;
        public CertificatesController(ICertificateRepository repo)
        {
            _repo = repo;   
        }

        [HttpGet]
        public async Task<ActionResult<List<Certificate>>> GetCertificates()
        {

            var certs = await _repo.GetCertificatsAsync();

            return Ok(certs);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> GetCertificates(int id)
        {
            return await _repo.GetCertificateByIdAsync(id);
        }


    }
}
