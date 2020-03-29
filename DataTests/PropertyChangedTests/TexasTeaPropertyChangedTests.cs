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
    public class TexasTeaPropertyChangedTests
    {
        [Fact]
        public void CowboyCoffeeShouldImplementINotifyPropertyChanged()
        {
            var tea = new TexasTea();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tea);
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChanged()
        {
            var tea = new TexasTea();

            Assert.PropertyChanged(tea, "Size", () => { tea.Size = Size.Large; });
            Assert.PropertyChanged(tea, "Size", () => { tea.Size = Size.Medium; });
            Assert.PropertyChanged(tea, "Size", () => { tea.Size = Size.Small; });
           
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChangeForPriceAndCalories()
        {
            var tea = new TexasTea();

            Assert.PropertyChanged(tea, "Price", () => { tea.Size = Size.Large; });
            Assert.PropertyChanged(tea, "Calories", () => { tea.Size = Size.Medium; });
        }


        [Fact]
        public void ChangingSweetShouldInvokePropertyChangeForCalories()
        {
            var tea = new TexasTea();

            Assert.PropertyChanged(tea, "Calories", () => { tea.Sweet = false; });
        }

        [Theory]
        [InlineData("Sweet")]
        [InlineData("Lemon")]
        [InlineData("Ice")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var tea = new TexasTea();

            Assert.PropertyChanged(tea, propertyName, () =>
            {
                switch (propertyName)
                {
                    case "Sweet":
                        tea.Sweet = false;
                        break;
                    case "Lemon":
                        tea.Lemon = true;
                        break;
                    case "Ice":
                        tea.Ice = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var tea = new TexasTea();

            Assert.PropertyChanged(tea, "SpecialInstructions", () => { tea.Lemon = true; });
            Assert.PropertyChanged(tea, "SpecialInstructions", () => { tea.Ice = false; });
        }
    }
}
