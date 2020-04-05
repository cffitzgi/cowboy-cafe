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
using PointOfSale.ExtensionMethods;
using CowboyCafe.Data;

namespace PointOfSale.TransactionScreens
{
    /// <summary>
    /// Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        public TransactionControl()
        {
            InitializeComponent();
        }

        void OnCashPaymentButtonClicked(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    CashButton.IsEnabled = false;
                    CardButton.IsEnabled = true;

                    var screen = new CashPaymentControl();
                    screen.DataContext = order;
                    SwapScreen(screen);
                }
            }
        }

        void OnCardPaymentButtonClicked(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    CashButton.IsEnabled = true;
                    CardButton.IsEnabled = false;

                    var screen = new CardPaymentControl();
                    screen.DataContext = order;
                    screen.PaymentValue();
                    SwapScreen(screen);
                }
            }
        }



        void OnCancelTransactionClicked(object sender, RoutedEventArgs e)
        {
            var orderControl = this.FindAncestor<OrderControl>();

            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    orderControl.DataContext = new Order();
                    orderControl.SwapScreen(new MenuItemSelectionControl());
                }
            }
        }

        void OnCompleteTransactionClicked(object sender, RoutedEventArgs e)
        {
            var orderControl = this.FindAncestor<OrderControl>();

            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    if (order.Owed <= 0)
                    {
                        orderControl.DataContext = new Order();
                        orderControl.SwapScreen(new MenuItemSelectionControl());
                    }
                    else
                    {
                        AmountOwedBorder.BorderBrush = Brushes.Red;
                        SwapScreen(null);
                        CashButton.IsEnabled = true;
                        CardButton.IsEnabled = true;
                    }
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
        }
    }
}
