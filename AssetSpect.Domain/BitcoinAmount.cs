namespace AssetSpect.Domain;

public record BitcoinAmount
{
    public long Satoshis { get;}
    public decimal Btc => Satoshis / 100_000_000m;

    private BitcoinAmount(long satoshis)
    {
        if (satoshis < 0)
            throw new ArgumentOutOfRangeException(nameof(satoshis), "A satoshis must be greater than or equal to zero.");
        
        Satoshis = satoshis;
    }
    
    public static BitcoinAmount FromSatoshis(long satoshis) => new BitcoinAmount(satoshis);
    public static BitcoinAmount FromBtc(decimal btc) => new BitcoinAmount((long)(btc * 100_000_000m));
    public static BitcoinAmount operator +(BitcoinAmount a, BitcoinAmount b) => FromSatoshis(a.Satoshis + b.Satoshis);
    public static BitcoinAmount Zero => FromSatoshis(0);

    public static BitcoinAmount Sum(IEnumerable<BitcoinAmount> amounts)
    {
        var satoshis = amounts.Sum(a => a.Satoshis);
        
        return FromSatoshis(satoshis);
    }
    
    public override string ToString() => $"{Btc:F8} BTC";
}