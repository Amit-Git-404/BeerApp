using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BeerApp.Contracts.IServices;
using BeerApp.Contracts.Models;
using BeerApp.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BeerTests;

public class BeerFetchServiceTest
{
    [Fact]
    public async Task GetBeersAsync_ShouldReturnData()
    {
        // Arrange
        var expectedData = "SampleDataFromAPI";
        var requestParams = new RequestParams();

        var httpClient = new HttpClient(new MockHttpMessageHandler(expectedData))
        {
            BaseAddress = new Uri("https://api.punkapi.com/")
        };

        var serviceProvider = new ServiceCollection()
                .AddSingleton(httpClient)
                .AddScoped<IBeerFetchService, BeerFetchService>()
                .BuildServiceProvider();

        var myService = serviceProvider.GetService<IBeerFetchService>();

        // Act
        var result = await myService.GetBeersAsync(requestParams);

        // Assert
        Assert.Equal(expectedData, result);
    }
}

public class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly string _content;

    public MockHttpMessageHandler(string content)
    {
        _content = content;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_content)
        });
    }
}