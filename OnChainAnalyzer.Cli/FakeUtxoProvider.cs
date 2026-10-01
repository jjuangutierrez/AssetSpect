using OnChainAnalyzer.Application.Interfaces;
using OnChainAnalyzer.Domain.Entities;
using OnChainAnalyzer.Domain.ValueObjects;

namespace OnChainAnalyzer.Cli;

public class FakeUtxoProvider: IUtxoProvider
{
    public Task<IReadOnlyList<Utxo>> GetUtxosAsync(string address)
    {
        var utxos = new List<Utxo>
        {
            new Utxo(new string('a', 64), 0, BitcoinAmount.FromSatoshis(100)),
            new Utxo(new string('a', 64), 1, BitcoinAmount.FromSatoshis(50)),
            new Utxo(new string('a', 64), 2, BitcoinAmount.FromSatoshis(1050)),
        };
     
        return Task.FromResult<IReadOnlyList<Utxo>>(utxos);
    }
}