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
using PointOfSale.TransactionScreens;
using PointOfSale.ExtensionMethods;
using PointOfSale.TransactionScreens.CashControls;

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
            Register = new CashRegisterModelView();

            this.DataContext = order;
        }

        public CashRegisterModelView Register { get; private set; }

        /// <summary>
        /// Returns to default OrderControl selection menu.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguement</param>
        private void ItemSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            SwapScreen(new MenuItemSelectionControl()); 
        }

        /// <summary>
        /// Discards the current order and creates new empty order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Order();
            SwapScreen(new MenuItemSelectionControl());
        }
        
        /// <summary>
        /// Sends the current order and creates new empty order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (order.Items.Any())
                {
                    var screen = new TransactionControl();
                    //screen.DataContext = order;
                    //screen.InitializeContext();
                    SwapScreen(screen);
                }
                else
                {
                    SummaryControlScreen.ItemListView.BorderBrush = Brushes.Red;
                    SummaryControlScreen.ItemListView.BorderThickness = new Thickness(3);
                }
            }
        }

        /// <summary>
        /// Swaps screen in container.
        /// </summary>
        /// <param name="element"></param>
        public void SwapScreen(FrameworkElement element)
        {
            Container.Child = element;

            SummaryControlScreen.ItemListView.BorderBrush = Brushes.Black;
            SummaryControlScreen.ItemListView.BorderThickness = new Thickness(1);
        }
    }
}
