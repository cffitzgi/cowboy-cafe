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
using PointOfSale.TransactionScreens.CashControls;
using System.ComponentModel;

namespace PointOfSale.TransactionScreens
{
    /// <summary>
    /// Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        /// <summary>
        /// Constructor for TransactionControl
        /// </summary>
        public TransactionControl()
        {
            InitializeComponent();
            
        }


        void OnPaidAmountChange(object sender, PropertyChangedEventArgs e)
        {
            if (DataContext is Order order)
            {
                    if (e.PropertyName == "Owed")
                    {
                        if (order.Owed < 0) OwedOrChange.Text = "Change";
                        else OwedOrChange.Text = "Owed";
                    }
                
            }
        }

        /// <summary>
        /// Click event handler for Cash Payment selection
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="args">Event arguments</param>
        void OnCashPaymentButtonClicked(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    var orderControl = this.FindAncestor<OrderControl>();

                    order.PropertyChanged += OnPaidAmountChange;

                    CashButton.IsEnabled = false;
                    CardButton.IsEnabled = true;


                    var screen = new CashPaymentControl(order);
                    screen.DataContext = orderControl.Register;
                    screen.InitializeContext();
                    SwapScreen(screen);
                }
            }
        }

        /// <summary>
        /// Click event handler for Card Payment selection
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="args">Event arguments</param>
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
                    screen.StartingPaymentValue();
                    SwapScreen(screen);
                }
            }
        }

        /// <summary>
        /// Click event handler for Transaction Cancelation 
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="args">Event arguments</param>
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

        /// <summary>
        /// Click event handler for Cash Payment selection
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="args">Event arguments</param>
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
        /// <param name="element">Screen to swap to</param>
        public void SwapScreen(FrameworkElement element)
        {
            Container.Child = element;
        }
    }
}
