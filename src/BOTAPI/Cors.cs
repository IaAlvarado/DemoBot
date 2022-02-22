namespace BotApi.Cors;

public class CorsAspectDefinition
{
    private const string MyAllowSpecificOrigins = "BotApiCorsPolicy";

    public static void DefineAspect(IServiceCollection services, IConfiguration configuration)
    {

        services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));
    }

    public static void ConfigureAspect(WebApplication app)
    {
        app.UseCors(MyAllowSpecificOrigins);
    }
}