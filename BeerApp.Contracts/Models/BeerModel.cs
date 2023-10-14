using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Contracts.Models
{
    internal class BeerModel
    {
    }

    public class RequestParams
    {
        public string beer_name { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public bool show_paging { get; set; }
    }
}
