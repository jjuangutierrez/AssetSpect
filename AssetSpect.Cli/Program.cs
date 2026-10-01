using AssetSpect.Application.UseCases;
using AssetSpect.Infrastructure;

var httpclient = new HttpClient
{
    BaseAddress = new Uri("https://mempool.space/api/")
};

var provider = new EsploraUtxoProvider(httpclient);

var getAddressBalance = new GetAddressBalance(provider);
var balance = await getAddressBalance.ExecuteAsync("12cbQLTFMXRnSzktFkuoG3eHoMeFtpTu3S");
Console.WriteLine(balance);