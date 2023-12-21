using Proyecto_Cliente.Helpers;
using Proyecto_Cliente.Services;
using Proyecto_Cliente.Repositories;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(j => {

    j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    j.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

});

builder.Services.AddSingleton<DbContextData>();
builder.Services.AddScoped<Iclient, clientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager config = builder.Configuration;
AccesoDatos.cadenaConexion = config.GetConnectionString("connectionstr");

var app = builder.Build();

{
    using var appscope = app.Services.CreateScope();
    var context = appscope.ServiceProvider.GetRequiredService<DbContextData>();
    await context.Init();

}

//Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MiddlewareErrorHandler>();
app.MapControllers();

app.Run();