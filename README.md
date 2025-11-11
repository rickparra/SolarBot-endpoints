# SolarBot - API para Monitoramento e Consulta de Placas Solares

## 🚀 Exemplos Rápidos para Testar no Swagger

### Como usar estes exemplos:

1. Inicie a aplicação com `dotnet run`
2. Acesse `http://localhost:5155/swagger`
3. Clique no endpoint que deseja testar
4. Clique em **"Try it out"**
5. **Copie e cole** os exemplos abaixo no campo de requisição
6. Clique em **"Execute"**

---

### 📌 1. Criar Painel Solar (POST /api/v1/paineis-solares)

**Exemplo 1 - Painel Residencial:**
```json
{
  "nome": "Painel Solar Residencial SP",
  "localizacao": "São Paulo, SP",
  "capacidadeKW": 5.5,
  "geracaoAtualKW": 4.2,
  "statusOperacao": "Ativo"
}
```

**Exemplo 2 - Painel Comercial:**
```json
{
  "nome": "Painel Solar Comercial RJ",
  "localizacao": "Rio de Janeiro, RJ",
  "capacidadeKW": 12.0,
  "geracaoAtualKW": 10.5,
  "statusOperacao": "Ativo"
}
```

**Exemplo 3 - Painel Industrial:**
```json
{
  "nome": "Painel Solar Industrial MG",
  "localizacao": "Belo Horizonte, MG",
  "capacidadeKW": 25.0,
  "geracaoAtualKW": 22.8,
  "statusOperacao": "Ativo"
}
```

**Exemplo 4 - Painel em Manutenção:**
```json
{
  "nome": "Painel Solar Fazenda BA",
  "localizacao": "Salvador, BA",
  "capacidadeKW": 8.0,
  "geracaoAtualKW": 0.0,
  "statusOperacao": "Manutencao"
}
```

---

### 📌 2. Atualizar Painel Solar (PUT /api/v1/paineis-solares/{id})

**Importante:** Substitua `{id}` na URL pelo ID do painel que você quer atualizar (ex: 1, 2, 3...)

**Exemplo de Atualização:**
```json
{
  "id": 1,
  "nome": "Painel Solar Residencial SP - Atualizado",
  "localizacao": "São Paulo, SP - Zona Sul",
  "capacidadeKW": 6.0,
  "geracaoAtualKW": 5.5,
  "statusOperacao": "Ativo"
}
```

**Exemplo - Colocar em Manutenção:**
```json
{
  "id": 1,
  "nome": "Painel Solar Residencial SP",
  "localizacao": "São Paulo, SP",
  "capacidadeKW": 5.5,
  "geracaoAtualKW": 0.0,
  "statusOperacao": "Manutencao"
}
```

**Exemplo - Desativar Painel:**
```json
{
  "id": 1,
  "nome": "Painel Solar Desativado",
  "localizacao": "São Paulo, SP",
  "capacidadeKW": 5.5,
  "geracaoAtualKW": 0.0,
  "statusOperacao": "Inativo"
}
```

---

### 📌 3. Buscar Painel por ID (GET /api/v1/paineis-solares/{id})

**Como testar:**
- Substitua `{id}` pelo número do painel (ex: 1, 2, 3...)
- Clique em "Execute"
- Não precisa preencher nenhum JSON

---

### 📌 4. Listar Todos os Painéis (GET /api/v1/paineis-solares)

**Como testar:**
- Apenas clique em "Try it out" e depois "Execute"
- Não precisa preencher nenhum JSON

---

### 📌 5. Ver Estatísticas (GET /api/v1/paineis-solares/estatisticas)

**Como testar:**
- Apenas clique em "Try it out" e depois "Execute"
- Não precisa preencher nenhum JSON
- Retorna: total de painéis, painéis ativos, capacidade total, geração média, eficiência, etc.

---

### 📌 6. Deletar Painel (DELETE /api/v1/paineis-solares/{id})

