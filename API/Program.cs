using Abp.Events.Bus;
using API;
using API.Endpoints;
using API.Handlers;
using Data.Context;
using Data.Repository;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

builder.Services.AddDbContext<CentralDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("BASE_SQL")!,
               sqlServerOptionsAction: sqlOptions =>
               {
                   sqlOptions.EnableRetryOnFailure();
               });

});

builder.Services.AddCors(options => options.AddPolicy("PermitirApiRequest", builder => builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader()));


builder.Services.AddScoped(typeof(ICentralRepository), typeof(CentralRepository));
builder.Services.AddScoped(typeof(IUnitOfWorkCentral), typeof(UnitOfWorkCentral));

builder.Services.AddTransient<IIntegracaoService, IntegracaoService>();

builder.Services.AddTransient<ArquivoIntegrarWmsEventHandler>();


builder.Services.AddCors(options =>
options.AddPolicy("PermitirApiRequest", builder => builder.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader()));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "microservice-teste-bemobi V1",
            Version = "v1"
        });



    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    setup.IncludeXmlComments(xmlPath);


});


//builder.Services.AddJaegerTracing("microservice-teste-bemobi");

//builder.Services.AddRabbitMQ(
//    new RabbitMQueuedOptions(
//        Environment.GetEnvironmentVariable("MESSAGEQ_HOST"),
//        Environment.GetEnvironmentVariable("MESSAGEQ_USER"),
//        Environment.GetEnvironmentVariable("MESSAGEQ_PWD"),
//        retryCount: 5,
//        Environment.GetEnvironmentVariable("MESSAGEQ_CLIENT_NAME")));

var app = builder.Build();

//var eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<ArquivoEvent, ArquivoIntegrarWmsEventHandler>();


app.UseCors(builder => builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());


app.UseSwagger();
app.UseSwaggerUI(c =>
                 {
                     c.SwaggerEndpoint("/swagger/v1/swagger.json", "microservice-teste-bemobi V1");
                     c.DocExpansion(DocExpansion.List);
                 }
);

app.UseHttpsRedirection();





//Commands
app.MapMethods(IntegrarArquivo.Template, IntegrarArquivo.Methods, IntegrarArquivo.Handle);


app.Run();