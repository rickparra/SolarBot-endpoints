using SolarBot.Models;

namespace SolarBot.Services;

public interface IPainelSolarService
{
    Task<IEnumerable<PainelSolar>> ObterTodosAsync();
    Task<PainelSolar?> ObterPorIdAsync(int id);
    Task<PainelSolar> CriarAsync(PainelSolar painel);
    Task<bool> AtualizarAsync(int id, PainelSolar painel);
    Task<bool> DeletarAsync(int id);
    Task<bool> ExisteAsync(int id);
}

