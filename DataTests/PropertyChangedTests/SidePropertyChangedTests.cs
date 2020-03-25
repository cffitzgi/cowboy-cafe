using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Sides;
using CowboyCafe.Data.Drinks;
using System.ComponentModel;

namespace CowboyCafe.DataTests.PropertyChangedTests
{
    public class SidePropertyChangedTests
    {
        [Fact]
        public void SideShouldImplementINotifyPropertyChanged()
        {
            var side = new BakedBeans();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(side);
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChanged()
        {
            var side = new BakedBeans();

            Assert.PropertyChanged(side, "Size", () => { side.Size = Size.Large; });
            Assert.PropertyChanged(side, "Size", () => { side.Size = Size.Medium; });
            Assert.PropertyChanged(side, "Size", () => { side.Size = Size.Small; });
           
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChangeForPriceAndCalories()
        {
            var side = new BakedBeans();

            Assert.PropertyChanged(side, "Price", () => { side.Size = Size.Large; });
            Assert.PropertyChanged(side, "Calories", () => { side.Size = Size.Medium; });
        }
    }
}
