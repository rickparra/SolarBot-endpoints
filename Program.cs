using SolarBot.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SolarBot API",
        Version = "v1",
        Description = "API RESTful para Monitoramento e Consulta de Placas Solares"
    });
    
    // Incluir comentários XML (opcional, mas ajuda na documentação)
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Registrar o serviço LiteDB
builder.Services.AddScoped<IPainelSolarService, PainelSolarService>();

var app = builder.Build();

// === TESTE DIRETO DO SERVIÇO ===
try
{
    using var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<IPainelSolarService>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    
    logger.LogInformation("===== TESTE DIRETO DO SERVIÇO =====");
    
    var painelTeste = new SolarBot.Models.PainelSolar
    {
        Id = 0,
        Nome = "Painel Teste Direto",
        Localizacao = "São Paulo, SP",
        CapacidadeKW = 10.0m,
        GeracaoAtualKW = 5.0m,
        StatusOperacao = "Ativo",
        DataInstalacao = DateTime.UtcNow,
        DataUltimaAtualizacao = DateTime.UtcNow
    };
    
    logger.LogInformation("Tentando criar painel...");
    var painelCriado = await service.CriarAsync(painelTeste);
    logger.LogInformation($"✓ Painel criado com sucesso! ID: {painelCriado.Id}");
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, $"✗ ERRO no teste direto: {ex.Message}");
    logger.LogError($"Inner: {ex.InnerException?.Message}");
    logger.LogError($"Stack: {ex.StackTrace}");
}
// === FIM DO TESTE ===

// Configurar o pipeline HTTP
// Habilitar página de exceção de desenvolvedor para ver erros detalhados
app.UseDeveloperExceptionPage();

// Habilitar Swagger sempre (não apenas em Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolarBot API v1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Tornar a classe Program visível para os testes de integração
public partial class Program { }
