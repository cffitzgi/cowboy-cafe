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
    public class WaterPropertyChangedTests
    {
        [Fact]
        public void CowboyCoffeeShouldImplementINotifyPropertyChanged()
        {
            var water = new Water();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(water);
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChanged()
        {
            var water = new Water();

            Assert.PropertyChanged(water, "Size", () => { water.Size = Size.Large; });
            Assert.PropertyChanged(water, "Size", () => { water.Size = Size.Medium; });
            Assert.PropertyChanged(water, "Size", () => { water.Size = Size.Small; });
           
        }

        [Theory]
        [InlineData("Ice")]
        [InlineData("Lemon")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var water = new Water();

            Assert.PropertyChanged(water, propertyName, () =>
            {
                switch (propertyName)
                {
                    case "Lemon":
                        water.Lemon = true;
                        break;
                    case "Ice":
                        water.Ice = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var water = new Water();

            Assert.PropertyChanged(water, "SpecialInstructions", () => { water.Lemon = true; });
            Assert.PropertyChanged(water, "SpecialInstructions", () => { water.Ice = false; });
        }
    }
}
