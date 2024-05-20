using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ExchangeRatesController : ControllerBase
{
    private readonly FrankfurterService _service;
    private static readonly string[] ExcludedCurrencies = { "TRY", "PLN", "THB", "MXN" };

    // Inject the FrankfurterService via constructor
    public ExchangeRatesController(FrankfurterService service)
    {
        _service = service;
    }

    [HttpGet("latest/{baseCurrency}")]
    public async Task<IActionResult> GetLatestRates(string baseCurrency)
    {
        var response = await _service.GetLatestRatesAsync(baseCurrency);
        return StatusCode((int)response.StatusCode, response.Content);
    }

    [HttpGet("convert")]
    public async Task<IActionResult> ConvertCurrency([FromQuery] string from, [FromQuery] string to, [FromQuery] decimal amount)
    {
        if (ExcludedCurrencies.Contains(from) || ExcludedCurrencies.Contains(to))
        {
            return BadRequest("Conversion involving TRY, PLN, THB, and MXN is not supported.");
        }

        var response = await _service.ConvertCurrencyAsync(from, to, amount);
        return StatusCode((int)response.StatusCode, response.Content);
    }

    [HttpGet("historical")]
    public async Task<IActionResult> GetHistoricalRates([FromQuery] string baseCurrency, [FromQuery] string startDate, [FromQuery] string endDate)
    {
        var response = await _service.GetHistoricalRatesAsync(baseCurrency, startDate, endDate);
        return StatusCode((int)response.StatusCode, response.Content);
    }
}