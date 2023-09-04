using System;

namespace Domain.DTO
{
    public class ArquivoIntegrarDTO
    {
        public string filename { get; set; }
        public DateTime lastmodified { get; set; }
        public long filesize { get; set; }
    }
}
