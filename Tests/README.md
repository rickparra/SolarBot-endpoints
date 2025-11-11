# 🧪 Testes Automatizados - SolarBot

Este diretório contém os testes automatizados da API SolarBot.

## 📋 Sobre os Testes

Os testes são implementados usando:
- **xUnit** - Framework de testes para .NET
- **Microsoft.AspNetCore.Mvc.Testing** - Para testes de integração da API

## 🎯 Cobertura dos Testes

Os testes cobrem todos os endpoints da API:

### ✅ Testes Implementados

1. **GET /api/v1/paineis-solares**
   - ✅ Listar todos os painéis (inclusive quando vazio)

2. **GET /api/v1/paineis-solares/{id}**
   - ✅ Buscar painel existente por ID
   - ✅ Retornar 404 quando painel não existe

3. **POST /api/v1/paineis-solares**
   - ✅ Criar novo painel com dados válidos
   - ✅ Retornar erro quando nome vazio
   - ✅ Retornar erro quando localização vazia

4. **PUT /api/v1/paineis-solares/{id}**
   - ✅ Atualizar painel existente
   - ✅ Retornar 404 quando painel não existe
   - ✅ Retornar erro quando IDs não correspondem

5. **DELETE /api/v1/paineis-solares/{id}**
   - ✅ Deletar painel existente
   - ✅ Retornar 404 quando painel não existe

6. **GET /api/v1/paineis-solares/estatisticas**
   - ✅ Retornar estatísticas corretas
   - ✅ Retornar zeros quando não há painéis

7. **Teste de Fluxo Completo**
   - ✅ Criar → Listar → Buscar → Atualizar → Deletar

## 🚀 Como Executar os Testes

### ⚠️ IMPORTANTE: Feche a aplicação antes de executar os testes

Se a aplicação SolarBot estiver rodando, **PARE-A primeiro** antes de executar os testes. Os testes criam uma instância própria da aplicação.

### Opção 1: Executar Todos os Testes

```bash
cd Tests
dotnet test
```

Ou do diretório raiz:

```bash
dotnet test Tests/SolarBot.Tests.csproj
```

### Opção 2: Executar com Saída Detalhada

```bash
cd Tests
dotnet test --verbosity detailed
```

### Opção 3: Executar com Cobertura de Código

```bash
cd Tests
dotnet test --collect:"XPlat Code Coverage"
```

### Opção 4: Executar um Teste Específico

```bash
cd Tests
dotnet test --filter "FullyQualifiedName~PaineisSolaresControllerTests.GetPaineisSolares_DeveRetornarListaVazia_QuandoNaoHouverPaineis"
```

## 📊 Estrutura dos Testes

```
Tests/
├── PaineisSolaresControllerTests.cs  # Testes de integração dos endpoints
├── SolarBot.Tests.csproj             # Arquivo de projeto dos testes
└── README.md                         # Este arquivo
```

## 🔍 Tipos de Testes

### Testes de Integração

Os testes implementados são **testes de integração**, que:
- ✅ Testam a API completa (Controllers + Services + Banco de Dados)
- ✅ Fazem requisições HTTP reais
- ✅ Verificam status codes, headers e respostas
- ✅ Usam um banco de dados de teste (LiteDB)

### Características dos Testes

- **Isolados**: Cada teste é independente
- **Rápidos**: Executam em milissegundos
- **Confiáveis**: Sempre produzem o mesmo resultado
- **Completos**: Cobrem cenários positivos e negativos

## 📝 Exemplo de Saída dos Testes

```
Iniciando execução de teste, aguarde...
Concluído em 2,5s

Aprovado!  – Com falha:     0, Aprovado:    16, Ignorado:     0, Total:    16, Duração: 2,5 s
```

## 🛠️ Adicionar Novos Testes

Para adicionar novos testes:

1. Abra o arquivo `PaineisSolaresControllerTests.cs`
2. Adicione um novo método de teste com o atributo `[Fact]`
3. Siga o padrão **Arrange-Act-Assert**:

```csharp
[Fact]
public async Task NomeDoTeste_DeveComportamento_QuandoCondicao()
{
    // Arrange - Preparar os dados
    var dados = new PainelSolar { /* ... */ };
    
    // Act - Executar a ação
    var response = await _client.PostAsync("/api/v1/paineis-solares", content);
    
    // Assert - Verificar o resultado
    Assert.Equal(HttpStatusCode.Created, response.StatusCode);
}
```

## 📦 Dependências

As dependências dos testes estão no arquivo `SolarBot.Tests.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.13.0" />
  <PackageReference Include="xunit" Version="2.9.2" />
  <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2" />
  <PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="9.0.10" />
</ItemGroup>
```

## 🎓 Boas Práticas Aplicadas

1. ✅ **Nomenclatura clara**: Nome do método indica o que está sendo testado
2. ✅ **Padrão AAA**: Arrange, Act, Assert
3. ✅ **Testes independentes**: Não dependem da ordem de execução
4. ✅ **Cenários positivos e negativos**: Testa sucesso e falhas
5. ✅ **Mensagens de erro claras**: Fácil identificar o que falhou
6. ✅ **Cobertura completa**: Todos os endpoints testados

## 🔧 Solução de Problemas

### Problema: Testes falhando por conflito de porta

**Solução**: A API de teste usa uma porta aleatória, então isso não deve ocorrer.

### Problema: Testes falhando por banco de dados

**Solução**: Cada execução de teste cria um novo banco LiteDB em memória, então não há conflito.

### Problema: Erro "Program class not found"

**Solução**: Certifique-se de que o arquivo `Program.cs` contém:

```csharp
public partial class Program { }
```

## 📚 Recursos Adicionais

- [Documentação xUnit](https://xunit.net/)
- [ASP.NET Core Testing](https://docs.microsoft.com/aspnet/core/test/integration-tests)
- [Best Practices for Unit Testing](https://docs.microsoft.com/dotnet/core/testing/unit-testing-best-practices)

## ✨ Próximos Passos

Possíveis melhorias futuras:

- [ ] Adicionar testes de performance
- [ ] Implementar mocks para o banco de dados
- [ ] Adicionar testes de carga
- [ ] Configurar CI/CD para executar testes automaticamente
- [ ] Adicionar relatórios de cobertura de código

---

**Desenvolvido com ❤️ para garantir a qualidade do SolarBot**

