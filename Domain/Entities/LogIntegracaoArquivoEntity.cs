using System;

namespace Domain.Entities
{
    public class LogIntegracaoArquivoEntity
    {
        public int Log_Integracao_Arquivo_ID { get; set; }
        public string Filename { get; set; }
        public DateTime lastmodified { get; set; }
        public int Status { get; set; }

        public LogIntegracaoArquivoEntity()
        {
            lastmodified = DateTime.Now;
        }
    }
}
