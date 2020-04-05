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
using CashRegister;
using PointOfSale.ExtensionMethods;

namespace PointOfSale.TransactionScreens
{
    /// <summary>
    /// Interaction logic for CardPaymentControl.xaml
    /// </summary>
    public partial class CardPaymentControl : UserControl
    {
        /// <summary>
        /// Constructor for card payment control
        /// </summary>
        public CardPaymentControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// The value which the user inputs.
        /// </summary>
        private double inputValue;

        
        /// <summary>
        /// Sets the InputvalueTextBlock equal to parameter.
        /// </summary>
        /// <param name="text">What to set the InputValueTextBlock to</param>
        private void setInputText(string text)
        {
            InputValueTextBlock.Text = text;
        }

        /// <summary>
        /// Displays a formated error to InputValueTextBlock
        /// </summary>
        /// <param name="text">The error to display.</param>
        private void errorDisplay(string text)
        {
            setInputText("### " + text + " ###");
        }

        /// <summary>
        /// Sets the InputValueTextBlock to the amount still owed in order formatted as US currency.
        /// </summary>
        public void PaymentValue()
        {
            if (DataContext is Order order)
            {
                inputValue = order.Owed;
                setInputText(inputValue.ToString("C2"));
            }
        }

        /// <summary>
        /// Instance of ReceiptPrinter class
        /// </summary>
        private ReceiptPrinter printer = new ReceiptPrinter();

        /// <summary>
        /// Sends inputted payment value to charge the card.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Event arguments</param>
        void OnSendClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    if (inputValue > order.Owed)
                    {
                        errorDisplay("OVERCHARGE");
                    }
                    else
                    {
                        var terminal = new CardTerminal();
                        var swipeResult = terminal.ProcessTransaction(inputValue);
                        switch (swipeResult)
                        {
                            case ResultCode.Success:
// TODO : IMPLEMENT RECEIPT FORMATTER EXTENSION METHOD/CLASS
                                order.Paid += inputValue;
                                printer.Print("TODO IMPLEMENT");
                                if (order.Owed <= 0)
                                {
                                    var orderControl = this.FindAncestor<OrderControl>();
                                    orderControl.DataContext = new Order();
                                    orderControl.SwapScreen(new MenuItemSelectionControl());
                                }
                                else PaymentValue();
                                break;
                            case ResultCode.ReadError:
                                errorDisplay("READ ERROR");
                                break;
                            case ResultCode.InsufficentFunds:
                                errorDisplay("INSUFFICIENT FUNDS");
                                break;
                            case ResultCode.CancelledCard:
                                errorDisplay("CANCELLED CARD");
                                break;
                            case ResultCode.UnknownErrror:
                                errorDisplay("UNKNOWN ERROR");
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clears the InputValueTextBlock and sets inputValue to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnClearClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    inputValue = 0;
                    InputValueTextBlock.Text = inputValue.ToString("C2");
                }
            }
        }

        /// <summary>
        /// If the numpad has not been touched yet.
        /// </summary>
        private bool isFirstChange = true;
        /// <summary>
        /// Handles button click events for numpad keys.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Event arguments</param>
        void OnNumpadClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    if (isFirstChange)
                    {
                        inputValue = 0;
                        isFirstChange = false;
                    }

                    switch (button.Tag)
                    {
                        case "Click_0":
                            AddLastDigit(0);
                            break;
                        case "Click_1":
                            AddLastDigit(1);
                            break;
                        case "Click_2":
                            AddLastDigit(2);
                            break;
                        case "Click_3":
                            AddLastDigit(3);
                            break;
                        case "Click_4":
                            AddLastDigit(4);
                            break;
                        case "Click_5":
                            AddLastDigit(5);
                            break;
                        case "Click_6":
                            AddLastDigit(6);
                            break;
                        case "Click_7":
                            AddLastDigit(7);
                            break;
                        case "Click_8":
                            AddLastDigit(8);
                            break;
                        case "Click_9":
                            AddLastDigit(9);
                            break;
                        case "Click_Backspace":
                            RemoveLastDigit();
                            break;
                    }
                    InputValueTextBlock.Text = inputValue.ToString("C2");
                }
            }
        }

        /// <summary>
        /// Adds the last digit onto the inputValue.
        /// </summary>
        /// <param name="digit"></param>
        void AddLastDigit(int digit)
        {
            inputValue = (inputValue * 10) + ((double)digit / 100);
        }

        /// <summary>
        /// Removes the last digit from the inputValue.
        /// </summary>
        void RemoveLastDigit()
        {
            int newValue = (int)(inputValue * 10.0);
            inputValue = (double)newValue / 100.0;

        }
    }
}
