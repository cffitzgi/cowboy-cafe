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
    public class CowboyCoffeePropertyChangedTests
    {
        [Fact]
        public void CowboyCoffeeShouldImplementINotifyPropertyChanged()
        {
            var coffee = new CowboyCoffee();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(coffee);
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChanged()
        {
            var coffee = new CowboyCoffee();

            Assert.PropertyChanged(coffee, "Size", () => { coffee.Size = Size.Large; });
            Assert.PropertyChanged(coffee, "Size", () => { coffee.Size = Size.Medium; });
            Assert.PropertyChanged(coffee, "Size", () => { coffee.Size = Size.Small; });
           
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChangeForPriceAndCalories()
        {
            var coffee = new CowboyCoffee();

            Assert.PropertyChanged(coffee, "Price", () => { coffee.Size = Size.Large; });
            Assert.PropertyChanged(coffee, "Calories", () => { coffee.Size = Size.Medium; });
        }
    }
}
