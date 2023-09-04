using Domain.DTO;
using Domain.Interface.Service;

namespace API.Endpoints
{
    public class IntegrarArquivo
    {
        public static string Template => "/arquivo";
        public static string[] Methods => new[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static async Task<IResult> Action(ArquivoIntegrarDTO arquivo,
                                                 IIntegracaoService service)
        {
            try
            {
                var ret = await service.IntegrarArquivo(arquivo);
                return Results.Ok(ret);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Mensagem = $"Erro ao tentar integrar Arquivo: {ex.Message}"
                });

            }
        }
    }
}
