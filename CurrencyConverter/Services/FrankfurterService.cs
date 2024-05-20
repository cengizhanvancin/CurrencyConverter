using RestSharp;
using System.Threading.Tasks;
using System.Net;

public class FrankfurterService
{
    private readonly RestClient _client;

    public FrankfurterService()
    {
        _client = new RestClient("https://api.frankfurter.app");
    }

    public async Task<RestResponse> GetLatestRatesAsync(string baseCurrency)
    {
        var request = new RestRequest($"/latest?from={baseCurrency}", Method.Get);
        return await ExecuteWithRetry(request);
    }

    public async Task<RestResponse> ConvertCurrencyAsync(string from, string to, decimal amount)
    {
        var request = new RestRequest($"/latest?from={from}&to={to}&amount={amount}", Method.Get);
        return await ExecuteWithRetry(request);
    }

    public async Task<RestResponse> GetHistoricalRatesAsync(string baseCurrency, string startDate, string endDate)
    {
        var request = new RestRequest($"/{startDate}..{endDate}?from={baseCurrency}", Method.Get);
        return await ExecuteWithRetry(request);
    }

    private async Task<RestResponse> ExecuteWithRetry(RestRequest request)
    {
        int retries = 3;
        for (int i = 0; i < retries; i++)
        {
            var response = await _client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return response;
        }
        return new RestResponse { StatusCode = HttpStatusCode.ServiceUnavailable };
    }
}