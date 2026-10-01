using OnChainAnalyzer.Domain.ValueObjects;
using OnChainAnalyzer.Application.Interfaces;

namespace OnChainAnalyzer.Application.UseCases;

public class GetAddressBalance
{
    private readonly IUtxoProvider _utxoProvider;

    public GetAddressBalance(IUtxoProvider utxoProvider)
    {
        _utxoProvider = utxoProvider;
    }

    public async Task<BitcoinAmount> ExecuteAsync(string address)
    {
        var utxos = await _utxoProvider.GetUtxosAsync(address);
        return BitcoinAmount.Sum(utxos.Select(utxo => utxo.Amount));
    }
}