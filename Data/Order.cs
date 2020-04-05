using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing one order.
    /// </summary>
    public class Order : INotifyPropertyChanged
    {
        /// <summary>
        /// Tax rate
        /// </summary>
        private const double TaxRate = 0.16;

        /// <summary>
        /// Static variable for number of orders since program has begun.
        /// </summary>
        private static uint lastOrderNumber = 0;

        /// <summary>
        /// The order number of this current order.
        /// </summary>
        public uint OrderNumber = 0;

        /// <summary>
        /// Order constructor.
        /// </summary>
        public Order() 
        { 
            OrderNumber = lastOrderNumber++; 
        }

        /// <summary>
        /// Event handler which is invoked if item is added or removed from list.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The sum of all the items in the order.
        /// </summary>
        public double Subtotal
        {
            get
            {
                double subtotal = 0;
                foreach(IOrderItem item in Items)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }

        /// <summary>
        /// Tthe tax value of the order.
        /// </summary>
        public double Tax => Subtotal * TaxRate;

        /// <summary>
        /// The total cost of the order including tax.
        /// </summary>
        public double Total => Subtotal + Tax;


        private double paid = 0.0;
        /// <summary>
        /// Amount customer has paid.
        /// </summary>
        public double Paid
        {
            get { return paid; }
            set 
            { 
                if (value == paid) return;
                paid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Paid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Owed"));
            }
        }

        /// <summary>
        /// Amount customer owes (if negative represents the customer's change)
        /// </summary>
        public double Owed => (double)((decimal)Total - (decimal)Paid);
        

        /// <summary>
        /// Private variable which holds the items in the order.
        /// </summary>
        List<IOrderItem> items = new List<IOrderItem>();

        /// <summary>
        /// The Enumerable variable for the items in the order.
        /// </summary>
        public IEnumerable<IOrderItem> Items => items.ToArray();

        /// <summary>
        /// Adds new item to the order.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void Add(IOrderItem item) 
        {
            if (item == null) return;
            items.Add(item);
        if (item is INotifyPropertyChanged pcitem)
            {
                pcitem.PropertyChanged += OnItemChanged;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Owed"));
        }

        /// <summary>
        /// Removes item from order.
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void Remove(IOrderItem item) 
        {
            if (item == null) return;
            items.Remove(item);
            if (item is INotifyPropertyChanged pcitem)
            {
               pcitem.PropertyChanged -= OnItemChanged;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Owed"));
        }

        /// <summary>
        /// Overrides the order's ToString.
        /// </summary>
        /// <returns>The order number in friendly format.</returns>
        public override string ToString()
        {
            return "Order #" + OrderNumber.ToString();
        }

        private void OnItemChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            if (e.PropertyName == "Price")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Owed"));
            }
        }
    }
}
