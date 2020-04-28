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

        /* The listing of items needs to be modified in order to more easily filter items
         * The Menu class needs to be finished, right now the only method done is SearchTerms, but it isn't really applied yet.
         * We need backing variables which will hold the list(s) within THIS class.
         */
        //[BindProperty]  
        public string SearchTerms { get; set; } = "";

        public string[] Categories { get; set; }

        public int? CalMin { get; set; }

        public int? CalMax { get; set; }

        public double? PriceMin { get; set; }

        public double? PriceMax { get; set; }

        /// <summary>
        /// On search.
        /// </summary>
        public void OnGet()
        {
            SearchTerms = Request.Query["SearchTerms"];
            Categories = Request.Query["Categories"];

            MenuList = Menu.Search(Menu.CompleteMenu, SearchTerms);
            MenuList = Menu.FilterByCategory(MenuList, Categories);
        }
    }
}
