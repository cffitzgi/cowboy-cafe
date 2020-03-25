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
    public class DakotaDoubleBurgerPropertyChangedTests
    {
        [Fact]
        public void DakotaDoubleBurgerShouldImplementINotifyPropertyChanged()
        {
            var burger = new DakotaDoubleBurger();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(burger);
        }

        [Theory]
        [InlineData("Bun")]
        [InlineData("Ketchup")]
        [InlineData("Mustard")]
        [InlineData("Pickle")]
        [InlineData("Cheese")]
        [InlineData("Tomato")]
        [InlineData("Lettuce")]
        [InlineData("Mayo")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var burger = new DakotaDoubleBurger();
            
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
                    case "Tomato":
                        burger.Tomato = false;
                        break;
                    case "Lettuce":
                        burger.Lettuce = false;
                        break;
                    case "Mayo":
                        burger.Mayo = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var burger = new DakotaDoubleBurger();
                                                                        ////////////////
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Bun = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Ketchup = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Mustard = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Pickle = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Cheese = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Tomato = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Lettuce = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Mayo = false; });
        }                                                               ////////////////
    }
}
