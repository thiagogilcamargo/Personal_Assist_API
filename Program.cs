using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Personal_Assist_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do contexto para Oracle
builder.Services.AddDbContext<Contexto>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Adiciona serviços ao contêiner
builder.Services.AddControllers();

// Configuração do Swagger para a documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Personal Assist API",
        Version = "v1",
        Description = "API para gerenciamento de empresas, serviços, feedbacks e suporte no sistema Personal Assist.",
        Contact = new OpenApiContact
        {
            Name = "Equipe de Desenvolvimento",
            Email = "suporte@personalassist.com",
            Url = new Uri("https://example.com/")
        }
    });

    // Inclui os comentários XML se disponíveis
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configura o pipeline de requisições HTTP
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
