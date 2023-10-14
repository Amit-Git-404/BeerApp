using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerApp.Contracts.IServices;
using BeerApp.Contracts.Models;

namespace BeerApp.Infrastructure.Services
{
    public class BeerFetchService : IBeerFetchService
    {
        private readonly HttpClient _httpClient;

        public BeerFetchService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetBeersAsync(RequestParams requestParams)
        {
            string url = "https://api.punkapi.com/v2/beers";
            if(requestParams != null)
            {
                if(requestParams.beer_name != null)
                {
                    url += "?beer_name=" + requestParams.beer_name;
                }
                if(requestParams.show_paging)
                {
                    string literalToUse = requestParams.beer_name != "" ? "&" : "?";
                    url += literalToUse + "page=" + requestParams.page + "&per_page=" + requestParams.per_page;
                }
            }
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Throw an exception if the response is not successful

            return await response.Content.ReadAsStringAsync();
        }
    }
}
