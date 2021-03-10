
using AutoMapper;
using certs.Dtos;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace certs.Helpers
{
    public class CertificateUrlResolver : IValueResolver<Certificate, CertificateToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public CertificateUrlResolver(IConfiguration config)
        {

            _config = config;

        }
        public string Resolve(Certificate source, CertificateToReturnDto destination, string destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;

        }
    }
}
