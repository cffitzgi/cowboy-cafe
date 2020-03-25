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
    public class AngryChickenPropertyChangedTests
    {
        [Fact]
        public void AngryChickenShouldImplementINotifyPropertyChanged()
        {
            var chicken = new AngryChicken();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(chicken);
        }

        [Theory]
        [InlineData("Bread")]
        [InlineData("Pickle")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var chicken = new AngryChicken();
            Assert.PropertyChanged(chicken, propertyName, () =>
            {
                switch (propertyName)
                {
                    case "Bread":
                        chicken.Bread = false;
                        break;
                    case "Pickle":
                        chicken.Pickle = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var chicken = new AngryChicken();

            Assert.PropertyChanged(chicken, "SpecialInstructions", () => { chicken.Bread = false; });
            Assert.PropertyChanged(chicken, "SpecialInstructions", () => { chicken.Pickle = false; });
        }
    }
}