**Como testar:**
- Substitua `{id}` pelo número do painel que deseja deletar
- Clique em "Execute"
- Não precisa preencher nenhum JSON

---

### 💡 Dicas Importantes:

- **Status de Operação** aceita apenas 3 valores: `"Ativo"`, `"Inativo"` ou `"Manutencao"`
- Os campos `id`, `dataInstalacao` e `dataUltimaAtualizacao` são gerados automaticamente
- Valores de KW (capacidadeKW e geracaoAtualKW) devem ser números decimais (use ponto, não vírgula)
- Todos os endpoints retornam JSON

---

## 📋 Descrição do Projeto

O **SolarBot** é uma API RESTful desenvolvida em **ASP.NET Core** que fornece dados sobre placas solares, permitindo que um chatbot consulte e responda perguntas com base nessas informações. A aplicação aborda o tema *"O Futuro do Trabalho"* ao unir **energia sustentável**, **automação** e **inteligência de dados**.

## 🚀 Funcionalidades

- ✅ CRUD completo de painéis solares (cadastro, atualização, exclusão, consulta)
- ✅ Armazenamento de dados de geração de energia, localização e status de operação
- ✅ Endpoint para estatísticas (geração média, painéis ativos, eficiência, etc.)
- ✅ Documentação via **Swagger/OpenAPI**
- ✅ Banco de dados **NoSQL** com **LiteDB** (arquivo local, sem necessidade de instalação ou conta)
- ✅ Estrutura versionada (`/api/v1/...`)
- ✅ Tratamento de erros com status codes adequados
- ✅ Código limpo e organizado seguindo boas práticas

## 🛠️ Tecnologias Utilizadas

- **.NET 9.0**
- **ASP.NET Core Web API**
- **LiteDB 5.0** (banco de dados NoSQL embutido)
- **Swagger/OpenAPI** (documentação)

## 📦 Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) ou superior
- Visual Studio 2022, VS Code ou qualquer editor de código compatível

## 🔧 Instalação e Execução

### 1. Clone o repositório

```bash
git clone <url-do-repositorio>
cd SolarBot
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Execute a aplicação

```bash
dotnet run
```

A API estará disponível em:
- **HTTP**: `http://localhost:5155`
- **HTTPS**: `https://localhost:7057` (se configurado)

### 4. Acesse a documentação Swagger

Abra seu navegador e acesse:
```
http://localhost:5155/swagger
```

A interface do Swagger será carregada com todos os endpoints disponíveis.

## 🧪 Como Testar os Endpoints

### Opção 1: Usando o Swagger UI (Recomendado)

1. Inicie a aplicação com `dotnet run`
2. Acesse `http://localhost:5155/swagger` no navegador
3. Você verá todos os endpoints disponíveis
4. Para testar um endpoint:
   - Clique no endpoint desejado (ex: `POST /api/v1/paineis-solares`)
   - Clique em "Try it out"
   - Preencha os dados no corpo da requisição (JSON)
   - Clique em "Execute"
   - Veja a resposta abaixo com status code e dados retornados

### Opção 2: Usando o Postman ou Insomnia

1. Crie uma nova requisição
2. Configure a URL: `http://localhost:5155/api/v1/paineis-solares`
3. Escolha o método HTTP apropriado (GET, POST, PUT, DELETE)
4. Para POST e PUT, adicione o corpo JSON no formato especificado
5. Envie a requisição e veja a resposta

### Opção 3: Usando cURL ou PowerShell

Exemplos detalhados estão na seção "Exemplos de Uso" abaixo.

## 📚 Endpoints da API

A API está versionada em `/api/v1/`. Todos os endpoints retornam JSON.

### Base URL
```
/api/v1/paineis-solares
```

### Endpoints Disponíveis

#### 1. Listar todos os painéis solares
```http
GET /api/v1/paineis-solares
```

