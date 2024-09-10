using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Personal_Assist_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do contexto para Oracle
builder.Services.AddDbContext<Contexto>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Adiciona servi�os ao cont�iner
builder.Services.AddControllers();

// Configura��o do Swagger para a documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Personal Assist API",
        Version = "v1",
        Description = "API para gerenciamento de empresas, servi�os, feedbacks e suporte no sistema Personal Assist.",
        Contact = new OpenApiContact
        {
            Name = "Equipe de Desenvolvimento",
            Email = "suporte@personalassist.com",
            Url = new Uri("https://example.com/")
        }
    });

    // Inclui os coment�rios XML se dispon�veis
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Personal Assist API v1");
        c.RoutePrefix = string.Empty; // Define a raiz para o Swagger UI
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
