
using Api.Helpers;
using AutoMapper;
using certs.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{

    public class CertificatesController : BaseApiController
    {

        private readonly IGenericRepository<Certificate> _certRepo;
        private readonly IGenericRepository<CertificateType> _certTypeRepo;
        private readonly IMapper _mapper;
        public CertificatesController(IGenericRepository<Certificate> certRepo,
            IGenericRepository<CertificateType> certTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _certRepo = certRepo;
            _certTypeRepo = certTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<CertificateToReturnDto>>> GetCertificates([FromQuery]CertificateSpecParams CertificateParams)
        {

            var spec = new CertificatesWithTypesSpecification(CertificateParams);

            var countSpec = new CertificateWithFiltersForCountSpecification(CertificateParams);
            var TotalItems = await _certRepo.CountAsync(countSpec);

            var certs = await _certRepo.ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<Certificate>, IReadOnlyList<CertificateToReturnDto>>(certs);

            return Ok(new Pagination<CertificateToReturnDto>(CertificateParams.PageIndex,
                CertificateParams.PageSize, TotalItems, data));

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateToReturnDto>> GetCertificates(int id)
        {

            var spec = new CertificatesWithTypesSpecification(id);

            var cert = await _certRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Certificate, CertificateToReturnDto>(cert);

        }

        [HttpGet("certstype")]

        public async Task<ActionResult<IReadOnlyList<CertificateType>>> GetCertificateType()
        {

            return Ok(await _certTypeRepo.ListAllAsync());

        }


    }
}
