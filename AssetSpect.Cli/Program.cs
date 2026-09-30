using AssetSpect.Domain;

var amount = BitcoinAmount.FromBtc(0.5m);
var validTxid = new string('a', 62);

var u1 = new Utxo(validTxid, 0, amount);
var u2 = new Utxo(validTxid, -1, amount);

Console.WriteLine(u1);
Console.WriteLine(u1 == u2);