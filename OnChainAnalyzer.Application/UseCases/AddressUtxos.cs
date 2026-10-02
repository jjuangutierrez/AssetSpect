using OnChainAnalyzer.Domain.ValueObjects;
using OnChainAnalyzer.Domain.Entities;

namespace OnChainAnalyzer.Application.UseCases;

public record AddressUtxos(IReadOnlyList<Utxo> Utxos, BitcoinAmount Total);