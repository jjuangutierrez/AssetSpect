using AssetSpect.Domain.Entities;

namespace AssetSpect.Application.Interfaces;

public interface IUtxoProvider
{
    Task<IReadOnlyList<Utxo>> GetUtxosAsync(string address);
}