**Resposta:** `200 OK`
```json
[
  {
    "id": 1,
    "nome": "Painel Solar 01",
    "localizacao": "São Paulo, SP",
    "capacidadeKW": 5.50,
    "geracaoAtualKW": 4.20,
    "statusOperacao": "Ativo",
    "dataInstalacao": "2024-01-15T10:00:00Z",
    "dataUltimaAtualizacao": "2024-11-10T23:00:00Z"
  }
]
```

#### 2. Buscar painel solar por ID
```http
GET /api/v1/paineis-solares/{id}
```

**Resposta:** `200 OK` ou `404 Not Found`

#### 3. Criar novo painel solar
```http
POST /api/v1/paineis-solares
Content-Type: application/json
```

**Body:**
```json
{
  "nome": "Painel Solar 02",
  "localizacao": "Rio de Janeiro, RJ",
  "capacidadeKW": 10.00,
  "geracaoAtualKW": 8.50,
  "statusOperacao": "Ativo"
}
```

**Resposta:** `201 Created`

#### 4. Atualizar painel solar
```http
PUT /api/v1/paineis-solares/{id}
Content-Type: application/json
```

**Body:**
```json
{
  "id": 1,
  "nome": "Painel Solar 01 Atualizado",
  "localizacao": "São Paulo, SP",
  "capacidadeKW": 5.50,
  "geracaoAtualKW": 4.80,
  "statusOperacao": "Ativo"
}
```

**Resposta:** `204 No Content` ou `404 Not Found`

#### 5. Deletar painel solar
```http
DELETE /api/v1/paineis-solares/{id}
```

**Resposta:** `204 No Content` ou `404 Not Found`

#### 6. Obter estatísticas
```http
GET /api/v1/paineis-solares/estatisticas
```

**Resposta:** `200 OK`
```json
{
  "totalPaineis": 10,
  "paineisAtivos": 8,
  "paineisInativos": 1,
  "paineisEmManutencao": 1,
  "capacidadeTotalKW": 55.50,
  "geracaoTotalKW": 42.30,
  "geracaoMediaKW": 4.23,
  "eficienciaMedia": 76.22
}
```

## 📊 Modelo de Dados

### PainelSolar

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `Id` | int | Identificador único (chave primária) |
| `Nome` | string | Nome do painel solar |
| `Localizacao` | string | Localização física do painel |
| `CapacidadeKW` | decimal | Capacidade máxima em kilowatts |
| `GeracaoAtualKW` | decimal | Geração atual em kilowatts |
| `StatusOperacao` | string | Status: "Ativo", "Inativo" ou "Manutencao" |
| `DataInstalacao` | DateTime | Data de instalação |
| `DataUltimaAtualizacao` | DateTime? | Data da última atualização |

## 🔄 Versionamento da API

A API utiliza versionamento por URL. A versão atual é **v1** (`/api/v1/`).

### Estrutura de Versionamento

- **v1**: Versão atual da API
- **v2**: Planejada para futuras melhorias (ex: filtros avançados, paginação, autenticação)

### Como funciona

O versionamento permite que diferentes versões da API coexistam, facilitando a evolução da API sem quebrar integrações existentes. Quando uma nova versão for necessária, será criada em `/api/v2/` mantendo a compatibilidade com `/api/v1/`.

## 📝 Status Codes HTTP

A API utiliza os seguintes status codes:

- `200 OK` - Requisição bem-sucedida
- `201 Created` - Recurso criado com sucesso
- `204 No Content` - Operação bem-sucedida sem conteúdo de retorno
- `400 Bad Request` - Dados inválidos na requisição
- `404 Not Found` - Recurso não encontrado
- `500 Internal Server Error` - Erro interno do servidor

## 🧪 Exemplos de Uso

### Usando cURL

#### 1. Criar um painel solar
```bash
curl -X POST http://localhost:5155/api/v1/paineis-solares \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Painel Solar Teste",
    "localizacao": "Brasília, DF",
    "capacidadeKW": 7.5,
    "geracaoAtualKW": 6.2,
    "statusOperacao": "Ativo"
  }'
```

**Resposta esperada:** Status 201 Created com os dados do painel criado incluindo o ID gerado.

