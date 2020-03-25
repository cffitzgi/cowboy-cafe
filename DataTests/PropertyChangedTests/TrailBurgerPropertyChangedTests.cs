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
    public class TrailBurgerPropertyChangedTests
    {
        [Fact]
        public void TrailBurgerShouldImplementINotifyPropertyChanged()
        {
            var burger = new TrailBurger();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(burger);
        }

        [Theory]
        [InlineData("Bun")]
        [InlineData("Ketchup")]
        [InlineData("Mustard")]
        [InlineData("Pickle")]
        [InlineData("Cheese")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var burger = new TrailBurger();
            
            Assert.PropertyChanged(burger, propertyName, () =>
            {
                switch (propertyName)
                {
                    case "Bun":
                        burger.Bun = false;
                        break;
                    case "Ketchup":
                        burger.Ketchup = false;
                        break;
                    case "Mustard":
                        burger.Mustard = false;
                        break;
                    case "Pickle":
                        burger.Pickle = false;
                        break;
                    case "Cheese":
                        burger.Cheese = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var burger = new TrailBurger();

            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Bun = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Ketchup = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Mustard = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Pickle = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Cheese = false; });
        }
    }
}
