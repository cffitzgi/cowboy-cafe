using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests
{
    public class OrderTests
    {
        /// <summary>
        /// Mock class for tests
        /// </summary>
        public class MockOrderItem : IOrderItem
        {
            public double Price { get; set; }

            public uint Calories { get; set; }

            public List<string> SpecialInstructions { get; set; } = new List<string>();
        }

        [Fact]
        public void ShouldAddItems()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            Assert.Contains(item, order.Items);
        }
       
        [Fact]
        public void ShouldRemoveItems()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            order.Remove(item);
            Assert.DoesNotContain(item, order.Items);
        }

        [Fact]
        public void ShouldGetTheEnumerationOfItems()
        {
            var order = new Order();
            var item0 = new MockOrderItem();
            var item1 = new MockOrderItem();
            var item2 = new MockOrderItem();
            order.Add(item0);
            order.Add(item1);
            order.Add(item2);
            Assert.Collection(order.Items,
                item => Assert.Equal(item0, item),
                item => Assert.Equal(item1, item),
                item => Assert.Equal(item2, item)); 
        }

        [Theory]
        [InlineData(new double[] { 1, 2, 3 })]
        [InlineData(new double[] { 0, 0.0, 0 })]
        [InlineData(new double[] { 199, 31 })]
        [InlineData(new double[] { 69.54, 420, 2.1, 3, 4 })]
        [InlineData(new double[] { 1.11 })]
        [InlineData(new double[] { })]
        [InlineData(new double[] { -5.78 })]
        [InlineData(new double[] { -4, 10, -8 })]
        [InlineData(new double[] { 3.14159265, 34.12342352332862 })]
        [InlineData(new double[] { double.NaN })]
        public void SumOfItemsShouldEqualSubtotal(double[] prices)
        {
            var order = new Order();
            double total = 0;
            foreach(var price in prices)
            {
                total += price;
                order.Add(new MockOrderItem() { Price = price });
            }
            Assert.Equal(total, order.Subtotal);
        }

        [Theory]
        [InlineData("Subtotal")]
        [InlineData("Items")]
        public void AddingItemShouldTriggerPropertyChanged(string propertyName)
        {
            var order = new Order();
            var item = new MockOrderItem();
            Assert.PropertyChanged(order, propertyName, () => { order.Add(item); } );
        }

        [Theory]
        [InlineData("Subtotal")]
        [InlineData("Items")]
        public void RemovingItemShouldTriggerPropertyChanged(string propertyName)
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            Assert.PropertyChanged(order, propertyName, () => { order.Remove(item); });

        }
    }
}