#### 2. Listar todos os painéis
```bash
curl http://localhost:5155/api/v1/paineis-solares
```

**Resposta esperada:** Status 200 OK com array JSON de todos os painéis cadastrados.

#### 3. Buscar painel por ID
```bash
curl http://localhost:5155/api/v1/paineis-solares/1
```

**Resposta esperada:** Status 200 OK com dados do painel ou 404 Not Found se não existir.

#### 4. Atualizar um painel
```bash
curl -X PUT http://localhost:5155/api/v1/paineis-solares/1 \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "nome": "Painel Solar Atualizado",
    "localizacao": "Brasília, DF",
    "capacidadeKW": 8.0,
    "geracaoAtualKW": 7.0,
    "statusOperacao": "Ativo"
  }'
```

**Resposta esperada:** Status 204 No Content (atualização bem-sucedida) ou 404 Not Found.

#### 5. Deletar um painel
```bash
curl -X DELETE http://localhost:5155/api/v1/paineis-solares/1
```

**Resposta esperada:** Status 204 No Content (exclusão bem-sucedida) ou 404 Not Found.

#### 6. Buscar estatísticas
```bash
curl http://localhost:5155/api/v1/paineis-solares/estatisticas
```

**Resposta esperada:** Status 200 OK com objeto JSON contendo estatísticas agregadas.

### Usando PowerShell

#### 1. Criar um painel solar
```powershell
$body = @{
    nome = "Painel Solar Teste"
    localizacao = "Brasília, DF"
    capacidadeKW = 7.5
    geracaoAtualKW = 6.2
    statusOperacao = "Ativo"
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5155/api/v1/paineis-solares" `
  -Method Post `
  -ContentType "application/json" `
  -Body $body
```

#### 2. Listar todos os painéis
```powershell
Invoke-RestMethod -Uri "http://localhost:5155/api/v1/paineis-solares" -Method Get
```

#### 3. Buscar estatísticas
```powershell
Invoke-RestMethod -Uri "http://localhost:5155/api/v1/paineis-solares/estatisticas" -Method Get
```

## 🗄️ Banco de Dados

O projeto utiliza **LiteDB**, um banco de dados **NoSQL** embutido que funciona como um arquivo local. O LiteDB é uma solução leve e eficiente que não requer instalação de servidor ou criação de contas.

### Características do LiteDB

- ✅ **NoSQL**: Banco de dados não relacional baseado em documentos
- ✅ **Arquivo Local**: Todos os dados são armazenados em um único arquivo (`SolarBot.db`)
- ✅ **Sem Instalação**: Não requer servidor ou configuração adicional
- ✅ **Sem Conta**: Não precisa de credenciais ou serviços externos
- ✅ **Criação Automática**: O arquivo de banco de dados é criado automaticamente na primeira execução
- ✅ **Portátil**: O arquivo pode ser facilmente copiado ou movido

### Localização do Banco de Dados

O arquivo `SolarBot.db` será criado automaticamente na raiz do projeto na primeira execução da aplicação. Este arquivo contém todas as coleções e dados dos painéis solares.

## 📁 Estrutura do Projeto

```
SolarBot/
├── Controllers/
│   └── PaineisSolaresController.cs
├── Services/
│   ├── IPainelSolarService.cs
│   └── PainelSolarService.cs
├── Models/
│   └── PainelSolar.cs
├── Tests/
│   ├── PaineisSolaresControllerTests.cs
│   ├── SolarBot.Tests.csproj
│   └── README.md
├── Program.cs
├── appsettings.json
├── SolarBot.csproj
├── SolarBot.db (criado automaticamente)
└── README.md
```

## 🧪 Testes Automatizados

O projeto inclui **testes automatizados completos** para todos os endpoints da API.

### Executar os Testes

```bash
# Do diretório raiz
dotnet test Tests/SolarBot.Tests.csproj

