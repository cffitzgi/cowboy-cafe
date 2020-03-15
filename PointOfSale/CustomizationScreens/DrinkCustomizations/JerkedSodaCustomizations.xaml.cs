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

namespace PointOfSale.CustomizationScreens.DrinkCustomizations
{
    /// <summary>
    /// Interaction logic for JerkedSodaCustomizations.xaml
    /// </summary>
    public partial class JerkedSodaCustomizations : UserControl
    {
        public JerkedSodaCustomizations()
        {
            InitializeComponent();
        }


        void OnSizeSelection(object sender, RoutedEventArgs args)
        {
            if (DataContext is JerkedSoda soda)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        case "Small":
                            soda.Size = CowboyCafe.Data.Size.Small;
                            break;
                        case "Medium":
                            soda.Size = CowboyCafe.Data.Size.Medium;
                            break;
                        case "Large":
                            soda.Size = CowboyCafe.Data.Size.Large;
                            break;
                    }
                }
            }
        }


        void OnFlavorSelection(object sender, RoutedEventArgs args)
        {
            if (DataContext is JerkedSoda soda)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        case "BirchBeer":
                            soda.Flavor = SodaFlavor.BirchBeer;
                            break;
                        case "CreamSoda":
                            soda.Flavor = SodaFlavor.CreamSoda;
                            break;
                        case "OrangeSoda":
                            soda.Flavor = SodaFlavor.OrangeSoda;
                            break;
                        case "RootBeer":
                            soda.Flavor = SodaFlavor.RootBeer;
                            break;
                        case "Sarsparilla":
                            soda.Flavor = SodaFlavor.Sarsparilla;
                            break;
                    }
                }
            }
        }
    }
}
