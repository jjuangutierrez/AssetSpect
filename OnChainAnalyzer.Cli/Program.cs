using OnChainAnalyzer.Application.UseCases;
using OnChainAnalyzer.Infrastructure;

if (args.Length == 0)
{
    Console.Error.WriteLine("Usage: onchain-analyzer <bitcoin-address>");
    return 1;
}

var address = args[0];

using var httpclient = new HttpClient
{
    BaseAddress = new Uri("https://mempool.space/api/")
};

var provider = new EsploraUtxoProvider(httpclient);
var getAddressUtxos  = new GetAddressUtxos(provider);

try
{
    var result = await getAddressUtxos.ExecuteAsync(address);

    Console.WriteLine($"Address: {address}");
    Console.WriteLine();
    Console.WriteLine($"{"TXID",-14}{"VOUT",-6}{"AMOUNT",-20}{"BLOCK",-12}");
    
    foreach (var utxo in result.Utxos)
    {
        var shortTxid = utxo.TransactionId[..8] + "...";
        var block = utxo.BlockHeight?.ToString() ?? "unconfirmed";

        Console.WriteLine($"{shortTxid,-14}{utxo.OutputIndex,-6}{utxo.Amount,-20}{block,-12}");
    }

    Console.WriteLine();
    Console.WriteLine($"UTXOs: {result.Utxos.Count}");
    Console.WriteLine($"Total: {result.Total}");
}
catch (HttpRequestException e)
{
    Console.Error.WriteLine($"Error: could not get data from the blockchain API. {e.Message}");
    return 2;
}

return 0;