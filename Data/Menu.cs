using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Sides;
using CowboyCafe.Data.Drinks;

namespace CowboyCafe.Data
{
    public static class Menu
    {
        private static IEnumerable<IOrderItem> entrees;
        /// <summary>
        /// Creates static enumeration of a single instance of every entree.
        /// </summary>
        /// <returns>Enumeration of every entree</returns>
        public static IEnumerable<IOrderItem> Entrees
        {
            get
            {
                if (entrees != null) return entrees;

                var entreesNew = new List<Entree>();

                entreesNew.Add(new AngryChicken());
                entreesNew.Add(new CowpokeChili());
                entreesNew.Add(new DakotaDoubleBurger());
                entreesNew.Add(new PecosPulledPork());
                entreesNew.Add(new RustlersRibs());
                entreesNew.Add(new TexasTripleBurger());
                entreesNew.Add(new TrailBurger());

                entrees = entreesNew.ToArray();
                return entrees;
            }
        }

        private static IEnumerable<IOrderItem> sides;
        /// <summary>
        /// Creates static enumeration of a single instance of every side.
        /// </summary>
        /// <returns>Enumeration of every side</returns>
        public static IEnumerable<IOrderItem> Sides
        {
            get
            {
                if (sides != null) return sides;

                var sidesNew = new List<Side>();

                sidesNew.Add(new BakedBeans());
                sidesNew.Add(new ChiliCheeseFries());
                sidesNew.Add(new CornDodgers());
                sidesNew.Add(new PanDeCampo());

                sides = sidesNew.ToArray();
                return sides;
            }
        }

        private static IEnumerable<IOrderItem> drinks;
        /// <summary>
        /// Creates static enumeration of a single instance of every drink.
        /// </summary>
        /// <returns>Enumeration of every drink</returns>
        public static IEnumerable<IOrderItem> Drinks
        {
            get
            {
                if (drinks != null) return drinks;

                var drinksNew = new List<Drink>();

                drinksNew.Add(new CowboyCoffee());
                drinksNew.Add(new JerkedSoda());
                drinksNew.Add(new TexasTea());
                drinksNew.Add(new Water());

                drinks = drinksNew.ToArray();
                return drinks;
            }
        }

        /// <summary>
        /// String list of the types of categories
        /// </summary>
        public static string[] Categories{
            get => new string[]
            {
                "Entrees",
                "Sides",
                "Drinks"
            };
        }

        private static IEnumerable<IOrderItem> completeMenu;
        /// <summary>
        /// Creates static enumeration of a single instance of every menu item.
        /// </summary>
        /// <returns>Enumeration of every menu item</returns>
        public static IEnumerable<IOrderItem> CompleteMenu
        {
            get
            {
                if (completeMenu != null) return completeMenu;

                var completeMenuNew = new List<IOrderItem>();

                foreach (Entree entree in Entrees) { completeMenuNew.Add(entree); }
                foreach (Side side in Sides) { completeMenuNew.Add(side); }
                foreach (Drink drink in Drinks) { completeMenuNew.Add(drink); }

                completeMenu = completeMenuNew.ToArray();
                return completeMenu;
            }
        }

