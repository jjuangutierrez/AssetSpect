using OnChainAnalyzer.Domain.ValueObjects;

namespace OnChainAnalyzer.Domain.Entities;

public record Utxo
{
    public string TransactionId { get; }
    public int OutputIndex { get; }
    public BitcoinAmount Amount { get; }
    
    public Utxo(string transactionId, int outputIndex, BitcoinAmount amount)
    {
        ArgumentException.ThrowIfNullOrEmpty(transactionId);
        ArgumentNullException.ThrowIfNull(amount);
        
        var isTransactionValid = transactionId.Length == 64 && transactionId.All(c => Uri.IsHexDigit(c));

        if  (!isTransactionValid)
            throw new ArgumentException($"Invalid transaction ID: {nameof(transactionId)}", nameof(transactionId));
        
        if (outputIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(outputIndex), "A outputIndex must be greater than or equal to zero.");
        
        TransactionId = transactionId;
        OutputIndex = outputIndex;
        Amount = amount;
    }
}