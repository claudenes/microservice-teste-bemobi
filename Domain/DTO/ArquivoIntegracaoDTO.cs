using Domain.Entities;

namespace Domain.DTO
{
    public class ArquivoIntegracaoDTO
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public Arquivo arquivo { get; set; }

        public ArquivoIntegracaoDTO()
        {
            arquivo = new Arquivo();
        }
    }

}
