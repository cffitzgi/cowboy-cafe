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
    /// Interaction logic for TexasTeaCustomizations.xaml
    /// </summary>
    public partial class TexasTeaCustomizations : UserControl
    {
        /// <summary>
        /// Customization screen constructor
        /// </summary>
        public TexasTeaCustomizations()
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
            if (DataContext is Drink tea)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        case "Small":
                            tea.Size = CowboyCafe.Data.Size.Small;
                            break;
                        case "Medium":
                            tea.Size = CowboyCafe.Data.Size.Medium;
                            break;
                        case "Large":
                            tea.Size = CowboyCafe.Data.Size.Large;
                            break;
                    }
                }
            }
        }
    }
}
