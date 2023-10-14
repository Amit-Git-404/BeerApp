using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerApp.Contracts.Models;

namespace BeerApp.Contracts.IServices
{
    public interface IBeerFetchService
    {
        Task<string> GetBeersAsync(RequestParams requestParams);
    }
}
