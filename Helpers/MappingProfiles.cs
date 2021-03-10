using AutoMapper;
using certs.Dtos;
using Core.Entities;

namespace certs.Helpers
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Certificate, CertificateToReturnDto>()
                .ForMember(d => d.CertificateType, o => o.MapFrom(s => s.CertificateType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<CertificateUrlResolver>());
        }

    }
}
