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
using PointOfSale.CustomizationScreens;
using PointOfSale.ExtensionMethods;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// OrderSummaryControl Constructor
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        public void OnDeleteItemClick(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button) order.Remove(button.DataContext as IOrderItem);
            }
        }

        private void OnRecustomizeClick(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    if (button.DataContext is IOrderItem item)
                    {
                        var orderControl = this.FindAncestor<OrderControl>();

                        if (item is Entree entree)
                        {
                            if (entree is AngryChicken angryChicken)
                            {
                                var screen = new AngryChickenCustomizations();
                                screen.DataContext = angryChicken;
                                orderControl?.SwapScreen(screen);
                            }
                        }
                    }
                }
            }
        }
    }
}
