
using Domain.DTO;
using System.Threading.Tasks;

namespace Domain.Interface.Service
{
    public interface IIntegracaoService
    {
        Task<bool> IntegrarArquivo(ArquivoIntegrarDTO arquivoIntegrarDTO);


    }
}
