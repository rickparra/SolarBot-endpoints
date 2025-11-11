using LiteDB;
using SolarBot.Models;

namespace SolarBot.Services;

public class PainelSolarService : IPainelSolarService
{
    private readonly string _connectionString;
    private const string CollectionName = "paineis_solares";

    public PainelSolarService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _connectionString = connectionString ?? "Filename=SolarBot.db;Connection=shared";
    }

    public async Task<IEnumerable<PainelSolar>> ObterTodosAsync()
    {
        return await Task.Run(() =>
        {
            using var db = new LiteDatabase(_connectionString);
            var collection = db.GetCollection<PainelSolar>(CollectionName);
            return collection.FindAll().ToList();
        });
    }

    public async Task<PainelSolar?> ObterPorIdAsync(int id)
    {
        return await Task.Run(() =>
        {
            using var db = new LiteDatabase(_connectionString);
            var collection = db.GetCollection<PainelSolar>(CollectionName);
            return collection.FindById(id);
        });
    }

    public async Task<PainelSolar> CriarAsync(PainelSolar painel)
    {
        return await Task.Run(() =>
        {
            using var db = new LiteDatabase(_connectionString);
            var collection = db.GetCollection<PainelSolar>(CollectionName);
            
            // O LiteDB gera automaticamente o ID quando Id = 0
            painel.Id = 0;
            var id = collection.Insert(painel);
            painel.Id = id.AsInt32;
            
            return painel;
        });
    }

    public async Task<bool> AtualizarAsync(int id, PainelSolar painel)
    {
        return await Task.Run(() =>
        {
            using var db = new LiteDatabase(_connectionString);
            var collection = db.GetCollection<PainelSolar>(CollectionName);
            
            var painelExistente = collection.FindById(id);
            if (painelExistente == null)
            {
                return false;
            }

            painel.Id = id;
            painel.DataInstalacao = painelExistente.DataInstalacao; // Preservar data de instalação
            painel.DataUltimaAtualizacao = DateTime.UtcNow;
            
            return collection.Update(painel);
        });
    }

    public async Task<bool> DeletarAsync(int id)
    {
        return await Task.Run(() =>
        {
            using var db = new LiteDatabase(_connectionString);
            var collection = db.GetCollection<PainelSolar>(CollectionName);
            return collection.Delete(id);
        });
    }

    public async Task<bool> ExisteAsync(int id)
    {
        return await Task.Run(() =>
        {
            using var db = new LiteDatabase(_connectionString);
            var collection = db.GetCollection<PainelSolar>(CollectionName);
            return collection.Exists(p => p.Id == id);
        });
    }
}

