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
        /// <summary>
        /// Creates static enumeration of a single instance of every entree.
        /// </summary>
        /// <returns>Enumeration of every entree</returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            var entrees = new List<Entree>();

            entrees.Add(new AngryChicken());
            entrees.Add(new CowpokeChili());
            entrees.Add(new DakotaDoubleBurger());
            entrees.Add(new PecosPulledPork());
            entrees.Add(new RustlersRibs());
            entrees.Add(new TexasTripleBurger());
            entrees.Add(new TrailBurger());

            return entrees.ToArray();
        }

        /// <summary>
        /// Creates static enumeration of a single instance of every side.
        /// </summary>
        /// <returns>Enumeration of every side</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            var sides = new List<Side>();

            sides.Add(new BakedBeans());
            sides.Add(new ChiliCheeseFries());
            sides.Add(new CornDodgers());
            sides.Add(new PanDeCampo());

            return sides.ToArray();
        }

        /// <summary>
        /// Creates static enumeration of a single instance of every drink.
        /// </summary>
        /// <returns>Enumeration of every drink</returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            var drinks = new List<Drink>();

            drinks.Add(new CowboyCoffee());
            drinks.Add(new JerkedSoda());
            drinks.Add(new TexasTea());
            drinks.Add(new Water());

            return drinks.ToArray();
        }

        /// <summary>
        /// Creates static enumeration of a single instance of every menu item.
        /// </summary>
        /// <returns>Enumeration of every menu item</returns>
        public static IEnumerable<IOrderItem> CompleteMenu()
        {
            var completeMenu = new List<IOrderItem>();

            foreach(Entree entree in Entrees()) { completeMenu.Add(entree); }
            foreach(Side side in Sides()) { completeMenu.Add(side); }
            foreach(Drink drink in Drinks()) { completeMenu.Add(drink); }

            return completeMenu.ToArray();
        }
    }
}
