using AssetSpect.Application.UseCases;
using AssetSpect.Cli;
using AssetSpect.Domain;

var provider = new FakeUtxoProvider();

var getAddressBalance = new GetAddressBalance(provider);

var balance = await getAddressBalance.ExecuteAsync("any-address");
Console.WriteLine(balance);