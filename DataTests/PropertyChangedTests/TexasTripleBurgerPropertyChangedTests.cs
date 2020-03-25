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
    public class TexasTripleBurgerPropertyChangedTests
    {
        [Fact]
        public void TexasTripleBurgerShouldImplementINotifyPropertyChanged()
        {
            var burger = new TexasTripleBurger();
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
        [InlineData("Bacon")]
        [InlineData("Egg")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var burger = new TexasTripleBurger();
            
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
                    case "Bacon":
                        burger.Bacon = false;
                        break;
                    case "Egg":
                        burger.Egg = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var burger = new TexasTripleBurger();

            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Bun = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Ketchup = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Mustard = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Pickle = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Cheese = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Tomato = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Lettuce = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Mayo = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Bacon = false; });
            Assert.PropertyChanged(burger, "SpecialInstructions", () => { burger.Egg = false; });
        }
    }
}
