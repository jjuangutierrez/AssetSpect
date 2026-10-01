using System.Net.Http.Json;
using AssetSpect.Application.Interfaces;
using AssetSpect.Domain.Entities;
using AssetSpect.Domain.ValueObjects;

namespace AssetSpect.Infrastructure;

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