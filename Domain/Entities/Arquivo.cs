using System;

namespace Domain.Entities
{
    public class Arquivo
    {
        public string filename { get; set; }
        public long filesize { get; set; }
        public DateTime lastmodified { get; set; }
    }
}
