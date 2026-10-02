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
var getAddressBalance = new GetAddressBalance(provider);

try
{
    var balance = await getAddressBalance.ExecuteAsync(address);
    Console.WriteLine(balance);
}
catch (HttpRequestException e)
{
    Console.Error.WriteLine($"Error: could not get data from the blockchain API. {e.Message}");
    return 2;
}

return 0;