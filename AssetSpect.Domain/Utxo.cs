namespace AssetSpect.Domain;

public record Utxo
{
    public string TransactionId { get; }
    public int OutputIndex { get; }
    public BitcoinAmount Amount { get; }
 
    public Utxo(string transactionId, int outputIndex, BitcoinAmount amount)
    {
        bool isTransactionValid = transactionId.Length == 64 && transactionId.All(c => Uri.IsHexDigit(c));

        if  (!isTransactionValid)
            throw new ArgumentException($"Invalid transaction ID: {transactionId}");
        
        if (outputIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(outputIndex), "A outputIndex must be greater than or equal to zero.");
        
        TransactionId = transactionId;
        OutputIndex = outputIndex;
        Amount = amount;
    }
}