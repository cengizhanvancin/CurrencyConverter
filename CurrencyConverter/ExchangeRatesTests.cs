using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

public class ExchangeRatesControllerTests
{
    [Fact]
    public async Task GetLatestRates_ReturnsOk()
    {

        var serviceMock = new Mock<FrankfurterService>();
        serviceMock.Setup(s => s.GetLatestRatesAsync(It.IsAny<string>()))
                   .ReturnsAsync(new RestResponse { StatusCode = HttpStatusCode.OK, Content = "{ \"rates\": {} }" });

        var controller = new ExchangeRatesController(serviceMock.Object);

        var result = await controller.GetLatestRates("EUR") as ObjectResult;

        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

}