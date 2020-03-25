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
    public class CowpokeChiliPropertyChangedTests
    {
        [Fact]
        public void CowpokeChiliShouldImplementINotifyPropertyChanged()
        {
            var chili = new CowpokeChili();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(chili);
        }

        [Theory]
        [InlineData("Cheese")]
        [InlineData("SourCream")]
        [InlineData("GreenOnions")]
        [InlineData("TortillaStrips")]
        public void ChangingPropertyShouldInvokePropertyChanged(string propertyName)
        {
            var chili = new CowpokeChili();
            
            Assert.PropertyChanged(chili, propertyName, () =>
            {
                switch (propertyName)
                {
                    case "Cheese":
                        chili.Cheese = false;
                        break;
                    case "SourCream":
                        chili.SourCream = false;
                        break;
                    case "GreenOnions":
                        chili.GreenOnions = false;
                        break;
                    case "TortillaStrips":
                        chili.TortillaStrips = false;
                        break;
                }
            });
        }

        [Fact]
        public void ChangingPropertyShouldInvokePropertyChangeForSpecialInstructions()
        {
            var chili = new CowpokeChili();

            Assert.PropertyChanged(chili, "SpecialInstructions", () => { chili.Cheese = false; });
            Assert.PropertyChanged(chili, "SpecialInstructions", () => { chili.SourCream = false; });
            Assert.PropertyChanged(chili, "SpecialInstructions", () => { chili.GreenOnions = false; });
            Assert.PropertyChanged(chili, "SpecialInstructions", () => { chili.TortillaStrips = false; });
        }
    }
}
