namespace Domain.Entities
{
    public class ArquivoIntegracao
    {
        public ArquivoIntegracao()
        {
            arquivo = new Arquivo();
        }
        public string usuario { get; set; }
        public string senha { get; set; }
        public Arquivo arquivo { get; set; }
    }
}
