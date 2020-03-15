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
using PointOfSale.CustomizationScreens;
using PointOfSale.CustomizationScreens.DrinkCustomizations;
using PointOfSale.CustomizationScreens.SideCustomizations;
using PointOfSale.ExtensionMethods;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// MenuItemSelectionControl constructor.
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        void OnAddOrderItemButtonClicked(object sender, RoutedEventArgs args)
        {
            var orderControl = this.FindAncestor<OrderControl>();

            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        //Entrees
                        case "AngryChicken":
                            {
                                var item = new AngryChicken();
                                var screen = new AngryChickenCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "CowpokeChili":
                            {
                                var item = new CowpokeChili();
                                var screen = new CowpokeChiliCustomization();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "DakotaDoubleBurger":
                            {
                                var item = new DakotaDoubleBurger();
                                var screen = new DakotaDoubleBurgerCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "PecosPulledPork":
                            {
                                var item = new PecosPulledPork();
                                var screen = new PecosPulledPorkCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "RustlersRibs":
                            {
                                var item = new RustlersRibs();
                                order.Add(item);
                            }
                            break;
                        case "TexasTripleBurger":
                            {
                                var item = new TexasTripleBurger();
                                var screen = new TexasTripleBurgerCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "TrailBurger":
                            {
                                var item = new TrailBurger();
                                var screen = new TrailBurgerCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;

                        //Sides
                        case "BakedBeans":
                            {
                                var item = new BakedBeans();
                                var screen = new SideCustomizations("Baked Beans");
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "ChiliCheeseFries":
                            {
                                var item = new ChiliCheeseFries();
                                var screen = new SideCustomizations("Chili Cheese Fries");
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "CornDodgers":
                            {
                                var item = new CornDodgers();
                                var screen = new SideCustomizations("Corn Dodgers");
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "PanDeCampo":
                            {
                                var item = new PanDeCampo();
                                var screen = new SideCustomizations("Pan De Campo");
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        // Drinks
                        case "CowboyCoffee":
                            {
                                var item = new CowboyCoffee();
                                var screen = new CowboyCoffeeCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "JerkedSoda":
                            {
                                var item = new JerkedSoda();
                                var screen = new JerkedSodaCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "TexasTea":
                            {
                                var item = new TexasTea();
                                var screen = new TexasTeaCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                        case "Water":
                            {
                                var item = new Water();
                                var screen = new WaterCustomizations();
                                screen.DataContext = item;
                                order.Add(item);
                                orderControl?.SwapScreen(screen);
                            }
                            break;
                    }
                }
            }
        }
    }
}
