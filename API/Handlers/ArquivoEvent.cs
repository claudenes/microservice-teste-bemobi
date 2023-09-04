using Domain.DTO;
using RabbitMQ.Client;

namespace API.Handlers
{
    public class ArquivoEvent
    {

    
        public ArquivoIntegrarDTO ArquivoIntegrar { get; set; }

        //public ArquivoEvent(ArquivoIntegrarDTO dto)
        //{
        //    ArquivoIntegrar = dto;

        //    ExchangeName = "ArquivoIntegracaoWms";
        //    ExchangeType = "direct";
        //    QueueName = "ArquivoEvent";

        //}
    }
}
