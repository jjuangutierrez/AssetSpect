using AssetSpect.Application.Interfaces;
using AssetSpect.Domain.Entities;
using AssetSpect.Domain.ValueObjects;

namespace AssetSpect.Cli;

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