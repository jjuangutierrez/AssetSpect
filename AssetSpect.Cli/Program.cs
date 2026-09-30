using AssetSpect.Domain;

var a = BitcoinAmount.FromSatoshis(100);
var b = BitcoinAmount.FromSatoshis(50);

Console.WriteLine(a + b);
Console.WriteLine(a + BitcoinAmount.Zero == a);
Console.WriteLine(a);