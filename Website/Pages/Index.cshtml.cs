using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CowboyCafe.Data;

namespace CowboyCafe.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// List of Entrees being displayed
        /// </summary>
        public IEnumerable<IOrderItem> MenuList { get; protected set; }

        /// <summary>
        /// Search terms to filter for
        /// </summary>
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// Categories to filter for
        /// </summary>
        public string[] Categories { get; set; }

        /// <summary>
        /// Minimum amount of calories to filter for
        /// </summary>
        public int? CalMin { get; set; }

        /// <summary>
        /// Maximum amount of calories to filter for
        /// </summary>
        public int? CalMax { get; set; }

        /// <summary>
        /// Minimum price to filter for
        /// </summary>
        public double? PriceMin { get; set; }

        /// <summary>
        /// Maximum price to filter for
        /// </summary>
        public double? PriceMax { get; set; }

        /// <summary>
        /// On search.
        /// </summary>
        public void OnGet(double? priceMin, double? priceMax, int? calMin, int? calMax)
        {
            SearchTerms = Request.Query["SearchTerms"];
            Categories = Request.Query["Categories"];
            PriceMin = priceMin;
            PriceMax = priceMax;
            CalMin = calMin;
            CalMax = calMax;

            MenuList = Menu.Search(Menu.CompleteMenu, SearchTerms);
            MenuList = Menu.FilterByCategory(MenuList, Categories);
            MenuList = Menu.FilterByPrice(MenuList, PriceMin, PriceMax);
            MenuList = Menu.FilterByCalories(MenuList, CalMin, CalMax);
        }
    }
}
