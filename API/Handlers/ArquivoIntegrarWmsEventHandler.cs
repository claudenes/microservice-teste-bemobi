using Domain.Interface.Service;
using OpenTracing;
using System.Text.Json;

namespace API.Handlers
{
    public class ArquivoIntegrarWmsEventHandler
    {
        private readonly IIntegracaoService _integracaoService;
        private readonly ILogger<ArquivoIntegrarWmsEventHandler> _logger;

        //public ArquivoIntegrarWmsEventHandler(
        //    IIntegracaoService integracaoService,
        //    ILogger<ArquivoIntegrarWmsEventHandler> logger,
        //    ITracer tracer)
        //    : base(tracer)
        //{
        //    _integracaoService = integracaoService;
        //    _logger = logger;
        //}

        //public async override Task Handle(ArquivoEvent @event)
        //{
        //    string output = JsonSerializer.Serialize(@event);
        //    _logger.LogInformation($"Reading {@event.QueueName} queue. Values \n {output}");
        //    await _integracaoService.IntegrarArquivo(@event.ArquivoIntegrar);
        //}
    }
}
