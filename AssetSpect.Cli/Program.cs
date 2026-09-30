using AssetSpect.Domain;

var a = BitcoinAmount.FromSatoshis(-1);
var b = BitcoinAmount.FromBtc(-0.5m);

Console.WriteLine(a);
Console.WriteLine(a.Btc);
Console.WriteLine(a == b);
