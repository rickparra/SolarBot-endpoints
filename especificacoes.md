# ✅ Requisitos do Projeto – Global Solution (C# ASP.NET Core)

## 1. Boas Práticas (30 pts)
- [ ] Implementar uma API **RESTful**.
- [ ] Utilizar **status codes** adequados (200, 201, 400, 404, 500...).
- [ ] Usar corretamente os verbos HTTP (**GET, POST, PUT, DELETE**).
- [ ] Estruturar rotas claras e consistentes.
- [ ] Manter código limpo, organizado e com boas práticas de arquitetura.

---

## 2. Versionamento da API (10 pts)
- [ ] Implementar versionamento nas rotas (ex: `/api/v1/...`).
- [ ] Explicar o controle de versões no **README**.
- [ ] Planejar estrutura para futuras versões (ex: `/api/v2`).

---

## 3. Integração e Persistência (30 pts)
- [ ] Integrar com um **banco de dados relacional ou não relacional** (SQL Server, Oracle ou MongoDB).
- [ ] Utilizar **Entity Framework Core**.
- [ ] Implementar operações CRUD com persistência.
- [ ] Criar modelos de dados bem definidos.

---

## 4. Documentação (30 pts)
- [ ] Criar **README completo** no GitHub com:
  - [ ] Nomes dos integrantes.  
  - [ ] Descrição do projeto e funcionalidades.  
  - [ ] Instruções de execução.  
  - [ ] Fluxo da aplicação (feito no **Draw.io**).  
  - [ ] Link do vídeo demonstrando o projeto (máx. 5 min).  
- [ ] Documentar a API com **Swagger**.
- [ ] Explicar o funcionamento dos endpoints e exemplos de uso.

---

# 💡 Ideia do Projeto

**Título:** SolarBot – API para Monitoramento e Consulta de Placas Solares  

**Descrição:**  
O projeto consiste em uma **API RESTful** desenvolvida em **ASP.NET Core** que fornece dados sobre placas solares, permitindo que um **chatbot** consulte e responda perguntas com base nessas informações. A aplicação aborda o tema *“O Futuro do Trabalho”* ao unir **energia sustentável**, **automação** e **inteligência de dados**.

**Principais Funcionalidades:**
- CRUD de painéis solares (cadastro, atualização, exclusão, consulta).  
- Armazenamento de dados de geração de energia, localização e status de operação.  
- Endpoint para estatísticas (ex: geração média, painéis ativos).  
- Documentação via **Swagger**.  
- Banco de dados com **Entity Framework Core**.  
- Estrutura versionada (`/api/v1/...`).  
- Documentação completa e diagrama de fluxo no **Draw.io**.  
