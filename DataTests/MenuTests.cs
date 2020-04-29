using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Sides;
using CowboyCafe.Data.Drinks;


namespace CowboyCafe.DataTests
{
    public class MenuTests
    {

        [Fact]
        public void MenuEntreesShouldContainEverySingleEntree()
        {
            var entrees = new List<IOrderItem>(Menu.Entrees);
            entrees.Sort((a, b) => a.ToString().CompareTo(b.ToString()));

            Assert.Collection(
                entrees, 
                (ac) => { Assert.IsType<AngryChicken>(ac); },
                (cc) => { Assert.IsType<CowpokeChili>(cc); },
                (ddb) => { Assert.IsType<DakotaDoubleBurger>(ddb); },
                (ppp) => { Assert.IsType<PecosPulledPork>(ppp); },
                (rr) => { Assert.IsType<RustlersRibs>(rr); },
                (ttb) => { Assert.IsType<TexasTripleBurger>(ttb); },
                (tb) => { Assert.IsType<TrailBurger>(tb); }
                );
        }

        [Fact]
        public void MenuSidesShouldContainEverySingleSide()
        {
            var sides = new List<IOrderItem>(Menu.Sides);
            sides.Sort((a, b) => a.ToString().CompareTo(b.ToString()));

            Assert.Collection(
                sides,
                (bb) => { Assert.IsType<BakedBeans>(bb); },
                (ccf) => { Assert.IsType<ChiliCheeseFries>(ccf); },
                (cd) => { Assert.IsType<CornDodgers>(cd); },
                (pdc) => { Assert.IsType<PanDeCampo>(pdc); }
                );
        }

        [Fact]
        public void MenuDrinksShouldContainEverySingleDrink()
        {
            Assert.Collection(
                Menu.Drinks,
                (cc) => { Assert.IsType<CowboyCoffee>(cc); },
                (js) => { Assert.IsType<JerkedSoda>(js); },
                (tt) => { Assert.IsType<TexasTea>(tt); },
                (w) => { Assert.IsType<Water>(w); }
                );
        }

        [Fact]
        public void MenuAllShouldContainEverySingleItem()
        {
            Assert.Collection(
                Menu.CompleteMenu,
                (ac) => { Assert.IsType<AngryChicken>(ac); },
                (cc) => { Assert.IsType<CowpokeChili>(cc); },
                (ddb) => { Assert.IsType<DakotaDoubleBurger>(ddb); },
                (ppp) => { Assert.IsType<PecosPulledPork>(ppp); },
                (rr) => { Assert.IsType<RustlersRibs>(rr); },
                (ttb) => { Assert.IsType<TexasTripleBurger>(ttb); },
                (tb) => { Assert.IsType<TrailBurger>(tb); },
                (bb) => { Assert.IsType<BakedBeans>(bb); },
                (ccf) => { Assert.IsType<ChiliCheeseFries>(ccf); },
                (cd) => { Assert.IsType<CornDodgers>(cd); },
                (pdc) => { Assert.IsType<PanDeCampo>(pdc); },
                (cc) => { Assert.IsType<CowboyCoffee>(cc); },
                (js) => { Assert.IsType<JerkedSoda>(js); },
                (tt) => { Assert.IsType<TexasTea>(tt); },
                (w) => { Assert.IsType<Water>(w); }
                );
        }

        [Fact]
        public void SearchTermFilterWorks()
        {
            Assert.Collection(
                Menu.Search(Menu.CompleteMenu, "co"), 
                (cw) => { Assert.IsType<CowpokeChili>(cw); },
                (ppp) => { Assert.IsType<PecosPulledPork>(ppp); },
                (cd) => { Assert.IsType<CornDodgers>(cd); },
                (cc) => { Assert.IsType<CowboyCoffee>(cc); }
                );
        }

        [Fact]
        public void CategoryFilterWorks()
        {
            Assert.Collection(
                Menu.FilterByCategory(Menu.CompleteMenu, new string[] { "Entrees", "Drinks" }),

                (ac) => { Assert.IsType<AngryChicken>(ac); },
                (cc) => { Assert.IsType<CowpokeChili>(cc); },
                (ddb) => { Assert.IsType<DakotaDoubleBurger>(ddb); },
                (ppp) => { Assert.IsType<PecosPulledPork>(ppp); },
                (rr) => { Assert.IsType<RustlersRibs>(rr); },
                (ttb) => { Assert.IsType<TexasTripleBurger>(ttb); },
                (tb) => { Assert.IsType<TrailBurger>(tb); },

                (cc) => { Assert.IsType<CowboyCoffee>(cc); },
                (js) => { Assert.IsType<JerkedSoda>(js); },
                (tt) => { Assert.IsType<TexasTea>(tt); },
                (w) => { Assert.IsType<Water>(w); }
                );
        }

        [Fact]
        public void PriceFilterWorks()
        {
            Assert.Collection(
                Menu.FilterByPrice(Menu.CompleteMenu, 4.0, 5.0),
                (tb) => { Assert.IsType<TrailBurger>(tb); }
                );
        }

        [Fact]
        public void CalorieFilterWorks()
        {
            Assert.Collection(
                Menu.FilterByCalories(Menu.CompleteMenu, 400, 500),

                (ddb) => { Assert.IsType<DakotaDoubleBurger>(ddb); },

                (bb) => { Assert.IsType<BakedBeans>(bb); },
                (ccf) => { Assert.IsType<ChiliCheeseFries>(ccf); }
                );
        }
    }
}
