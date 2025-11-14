# Script para Demonstração da API SolarBot no Swagger

Este documento contém os blocos de texto prontos para serem copiados e colados durante a demonstração da API no Swagger. Todos os exemplos estão organizados em ordem sequencial para facilitar a gravação do vídeo.

---

## **1. POST - Criar Painel 1 (Residencial)**

```json
{
  "nome": "Painel Solar Residencial SP",
  "localizacao": "São Paulo, SP",
  "capacidadeKW": 5.5,
  "geracaoAtualKW": 4.2,
  "statusOperacao": "Ativo"
}
```

**Ação:** Copiar o JSON acima, colar no campo de requisição do endpoint POST `/api/v1/paineis-solares`, clicar em "Try it out" e depois em "Execute". O sistema retorna status 201 Created com os dados do painel criado, incluindo o ID gerado automaticamente.

---

## **2. POST - Criar Painel 2 (Comercial)**

```json
{
  "nome": "Painel Solar Comercial RJ",
  "localizacao": "Rio de Janeiro, RJ",
  "capacidadeKW": 12.0,
  "geracaoAtualKW": 10.5,
  "statusOperacao": "Ativo"
}
```

**Ação:** Repetir o processo do passo anterior. O sistema cria um segundo painel solar com características comerciais.

---

## **3. POST - Criar Painel 3 (Industrial)**

```json
{
  "nome": "Painel Solar Industrial MG",
  "localizacao": "Belo Horizonte, MG",
  "capacidadeKW": 25.0,
  "geracaoAtualKW": 22.8,
  "statusOperacao": "Ativo"
}
```

**Ação:** Criar um terceiro painel com capacidade industrial maior. O sistema processa a requisição e retorna o painel criado.

---

## **4. POST - Criar Painel 4 (Em Manutenção)**

```json
{
  "nome": "Painel Solar Fazenda BA",
  "localizacao": "Salvador, BA",
  "capacidadeKW": 8.0,
  "geracaoAtualKW": 0.0,
  "statusOperacao": "Manutencao"
}
```

**Ação:** Criar um quarto painel com status "Manutencao" e geração zerada. O sistema aceita diferentes status de operação.

---

## **5. GET - Listar Todos os Painéis**

**Ação:** Acessar o endpoint GET `/api/v1/paineis-solares`, clicar em "Try it out" e depois em "Execute". Não é necessário preencher nenhum campo. O sistema retorna um array JSON com todos os painéis cadastrados, incluindo os 4 criados anteriormente.

---

## **6. GET por ID - Buscar Painel Específico**

**Parâmetro:** `id = 1`

**Ação:** Acessar o endpoint GET `/api/v1/paineis-solares/{id}`, clicar em "Try it out", inserir o valor `1` no campo `id` e clicar em "Execute". O sistema retorna apenas o painel com ID 1, mostrando todos os seus detalhes.

---

## **7. GET - Estatísticas dos Painéis**

**Ação:** Acessar o endpoint GET `/api/v1/paineis-solares/estatisticas`, clicar em "Try it out" e depois em "Execute". O sistema retorna um objeto JSON contendo estatísticas agregadas: total de painéis, painéis ativos, inativos, em manutenção, capacidade total, geração total, geração média e eficiência média.

---

## **8. PUT - Atualizar Painel ID 1**

**Parâmetro:** `id = 1`

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

**Ação:** Acessar o endpoint PUT `/api/v1/paineis-solares/{id}`, clicar em "Try it out", inserir o valor `1` no campo `id`, colar o JSON acima no corpo da requisição e clicar em "Execute". O sistema retorna status 204 No Content, indicando que a atualização foi bem-sucedida.

---

## **9. GET por ID - Verificar Atualização do Painel 1**

**Parâmetro:** `id = 1`

**Ação:** Repetir o processo do passo 6, buscando novamente o painel com ID 1. O sistema retorna os dados atualizados, confirmando que as alterações foram salvas corretamente.

---

## **10. PUT - Colocar Painel 2 em Manutenção**

**Parâmetro:** `id = 2`

```json
{
  "id": 2,
  "nome": "Painel Solar Comercial RJ",
  "localizacao": "Rio de Janeiro, RJ",
  "capacidadeKW": 12.0,
  "geracaoAtualKW": 0.0,
  "statusOperacao": "Manutencao"
}
```

**Ação:** Atualizar o painel com ID 2, alterando seu status para "Manutencao" e zerando a geração atual. O sistema processa a atualização e retorna status 204 No Content.

---

## **11. GET - Estatísticas Após Atualização**

**Ação:** Acessar novamente o endpoint de estatísticas. O sistema retorna estatísticas atualizadas, refletindo as mudanças realizadas: agora há mais painéis em manutenção e a geração total foi reduzida.

---

## **12. DELETE - Deletar Painel ID 4**

**Parâmetro:** `id = 4`

**Ação:** Acessar o endpoint DELETE `/api/v1/paineis-solares/{id}`, clicar em "Try it out", inserir o valor `4` no campo `id` e clicar em "Execute". O sistema retorna status 204 No Content, confirmando que o painel foi removido com sucesso.

---

## **13. GET - Listar Todos os Painéis Após Deletar**

**Ação:** Listar novamente todos os painéis. O sistema retorna apenas os 3 painéis restantes (IDs 1, 2 e 3), confirmando que o painel com ID 4 foi removido do banco de dados.

---

## **14. GET por ID - Tentar Buscar Painel Deletado**

**Parâmetro:** `id = 4`

**Ação:** Tentar buscar o painel com ID 4 que foi deletado. O sistema retorna status 404 Not Found com uma mensagem informando que o painel não foi encontrado, demonstrando o tratamento adequado de erros.

---

## **15. GET - Estatísticas Finais**

**Ação:** Acessar o endpoint de estatísticas pela última vez. O sistema retorna estatísticas finais atualizadas, refletindo o estado atual do banco de dados após todas as operações realizadas: 3 painéis no total, com distribuição atualizada de status e valores recalculados.

---

## **Resumo da Demonstração**

A demonstração cobre todas as operações CRUD da API:

- ✅ **CREATE (POST)**: Criação de 4 painéis solares com diferentes características
- ✅ **READ (GET)**: Listagem de todos os painéis e busca por ID específico
- ✅ **UPDATE (PUT)**: Atualização de dados e status dos painéis
- ✅ **DELETE (DELETE)**: Remoção de um painel do sistema
- ✅ **ESTATÍSTICAS**: Consulta de métricas agregadas dos painéis
- ✅ **TRATAMENTO DE ERROS**: Demonstração de resposta 404 para recurso não encontrado

Todos os endpoints retornam status codes HTTP apropriados e respostas em formato JSON, demonstrando que a API está funcionando corretamente e seguindo as melhores práticas de desenvolvimento REST.

