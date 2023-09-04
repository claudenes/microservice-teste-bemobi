using System.Text.Json;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System.Threading.Tasks;
using Domain.DTO;
using System;

namespace Service
{
    public class IntegracaoService : IIntegracaoService
    {
        private readonly ICentralRepository _centralRepository;


        public IntegracaoService(
            ICentralRepository centralRepository)
        {
            _centralRepository = centralRepository;
        }

        public async Task<bool> IntegrarArquivo(ArquivoIntegrarDTO arquivodto)
        {
            var arquivo = new ArquivoIntegracaoDTO();
            arquivo.usuario = Environment.GetEnvironmentVariable("USUARIO_SENIOR");
            arquivo.senha = Environment.GetEnvironmentVariable("SENHA_SENIOR");

            arquivo.arquivo = await _centralRepository.GetArquivo(arquivodto.filename.ToString());

            var json = JsonSerializer.Serialize(arquivo);
            //Enviar para fila
            await HttpClientIntegracaoHelper.PostAsync<ArquivoIntegrarDTO>(json, "entrada/arquivo");

            return true;
        }
    }
}