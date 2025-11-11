using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using SolarBot.Models;
using Xunit;

namespace SolarBot.Tests;

public class PaineisSolaresControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;

    public PaineisSolaresControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    [Fact]
    public async Task GetPaineisSolares_DeveRetornarListaVazia_QuandoNaoHouverPaineis()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/paineis-solares");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var paineis = await response.Content.ReadFromJsonAsync<List<PainelSolar>>(_jsonOptions);
        Assert.NotNull(paineis);
    }

    [Fact]
    public async Task PostPainelSolar_DeveCriarNovoPainel_QuandoDadosValidos()
    {
        // Arrange
        var novoPainel = new PainelSolar
        {
            Nome = "Painel Teste 1",
            Localizacao = "São Paulo, SP",
            CapacidadeKW = 5.5m,
            GeracaoAtualKW = 4.2m,
            StatusOperacao = "Ativo"
        };

        var content = new StringContent(
            JsonSerializer.Serialize(novoPainel),
            Encoding.UTF8,
            "application/json");

        // Act
        var response = await _client.PostAsync("/api/v1/paineis-solares", content);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        var painelCriado = await response.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);
        Assert.NotNull(painelCriado);
        Assert.True(painelCriado.Id > 0);
        Assert.Equal(novoPainel.Nome, painelCriado.Nome);
        Assert.Equal(novoPainel.Localizacao, painelCriado.Localizacao);
        Assert.Equal(novoPainel.CapacidadeKW, painelCriado.CapacidadeKW);
        Assert.Equal(novoPainel.GeracaoAtualKW, painelCriado.GeracaoAtualKW);
        Assert.Equal(novoPainel.StatusOperacao, painelCriado.StatusOperacao);
    }

    [Fact]
    public async Task PostPainelSolar_DeveRetornarBadRequest_QuandoNomeVazio()
    {
        // Arrange
        var painelInvalido = new PainelSolar
        {
            Nome = "",
            Localizacao = "São Paulo, SP",
            CapacidadeKW = 5.5m,
            GeracaoAtualKW = 4.2m,
            StatusOperacao = "Ativo"
        };

        var content = new StringContent(
            JsonSerializer.Serialize(painelInvalido),
            Encoding.UTF8,
            "application/json");

        // Act
        var response = await _client.PostAsync("/api/v1/paineis-solares", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task PostPainelSolar_DeveRetornarBadRequest_QuandoLocalizacaoVazia()
    {
        // Arrange
        var painelInvalido = new PainelSolar
        {
            Nome = "Painel Teste",
            Localizacao = "",
            CapacidadeKW = 5.5m,
            GeracaoAtualKW = 4.2m,
            StatusOperacao = "Ativo"
        };

        var content = new StringContent(
            JsonSerializer.Serialize(painelInvalido),
            Encoding.UTF8,
            "application/json");

        // Act
        var response = await _client.PostAsync("/api/v1/paineis-solares", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetPainelSolarPorId_DeveRetornarPainel_QuandoExistir()
    {
        // Arrange - Primeiro criar um painel
        var novoPainel = new PainelSolar
        {
            Nome = "Painel Teste Get",
            Localizacao = "Rio de Janeiro, RJ",
            CapacidadeKW = 10.0m,
            GeracaoAtualKW = 8.5m,
            StatusOperacao = "Ativo"
        };

        var createContent = new StringContent(
            JsonSerializer.Serialize(novoPainel),
            Encoding.UTF8,
            "application/json");

        var createResponse = await _client.PostAsync("/api/v1/paineis-solares", createContent);
        var painelCriado = await createResponse.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);

        // Act
        var response = await _client.GetAsync($"/api/v1/paineis-solares/{painelCriado!.Id}");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var painel = await response.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);
        Assert.NotNull(painel);
        Assert.Equal(painelCriado.Id, painel.Id);
        Assert.Equal(novoPainel.Nome, painel.Nome);
    }

    [Fact]
    public async Task GetPainelSolarPorId_DeveRetornarNotFound_QuandoNaoExistir()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/paineis-solares/99999");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task PutPainelSolar_DeveAtualizarPainel_QuandoExistir()
    {
        // Arrange - Primeiro criar um painel
        var novoPainel = new PainelSolar
        {
            Nome = "Painel Teste Update",
            Localizacao = "Belo Horizonte, MG",
            CapacidadeKW = 8.0m,
            GeracaoAtualKW = 6.0m,
            StatusOperacao = "Ativo"
        };

        var createContent = new StringContent(
            JsonSerializer.Serialize(novoPainel),
            Encoding.UTF8,
            "application/json");

        var createResponse = await _client.PostAsync("/api/v1/paineis-solares", createContent);
        var painelCriado = await createResponse.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);

        // Act - Atualizar o painel
        painelCriado!.Nome = "Painel Teste Update Modificado";
        painelCriado.GeracaoAtualKW = 7.5m;

        var updateContent = new StringContent(
            JsonSerializer.Serialize(painelCriado),
            Encoding.UTF8,
            "application/json");

        var updateResponse = await _client.PutAsync($"/api/v1/paineis-solares/{painelCriado.Id}", updateContent);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);

        // Verificar se foi atualizado
        var getResponse = await _client.GetAsync($"/api/v1/paineis-solares/{painelCriado.Id}");
        var painelAtualizado = await getResponse.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);
        
        Assert.NotNull(painelAtualizado);
        Assert.Equal("Painel Teste Update Modificado", painelAtualizado.Nome);
        Assert.Equal(7.5m, painelAtualizado.GeracaoAtualKW);
    }

    [Fact]
    public async Task PutPainelSolar_DeveRetornarNotFound_QuandoNaoExistir()
    {
        // Arrange
        var painelInexistente = new PainelSolar
        {
            Id = 99999,
            Nome = "Painel Inexistente",
            Localizacao = "Inexistente",
            CapacidadeKW = 5.0m,
            GeracaoAtualKW = 3.0m,
            StatusOperacao = "Ativo"
        };

        var content = new StringContent(
            JsonSerializer.Serialize(painelInexistente),
            Encoding.UTF8,
            "application/json");

        // Act
        var response = await _client.PutAsync("/api/v1/paineis-solares/99999", content);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task PutPainelSolar_DeveRetornarBadRequest_QuandoIdsDiferentes()
    {
        // Arrange
        var painel = new PainelSolar
        {
            Id = 1,
            Nome = "Painel Teste",
            Localizacao = "São Paulo, SP",
            CapacidadeKW = 5.0m,
            GeracaoAtualKW = 3.0m,
            StatusOperacao = "Ativo"
        };

        var content = new StringContent(
            JsonSerializer.Serialize(painel),
            Encoding.UTF8,
            "application/json");

        // Act - ID na URL diferente do ID no corpo
        var response = await _client.PutAsync("/api/v1/paineis-solares/2", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DeletePainelSolar_DeveDeletarPainel_QuandoExistir()
    {
        // Arrange - Primeiro criar um painel
        var novoPainel = new PainelSolar
        {
            Nome = "Painel Teste Delete",
            Localizacao = "Salvador, BA",
            CapacidadeKW = 6.0m,
            GeracaoAtualKW = 4.5m,
            StatusOperacao = "Ativo"
        };

        var createContent = new StringContent(
            JsonSerializer.Serialize(novoPainel),
            Encoding.UTF8,
            "application/json");

        var createResponse = await _client.PostAsync("/api/v1/paineis-solares", createContent);
        var painelCriado = await createResponse.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);

        // Act - Deletar o painel
        var deleteResponse = await _client.DeleteAsync($"/api/v1/paineis-solares/{painelCriado!.Id}");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        // Verificar se foi deletado
        var getResponse = await _client.GetAsync($"/api/v1/paineis-solares/{painelCriado.Id}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task DeletePainelSolar_DeveRetornarNotFound_QuandoNaoExistir()
    {
        // Act
        var response = await _client.DeleteAsync("/api/v1/paineis-solares/99999");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetEstatisticas_DeveRetornarEstatisticas_ComDadosCorretos()
    {
        // Arrange - Criar alguns painéis para calcular estatísticas
        var paineis = new[]
        {
            new PainelSolar
            {
                Nome = "Painel Estatística 1",
                Localizacao = "São Paulo, SP",
                CapacidadeKW = 10.0m,
                GeracaoAtualKW = 8.0m,
                StatusOperacao = "Ativo"
            },
            new PainelSolar
            {
                Nome = "Painel Estatística 2",
                Localizacao = "Rio de Janeiro, RJ",
                CapacidadeKW = 15.0m,
                GeracaoAtualKW = 12.0m,
                StatusOperacao = "Ativo"
            },
            new PainelSolar
            {
                Nome = "Painel Estatística 3",
                Localizacao = "Belo Horizonte, MG",
                CapacidadeKW = 5.0m,
                GeracaoAtualKW = 0.0m,
                StatusOperacao = "Manutencao"
            }
        };

        foreach (var painel in paineis)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(painel),
                Encoding.UTF8,
                "application/json");
            await _client.PostAsync("/api/v1/paineis-solares", content);
        }

        // Act
        var response = await _client.GetAsync("/api/v1/paineis-solares/estatisticas");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var estatisticas = JsonSerializer.Deserialize<JsonElement>(responseContent, _jsonOptions);
        
        Assert.True(estatisticas.GetProperty("totalPaineis").GetInt32() >= 3);
        Assert.True(estatisticas.GetProperty("paineisAtivos").GetInt32() >= 2);
        Assert.True(estatisticas.GetProperty("paineisEmManutencao").GetInt32() >= 1);
        Assert.True(estatisticas.GetProperty("capacidadeTotalKW").GetDecimal() >= 30.0m);
    }

    [Fact]
    public async Task GetEstatisticas_DeveRetornarZeros_QuandoNaoHouverPaineis()
    {
        // Arrange - Limpar todos os painéis (se houver)
        var allPaineisResponse = await _client.GetAsync("/api/v1/paineis-solares");
        var allPaineis = await allPaineisResponse.Content.ReadFromJsonAsync<List<PainelSolar>>(_jsonOptions);
        
        if (allPaineis != null)
        {
            foreach (var painel in allPaineis)
            {
                await _client.DeleteAsync($"/api/v1/paineis-solares/{painel.Id}");
            }
        }

        // Act
        var response = await _client.GetAsync("/api/v1/paineis-solares/estatisticas");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var estatisticas = JsonSerializer.Deserialize<JsonElement>(responseContent, _jsonOptions);
        
        Assert.Equal(0, estatisticas.GetProperty("totalPaineis").GetInt32());
        Assert.Equal(0, estatisticas.GetProperty("paineisAtivos").GetInt32());
        Assert.Equal(0, estatisticas.GetProperty("paineisInativos").GetInt32());
        Assert.Equal(0, estatisticas.GetProperty("paineisEmManutencao").GetInt32());
    }

    [Fact]
    public async Task FluxoCompleto_CriarListarAtualizarDeletar_DeveExecutarComSucesso()
    {
        // 1. Criar um painel
        var novoPainel = new PainelSolar
        {
            Nome = "Painel Fluxo Completo",
            Localizacao = "Brasília, DF",
            CapacidadeKW = 12.0m,
            GeracaoAtualKW = 10.0m,
            StatusOperacao = "Ativo"
        };

        var createContent = new StringContent(
            JsonSerializer.Serialize(novoPainel),
            Encoding.UTF8,
            "application/json");

        var createResponse = await _client.PostAsync("/api/v1/paineis-solares", createContent);
        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
        
        var painelCriado = await createResponse.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);
        Assert.NotNull(painelCriado);
        var painelId = painelCriado.Id;

        // 2. Buscar o painel por ID
        var getResponse = await _client.GetAsync($"/api/v1/paineis-solares/{painelId}");
        Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

        // 3. Listar todos os painéis (deve conter o criado)
        var listResponse = await _client.GetAsync("/api/v1/paineis-solares");
        Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);
        
        var listaPaineis = await listResponse.Content.ReadFromJsonAsync<List<PainelSolar>>(_jsonOptions);
        Assert.NotNull(listaPaineis);
        Assert.Contains(listaPaineis, p => p.Id == painelId);

        // 4. Atualizar o painel
        painelCriado.Nome = "Painel Fluxo Completo - Atualizado";
        painelCriado.StatusOperacao = "Manutencao";
        
        var updateContent = new StringContent(
            JsonSerializer.Serialize(painelCriado),
            Encoding.UTF8,
            "application/json");

        var updateResponse = await _client.PutAsync($"/api/v1/paineis-solares/{painelId}", updateContent);
        Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);

        // 5. Verificar se foi atualizado
        var getUpdatedResponse = await _client.GetAsync($"/api/v1/paineis-solares/{painelId}");
        var painelAtualizado = await getUpdatedResponse.Content.ReadFromJsonAsync<PainelSolar>(_jsonOptions);
        Assert.NotNull(painelAtualizado);
        Assert.Equal("Painel Fluxo Completo - Atualizado", painelAtualizado.Nome);
        Assert.Equal("Manutencao", painelAtualizado.StatusOperacao);

        // 6. Deletar o painel
        var deleteResponse = await _client.DeleteAsync($"/api/v1/paineis-solares/{painelId}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        // 7. Verificar se foi deletado
        var getDeletedResponse = await _client.GetAsync($"/api/v1/paineis-solares/{painelId}");
        Assert.Equal(HttpStatusCode.NotFound, getDeletedResponse.StatusCode);
    }
}

