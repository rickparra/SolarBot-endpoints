namespace SolarBot.Models;

public class PainelSolar
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Localizacao { get; set; } = string.Empty;
    public decimal CapacidadeKW { get; set; }
    public decimal GeracaoAtualKW { get; set; }
    public string StatusOperacao { get; set; } = "Ativo"; // Ativo, Inativo, Manutencao
    public DateTime DataInstalacao { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }
}

