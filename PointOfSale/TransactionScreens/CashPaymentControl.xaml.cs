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
using CashRegister;
using CowboyCafe.Data;
using PointOfSale.TransactionScreens.CashControls;
using System.ComponentModel;

namespace PointOfSale.TransactionScreens
{
    /// <summary>
    /// Interaction logic for CashPaymentControl.xaml
    /// </summary>
    public partial class CashPaymentControl : UserControl
    {
        /// <summary>
        /// No parameter Constructor
        /// </summary>
        public CashPaymentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with order parameter.
        /// </summary>
        /// <param name="o">Current order in question.</param>
        public CashPaymentControl(Order o)
        {
            InitializeComponent();
            order = o;
        }

        /// <summary>
        /// Order being paid for.
        /// </summary>
        private Order order;

        /// <summary>
        /// Amount of cash in register at begining of transaction.
        /// </summary>
        private double startingRegisterAmount;

        /// <summary>
        /// Initializes event listener for Register amount
        /// </summary>
        public void InitializeContext()
        {
            if (DataContext is CashRegisterModelView register)
            {
                startingRegisterAmount = register.TotalValue;
                register.PropertyChanged += onRegisterAmountChange;
            }
        }


        /// <summary>
        /// When amount of cash in register has changed, updates order to reflect cash exchange.
        /// </summary>
        /// <param name="sender">Event</param>
        /// <param name="args">Event arguments</param>
        private void onRegisterAmountChange(object sender, PropertyChangedEventArgs args)
        {

            if (DataContext is CashRegisterModelView register)
            {
                if (args.PropertyName == "TotalValue")
                {
                    order.Paid = safeSubtraction(register.TotalValue, startingRegisterAmount);
                }
            }
        }

        /// <summary>
        /// Subtracts two doubles without rounding error (converts both to decimals)
        /// </summary>
        /// <param name="a">First double</param>
        /// <param name="b">Subtracted double</param>
        /// <returns>Difference of doubles.</returns>
        private double safeSubtraction(double a, double b)
        {
            return (double)((decimal)a - (decimal)b);
        }
    }
}
