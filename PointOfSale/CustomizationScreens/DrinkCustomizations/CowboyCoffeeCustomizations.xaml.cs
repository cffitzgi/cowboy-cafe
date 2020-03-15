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
using PointOfSale.ExtensionMethods;

namespace PointOfSale.CustomizationScreens.DrinkCustomizations
{
    /// <summary>
    /// Interaction logic for CowboyCoffeeCustomizations.xaml
    /// </summary>
    public partial class CowboyCoffeeCustomizations : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CowboyCoffeeCustomizations()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Size selection button handler.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="args">Arguments</param>
        void OnSizeSelection(object sender, RoutedEventArgs args)
        {
            if (DataContext is Drink coffee)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        case "Small":
                            coffee.Size = CowboyCafe.Data.Size.Small;
                            break;
                        case "Medium":
                            coffee.Size = CowboyCafe.Data.Size.Medium;
                            break;
                        case "Large":
                            coffee.Size = CowboyCafe.Data.Size.Large;
                            break;
                    }
                }
            }
        }
    }
}
