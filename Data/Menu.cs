using System;
using System.Collections.Generic;
using System.Text;
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

        /*public static IEnumerable<IOrderItem> FilterByCategory(IEnumerable<IOrderItem> menu, IEnumerable<string> categories)
        {

        }

        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> menu, int? min, int? max)
        {

        }

        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> menu, double? min, double? max)
        {

        }*/
    }
}
