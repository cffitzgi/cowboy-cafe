using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CowboyCafe.Data;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        /// <summary>
        /// Constructor for Order Control
        /// </summary>
        public OrderControl()
        {
            InitializeComponent();
            var order = new Order();

            this.DataContext = order;
        }

        /// <summary>
        /// Returns to default OrderControl selection menu.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguement</param>
        private void ItemSelectionButton_Click(object sender, RoutedEventArgs e)
        {
// TODO Implement
        }

        /// <summary>
        /// Discards the current order and creates new empty order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Order();
        }
        
        /// <summary>
        /// Sends the current order and creates new empty order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Order();
        }
    }
}
