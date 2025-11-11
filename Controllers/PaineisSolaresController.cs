using Microsoft.AspNetCore.Mvc;
using SolarBot.Models;
using SolarBot.Services;

namespace SolarBot.Controllers;

[ApiController]
[Route("api/v1/paineis-solares")]
[Produces("application/json")]
public class PaineisSolaresController : ControllerBase
{
    private readonly IPainelSolarService _service;
    private readonly ILogger<PaineisSolaresController> _logger;

    public PaineisSolaresController(IPainelSolarService service, ILogger<PaineisSolaresController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Lista todos os painéis solares cadastrados
    /// </summary>
    /// <returns>Lista de painéis solares</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PainelSolar>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PainelSolar>>> GetPaineisSolares()
    {
        try
        {
            var paineis = await _service.ObterTodosAsync();
            return Ok(paineis);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar painéis solares");
            return StatusCode(500, new { message = "Erro interno do servidor ao buscar painéis solares" });
        }
    }

    /// <summary>
    /// Busca um painel solar específico por ID
    /// </summary>
    /// <param name="id">ID do painel solar</param>
    /// <returns>Painel solar encontrado</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PainelSolar), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PainelSolar>> GetPainelSolar(int id)
    {
        try
        {
            var painel = await _service.ObterPorIdAsync(id);

            if (painel == null)
            {
                return NotFound(new { message = $"Painel solar com ID {id} não encontrado" });
            }

            return Ok(painel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar painel solar com ID {Id}", id);
            return StatusCode(500, new { message = "Erro interno do servidor ao buscar painel solar" });
        }
    }

    /// <summary>
    /// Cria um novo painel solar
    /// </summary>
    /// <param name="painel">Dados do painel solar a ser criado</param>
    /// <returns>Painel solar criado</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PainelSolar), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PainelSolar>> PostPainelSolar(PainelSolar painel)
    {
        try
        {
            _logger.LogInformation("===== INICIANDO POST PAINEL SOLAR =====");
            _logger.LogInformation($"Painel recebido: Nome={painel?.Nome}, Localizacao={painel?.Localizacao}");
            
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválido");
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(painel.Nome))
            {
                _logger.LogWarning("Nome do painel vazio");
                return BadRequest(new { message = "O nome do painel solar é obrigatório" });
            }

            if (string.IsNullOrWhiteSpace(painel.Localizacao))
            {
                _logger.LogWarning("Localização do painel vazia");
                return BadRequest(new { message = "A localização do painel solar é obrigatória" });
            }

            _logger.LogInformation("Definindo datas...");
            painel.DataInstalacao = DateTime.UtcNow;
            painel.DataUltimaAtualizacao = DateTime.UtcNow;

            _logger.LogInformation($"Chamando serviço CriarAsync...");
            var painelCriado = await _service.CriarAsync(painel);
            
            _logger.LogInformation($"Painel criado com ID: {painelCriado.Id}");

            return CreatedAtAction(nameof(GetPainelSolar), new { id = painelCriado.Id }, painelCriado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ERRO DETALHADO ao criar painel solar: {ex.Message}");
            _logger.LogError($"Inner Exception: {ex.InnerException?.Message}");
            _logger.LogError($"Stack Trace: {ex.StackTrace}");
            return StatusCode(500, new { 
                message = "Erro interno do servidor ao criar painel solar",
                error = ex.Message,
                innerError = ex.InnerException?.Message
            });
        }
    }

    /// <summary>
    /// Atualiza um painel solar existente
    /// </summary>
    /// <param name="id">ID do painel solar</param>
    /// <param name="painel">Dados atualizados do painel solar</param>
    /// <returns>Nenhum conteúdo</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutPainelSolar(int id, PainelSolar painel)
    {
        try
        {
            if (id != painel.Id)
            {
                return BadRequest(new { message = "O ID da URL não corresponde ao ID do painel solar" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atualizado = await _service.AtualizarAsync(id, painel);
            if (!atualizado)
            {
                return NotFound(new { message = $"Painel solar com ID {id} não encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar painel solar com ID {Id}", id);
            return StatusCode(500, new { message = "Erro interno do servidor ao atualizar painel solar" });
        }
    }

    /// <summary>
    /// Remove um painel solar
    /// </summary>
    /// <param name="id">ID do painel solar</param>
    /// <returns>Nenhum conteúdo</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePainelSolar(int id)
    {
        try
        {
            var deletado = await _service.DeletarAsync(id);
            if (!deletado)
            {
                return NotFound(new { message = $"Painel solar com ID {id} não encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar painel solar com ID {Id}", id);
            return StatusCode(500, new { message = "Erro interno do servidor ao deletar painel solar" });
        }
    }

    /// <summary>
    /// Retorna estatísticas sobre os painéis solares
    /// </summary>
    /// <returns>Estatísticas dos painéis solares</returns>
    [HttpGet("estatisticas")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetEstatisticas()
    {
        try
        {
            var paineis = await _service.ObterTodosAsync();
            var listaPaineis = paineis.ToList();

            var estatisticas = new
            {
                TotalPaineis = listaPaineis.Count,
                PaineisAtivos = listaPaineis.Count(p => p.StatusOperacao == "Ativo"),
                PaineisInativos = listaPaineis.Count(p => p.StatusOperacao == "Inativo"),
                PaineisEmManutencao = listaPaineis.Count(p => p.StatusOperacao == "Manutencao"),
                CapacidadeTotalKW = listaPaineis.Sum(p => p.CapacidadeKW),
                GeracaoTotalKW = listaPaineis.Sum(p => p.GeracaoAtualKW),
                GeracaoMediaKW = listaPaineis.Any() ? listaPaineis.Average(p => p.GeracaoAtualKW) : 0,
                EficienciaMedia = listaPaineis.Any() && listaPaineis.Sum(p => p.CapacidadeKW) > 0
                    ? (listaPaineis.Sum(p => p.GeracaoAtualKW) / listaPaineis.Sum(p => p.CapacidadeKW)) * 100
                    : 0
            };

            return Ok(estatisticas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar estatísticas");
            return StatusCode(500, new { message = "Erro interno do servidor ao buscar estatísticas" });
        }
    }
}

