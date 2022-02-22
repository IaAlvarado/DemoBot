using BotApi.Endpoints;
using BotApi.Cors;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
CorsAspectDefinition.DefineAspect(builder.Services, builder.Configuration);
BotApiEndpointsDefinition.DefineServices(builder.Services);

var app = builder.Build();

BotApiEndpointsDefinition.DefineEndpoints(app);
CorsAspectDefinition.ConfigureAspect(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

