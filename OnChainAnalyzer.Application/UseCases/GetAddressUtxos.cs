using OnChainAnalyzer.Application.Interfaces;
using OnChainAnalyzer.Domain.ValueObjects;

namespace OnChainAnalyzer.Application.UseCases;

public class GetAddressUtxos
{
    private readonly IUtxoProvider _utxoProvider;

    public GetAddressUtxos(IUtxoProvider utxoProvider)
    {
        _utxoProvider = utxoProvider;
    }

    public async Task<AddressUtxos> ExecuteAsync(string address)
    {
        var utxos = await _utxoProvider.GetUtxosAsync(address);
        var total = BitcoinAmount.Sum(utxos.Select(u => u.Amount));
        return new AddressUtxos(utxos, total);
    }
}