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

        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// Categories to filter for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] Categories { get; set; }

        /// <summary>
        /// Minimum amount of calories to filter for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public int? CalMin { get; set; }

        /// <summary>
        /// Maximum amount of calories to filter for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public int? CalMax { get; set; }

        /// <summary>
        /// Minimum price to filter for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? PriceMin { get; set; }

        /// <summary>
        /// Maximum price to filter for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? PriceMax { get; set; }

        /// <summary>
        /// On search.
        /// </summary>
        public void OnGet()
        {

            MenuList = Menu.CompleteMenu;

            if (Categories != null && Categories.Length > 0)
            {
                List<IOrderItem> categoriesList = new List<IOrderItem>();

                if (Categories.Contains("Entrees")) categoriesList.AddRange(MenuList.Where(item => item is Entree));
                if (Categories.Contains("Sides")) categoriesList.AddRange(MenuList.Where(item => item is Side));
                if (Categories.Contains("Drinks")) categoriesList.AddRange(MenuList.Where(item => item is Drink));

                MenuList = categoriesList;
            }

            if (SearchTerms != null)
            {
                MenuList = MenuList.Where(item => item.ToString() != null && item.ToString().Contains(SearchTerms, StringComparison.CurrentCultureIgnoreCase));
            }

            if (PriceMin != null)
            {
                MenuList = MenuList.Where(item => {
                    if (item is Side side)
                    {
                        side.Size = Size.Large;
                        bool largePrice = PriceMin <= side.Price;
                        side.Size = Size.Small;
                        return largePrice;
                    }
                    else if (item is Drink drink)
                    {
                        drink.Size = Size.Large;
                        bool largePrice = PriceMin <= drink.Price;
                        drink.Size = Size.Small;
                        return largePrice;
                    }
                    return PriceMin <= item.Price;
                });
            }
            if (PriceMax != null)
            {
                MenuList = MenuList.Where(item => item.Price <= PriceMax);
            }

            if (CalMin != null)
            {
                MenuList = MenuList.Where(item => {
                    if (item is Side side)
                    {
                        side.Size = Size.Large;
                        bool largeCal = CalMin <= side.Calories;
                        side.Size = Size.Small;
                        return largeCal;
                    }
                    else if (item is Drink drink)
                    {
                        drink.Size = Size.Large;
                        bool largeCal = CalMin <= drink.Calories;
                        drink.Size = Size.Small;
                        return largeCal;
                    }
                    return CalMin <= item.Calories;
                });
            }
            if (CalMax != null)
            {
                MenuList = MenuList.Where(item => item.Calories <= CalMax);
            }
        }
    }
}
