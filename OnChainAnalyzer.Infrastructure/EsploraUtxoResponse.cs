using System.Text.Json.Serialization;

namespace OnChainAnalyzer.Infrastructure;

public record EsploraUtxoResponse
{
    [JsonPropertyName("txid")] public string Txid { get; init; } = "";
    [JsonPropertyName("vout")] public int Vout { get; init; } = 0;
    [JsonPropertyName("value")] public long Value { get; init; } = 0;
    [JsonPropertyName("status")] public EsploraStatusResponse Status { get; init; } = new();
}