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
    public class JerkedSodaPropertyChangedTests
    {
        [Fact]
        public void JerkedSodaShouldImplementINotifyPropertyChanged()
        {
            var soda = new JerkedSoda();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(soda);
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChanged()
        {
            var soda = new JerkedSoda();

            Assert.PropertyChanged(soda, "Size", () => { soda.Size = Size.Large; });
            Assert.PropertyChanged(soda, "Size", () => { soda.Size = Size.Medium; });
            Assert.PropertyChanged(soda, "Size", () => { soda.Size = Size.Small; });
           
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChangeForPriceAndCalories()
        {
            var soda = new JerkedSoda();

            Assert.PropertyChanged(soda, "Price", () => { soda.Size = Size.Large; });
            Assert.PropertyChanged(soda, "Calories", () => { soda.Size = Size.Medium; });
        }

        [Theory]
        [InlineData("Flavor")]
        [InlineData("Ice")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var soda = new JerkedSoda();
            Assert.PropertyChanged(soda, propertyName, () =>
            {
                switch (propertyName)
                {
                    case "Flavor":
                        soda.Flavor = SodaFlavor.Sarsparilla;
                        break;
                    case "Ice":
                        soda.Ice = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var soda = new JerkedSoda();

            Assert.PropertyChanged(soda, "SpecialInstructions", () => { soda.Ice = false; });
        }
    }
}
