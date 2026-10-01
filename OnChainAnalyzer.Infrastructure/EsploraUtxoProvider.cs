using System.Net.Http.Json;
using OnChainAnalyzer.Application.Interfaces;
using OnChainAnalyzer.Domain.Entities;
using OnChainAnalyzer.Domain.ValueObjects;

namespace OnChainAnalyzer.Infrastructure;

public class EsploraUtxoProvider : IUtxoProvider
{
    private readonly HttpClient _httpClient;
    
    public EsploraUtxoProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<Utxo>> GetUtxosAsync(string address)
    {
        var responses = await _httpClient.GetFromJsonAsync<List<EsploraUtxoResponse>>($"address/{address}/utxo") ?? [];
        
        return responses.Select(r => new Utxo(r.Txid, r.Vout, BitcoinAmount.FromSatoshis(r.Value))).ToList();
    }
}