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
    /// Interaction logic for WaterCustomizations.xaml
    /// </summary>
    public partial class WaterCustomizations : UserControl
    {
        /// <summary>
        /// Customization screen constructor
        /// </summary>
        public WaterCustomizations()
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
            if (DataContext is Drink water)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        case "Small":
                            water.Size = CowboyCafe.Data.Size.Small;
                            break;
                        case "Medium":
                            water.Size = CowboyCafe.Data.Size.Medium;
                            break;
                        case "Large":
                            water.Size = CowboyCafe.Data.Size.Large;
                            break;
                    }
                }
            }
        }
    }
}