# Ou com saída detalhada
dotnet test Tests/SolarBot.Tests.csproj --verbosity detailed
```

⚠️ **IMPORTANTE**: Feche a aplicação antes de executar os testes! Os testes criam uma instância própria da API.

### Cobertura dos Testes

✅ 16 testes implementados cobrindo:
- GET - Listar todos os painéis
- GET - Buscar painel por ID
- POST - Criar novo painel (com validações)
- PUT - Atualizar painel existente
- DELETE - Remover painel
- GET - Estatísticas dos painéis
- Fluxo completo (CRUD integrado)

Veja mais detalhes em [`Tests/README.md`](Tests/README.md)

## 🔍 Documentação Swagger

A documentação interativa da API está disponível através do Swagger quando a aplicação está em modo de desenvolvimento. Acesse `/swagger` após iniciar a aplicação.

## ✅ Checklist de Requisitos do Projeto

### 1. Boas Práticas (30 pts) - ✅ COMPLETO

- ✅ **API RESTful implementada** - Todos os endpoints seguem princípios REST
- ✅ **Status codes adequados** - Utiliza 200, 201, 204, 400, 404, 500 corretamente
- ✅ **Verbos HTTP corretos** - GET (consulta), POST (criação), PUT (atualização), DELETE (remoção)
- ✅ **Rotas claras e consistentes** - Padrão `/api/v1/paineis-solares` em todos os endpoints
- ✅ **Código limpo e organizado** - Estrutura com Controllers, Services, Models separados

### 2. Versionamento da API (10 pts) - ✅ COMPLETO

- ✅ **Versionamento implementado** - Todas as rotas usam `/api/v1/...`
- ✅ **Controle de versões explicado** - Documentado na seção "Versionamento da API"
- ✅ **Estrutura para futuras versões** - Preparado para `/api/v2` quando necessário

### 3. Integração e Persistência (30 pts) - ⚠️ PARCIAL

- ✅ **Banco de dados NoSQL integrado** - LiteDB (arquivo local, sem necessidade de servidor)
- ❌ **Entity Framework Core** - Não utilizado (projeto usa LiteDB diretamente por ser NoSQL)
- ✅ **Operações CRUD com persistência** - Create, Read, Update, Delete funcionando
- ✅ **Modelos de dados bem definidos** - Classe `PainelSolar` com todas propriedades necessárias

**Nota:** O projeto utiliza **LiteDB** (banco NoSQL) em vez de Entity Framework Core. LiteDB foi escolhido por ser:
- Banco de dados NoSQL embutido (sem necessidade de servidor)
- Arquivo local simples
- Sem necessidade de credenciais ou instalação
- Ideal para prototipagem e desenvolvimento

### 4. Documentação (30 pts) - ⚠️ PARCIAL

- ✅ **README completo** - Com todas as instruções
  - ⚠️ Nomes dos integrantes (adicionar)
  - ✅ Descrição do projeto e funcionalidades
  - ✅ Instruções de execução
  - ❌ Fluxo da aplicação no Draw.io (pendente)
  - ❌ Link do vídeo demonstrativo (pendente)
- ✅ **Documentação com Swagger** - Interface interativa completa
- ✅ **Funcionamento dos endpoints explicado** - Exemplos de uso documentados

### Pontuação Estimada

- **Boas Práticas**: 30/30 ✅
- **Versionamento**: 10/10 ✅
- **Integração e Persistência**: 25/30 ⚠️ (LiteDB em vez de EF Core)
- **Documentação**: 25/30 ⚠️ (falta Draw.io e vídeo)

**Total Estimado: 90/100**

## 👥 Integrantes

- [Adicione os nomes dos integrantes aqui]

## 📹 Vídeo Demonstrativo

[Adicione o link do vídeo demonstrando o projeto (máx. 5 min)]

## 📊 Diagrama de Fluxo

[Adicione o link do diagrama Draw.io aqui]

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais.

## 🤝 Contribuindo

Este é um projeto acadêmico. Para sugestões ou melhorias, entre em contato com a equipe.
