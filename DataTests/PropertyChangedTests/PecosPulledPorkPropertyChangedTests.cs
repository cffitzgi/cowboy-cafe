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
    public class PecosPulledPorkPropertyChangedTests
    {
        [Fact]
        public void PecosPulledPorkShouldImplementINotifyPropertyChanged()
        {
            var pork = new PecosPulledPork();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(pork);
        }

        [Theory]
        [InlineData("Bread")]
        [InlineData("Pickle")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var pork = new PecosPulledPork();
            
            Assert.PropertyChanged(pork, propertyName, () =>
            {
                switch (propertyName)
                {
                    case "Bread":
                        pork.Bread = false;
                        break;
                    case "Pickle":
                        pork.Pickle = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var pork = new PecosPulledPork();

            Assert.PropertyChanged(pork, "SpecialInstructions", () => { pork.Bread = false; });
            Assert.PropertyChanged(pork, "SpecialInstructions", () => { pork.Pickle = false; });
        }
    }
}
