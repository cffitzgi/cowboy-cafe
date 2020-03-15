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

namespace PointOfSale.CustomizationScreens.SideCustomizations
{
    /// <summary>
    /// Interaction logic for SideCustomizations.xaml
    /// </summary>
    public partial class SideCustomizations : UserControl
    {
        public SideCustomizations()
        {
            InitializeComponent();
        }

        public SideCustomizations(string sideName)
        {
            InitializeComponent();
            TitleBlock.Text = sideName + " Customizations";
        }

        void OnSizeSelection(object sender, RoutedEventArgs args)
        {
            var orderControl = this.FindAncestor<OrderControl>();

            if (DataContext is Side side)
            {
                if (sender is Button button)
                {
                    switch(button.Tag)
                    {
                        case "Small":
                            side.Size = CowboyCafe.Data.Size.Small;
                            break;
                        case "Medium":
                            side.Size = CowboyCafe.Data.Size.Medium;
                            break;
                        case "Large":
                            side.Size = CowboyCafe.Data.Size.Large;
                            break;
                    }
                }
            }
        }
    }
}