        /// <summary>
        /// Filters IOrderItems list by serachterm
        /// </summary>
        /// <param name="menu">Enumerable list of IOrderItems</param>
        /// <param name="term">Search terms</param>
        /// <returns>Filtered list of IOrderItems</returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> menu, string term)
        {
            List<IOrderItem> results = new List<IOrderItem>();

            if (term == null) return menu;
            foreach (IOrderItem item in menu)
            {
                if (item.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
                    results.Add(item);
            }
            return results;
        }

        /// <summary>
        /// Filters IOrderItems list according to category
        /// </summary>
        /// <param name="menu">Enumerable list of IOrderItems</param>
        /// <param name="term">Search terms</param>
        /// <returns>Filtered list of IOrderItems</returns>
        public static IEnumerable<IOrderItem> FilterByCategory(IEnumerable<IOrderItem> menu, IEnumerable<string> categories)
        {

            if (categories == null || categories.Count() == 0) return menu;

            List<IOrderItem> results = new List<IOrderItem>();

            if (categories.Contains("Entrees"))
            {
                foreach (Entree item in menu.OfType<Entree>())
                {
                    results.Add(item);
                }
            }
            if (categories.Contains("Sides"))
            {
                foreach (Side item in menu.OfType<Side>())
                {
                    results.Add(item);
                }
            }
            if (categories.Contains("Drinks"))
            {
                foreach (Drink item in menu.OfType<Drink>())
                {
                    results.Add(item);
                }
            }

            return results;
        }

        /// <summary>
        /// Filters IOrderItemList list according to Calorie count
        /// </summary>
        /// <param name="menu">Enumerable list of IOrderItems</param>
        /// <param name="min">Minimum amount of calories</param>
        /// <param name="max">Maximum amount of calories</param>
        /// <returns>Filtered list of IOrderItems</returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> menu, int? min, int? max)
        {
            if (min == null  && max == null) return menu;

            List<IOrderItem> results = new List<IOrderItem>();

            if (min == null)
            {
                foreach (IOrderItem item in menu)
                {
                    if (item.Calories <= max)
                        results.Add(item);
                }
            }
            else if (max == null)
            {
                foreach (IOrderItem item in menu)
                {
                    if (item is Drink drink)
                    {
                        drink = SwapSize(drink);

                        if (min <= drink.Calories)
                            results.Add(item);

                        drink = SwapSize(drink);
                    }
                    else if (item is Side side)
                    {
                        side = SwapSize(side);

                        if (min <= side.Calories)
                            results.Add(item);

                        side = SwapSize(side);
                    }
                    else
                    {
                        if (min <= item.Calories)
                            results.Add(item);
                    }
                }
            }
            else
            {
                foreach (IOrderItem item in menu)
                {
                    if (item.Calories <= max)
                    {
                        if (item is Drink drink)
                        {
                            drink = SwapSize(drink);

                            if (min <= drink.Calories)
                                results.Add(item);

                            drink = SwapSize(drink);
                        }
                        else if (item is Side side)
                        {
                            side = SwapSize(side);

                            if (min <= side.Calories)
                                results.Add(item);

                            side = SwapSize(side);
                        }
                        else
                        {
                            if (min <= item.Calories)
                                results.Add(item);
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Filters IOrderItemList list according to Price
        /// </summary>
        /// <param name="menu">Enumerable list of IOrderItems</param>
        /// <param name="min">Minimum amount of calories</param>
        /// <param name="max">Maximum amount of calories</param>
        /// <returns>Filtered list of IOrderItems</returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> menu, double? min, double? max)
        {
            if (min == null && max == null) return menu;

            List<IOrderItem> results = new List<IOrderItem>();

            if (min == null)
            {
                foreach (IOrderItem item in menu)
                {
                    
                    if (item.Price <= max)
                        results.Add(item);
                }
            }
            else if (max == null)
            {
                foreach (IOrderItem item in menu)
                {
                    if (item is Drink drink)
                    {
                        drink = SwapSize(drink);

                        if (min <= drink.Price)
                            results.Add(item);

                        drink = SwapSize(drink);
                    }
                    else if (item is Side side)
                    {
                        side = SwapSize(side);

                        if (min <= side.Price)
                            results.Add(item);

                        side = SwapSize(side);
                    }
                    else
                    {
                        if (min <= item.Price)
                            results.Add(item);
                    }
                }
            }
            else
            {
                foreach (IOrderItem item in menu)
                {
                    if (item.Price <= max)
                    {
                        if (item is Drink drink)
                        {
                            drink = SwapSize(drink);

                            if (min <= drink.Price)
                                results.Add(item);

                            drink = SwapSize(drink);
                        }
                        else if (item is Side side)
                        {
                            side = SwapSize(side);

                            if (min <= side.Price)
                                results.Add(item);

                            side = SwapSize(side);
                        }
                        else
                        {
                            if (min <= item.Price)
                                results.Add(item);
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Swaps side paramter with Size Small=>Large/Large=>Small
        /// </summary>
        /// <param name="side">Side to swap</param>
        /// <returns>Size swapped side</returns>
        private static Side SwapSize(Side side)
        {
            if (side.Size == Size.Small)
                side.Size = Size.Large;
            else
                side.Size = Size.Small;

            return side;
        }

        /// <summary>
        /// Swaps drink paramter with Size Small=>Large/Large=>Small
        /// </summary>
        /// <param name="drink">Drink to swap</param>
        /// <returns>Size swapped drink</returns>
        private static Drink SwapSize(Drink drink)
        {
            if (drink.Size == Size.Small)
                drink.Size = Size.Large;
            else
                drink.Size = Size.Small;

            return drink;
        }
    }
}
