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
        public CashPaymentControl()
        {
            InitializeComponent();
        }
        public CashPaymentControl(Order o)
        {
            InitializeComponent();
            order = o;
            
        }


        private Order order;

        private double startingRegisterAmount;

        private double endRegisterAmount => safeAddition(startingRegisterAmount, order.Total);

        public void InitializeContext()
        {
            if (DataContext is CashRegisterModelView register)
            {
                startingRegisterAmount = register.TotalValue;
                register.PropertyChanged += OnRegisterAmountChange;
            }
        }

        /// <summary>
        /// Instance of ReceiptPrinter class
        /// </summary>
        private ReceiptPrinter printer = new ReceiptPrinter();

        //private PropertyChangedEventHandler

        private void OnRegisterAmountChange(object sender, PropertyChangedEventArgs args)
        {

            if (DataContext is CashRegisterModelView register)
            {
                if (args.PropertyName == "TotalValue")
                {
                    order.Paid = safeSubtraction(register.TotalValue, startingRegisterAmount);
                    //if(order.Owed < 0) 
                }
            }
        }

        private double safeSubtraction(double a, double b)
        {
            return (double)((decimal)a - (decimal)b);
        }
        private double safeAddition(double a, double b)
        {
            return (double)((decimal)a + (decimal)b);
        }
    }
}
