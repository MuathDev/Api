using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace certs.Dtos
{
    public class CertificateToReturnDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public string CertificateType { get; set; }

    }
}
