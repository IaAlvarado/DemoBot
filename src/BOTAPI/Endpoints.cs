using System.Text.Json;
using System.Net.Http;
using Twilio;
using Microsoft.AspNetCore.Mvc;
namespace BotApi.Endpoints;
public record IncommingElements(string AccountSid, string ApiVersion, string Body, string From, string MessageSid, int NumMedia,int NumSegments, string ProfileName, string SmsMessageSid, string SmsStatus, string To, string Wald);
public class BotApiEndpointsDefinition
{
    public static void DefineServices(IServiceCollection services)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        services.AddHttpClient();
    }    
    public static void DefineEndpoints(WebApplication app)
    {   
        app.MapGet("", () => {Console.WriteLine("HOLA"); return"BIENVENIDO";});
        app.MapPost("/message", OnMessage);
    }

    
    [Consumes("application/x-www-form-urlencoded")]
    public static void OnMessage([FromForm]string form)
    {
        var json = JsonSerializer.Deserialize<FormCollection>(form);
        Console.WriteLine(form);
    }

}
