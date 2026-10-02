using OnChainAnalyzer.Application.UseCases;
using OnChainAnalyzer.Infrastructure;

if (args.Length == 0)
{
    Console.WriteLine("Usage: onchain-analyzer <bitcoin-address>");
    return 1;
}

var address = args[0];

var httpclient = new HttpClient
{
    BaseAddress = new Uri("https://mempool.space/api/")
};

var provider = new EsploraUtxoProvider(httpclient);
var getAddressBalance = new GetAddressBalance(provider);

var balance = await getAddressBalance.ExecuteAsync(address);
Console.WriteLine(balance);

return 0;