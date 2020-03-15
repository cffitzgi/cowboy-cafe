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
using PointOfSale.ExtensionMethods;
using PointOfSale.CustomizationScreens.SideCustomizations;
using PointOfSale.CustomizationScreens.DrinkCustomizations;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// OrderSummaryControl Constructor
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles item deletion.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="args">Arguments</param>
        public void OnDeleteItemClick(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    var orderControl = this.FindAncestor<OrderControl>();

                    if (!(orderControl.Container.Child is MenuItemSelectionControl))
                        orderControl?.SwapScreen(new MenuItemSelectionControl());
                    order.Remove(button.DataContext as IOrderItem);

                }
            }
        }

        /// <summary>
        /// Opens corresponding customization screen when item is clicked on
        /// </summary>
        /// <param name="sender">Button containing item in summary display</param>
        /// <param name="args">Arguments</param>
        private void OnRecustomizeClick(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    if (button.DataContext is IOrderItem item)
                    {
                        var orderControl = this.FindAncestor<OrderControl>();

                        if (item is Entree entree)
                        {
                            if (entree is AngryChicken angryChicken)
                            {
                                var screen = new AngryChickenCustomizations();
                                screen.DataContext = angryChicken;
                                orderControl?.SwapScreen(screen);
                            }
                            else if(entree is CowpokeChili cowpokeChili)
                            {
                                var screen = new CowpokeChiliCustomizations();
                                screen.DataContext = cowpokeChili;
                                orderControl?.SwapScreen(screen);
                            }
                            else if (entree is DakotaDoubleBurger dakotaDoubleBurger)
                            {
                                var screen = new DakotaDoubleBurgerCustomizations();
                                screen.DataContext = dakotaDoubleBurger;
                                orderControl?.SwapScreen(screen);
                            }
                            else if (entree is PecosPulledPork pecosPulledPork)
                            {
                                var screen = new PecosPulledPorkCustomizations();
                                screen.DataContext = pecosPulledPork;
                                orderControl?.SwapScreen(screen);
                            }
                            else if (entree is TexasTripleBurger texasTripleBurger)
                            {
                                var screen = new TexasTripleBurgerCustomizations();
                                screen.DataContext = texasTripleBurger;
                                orderControl?.SwapScreen(screen);
                            }
                            else if (entree is TrailBurger trailBurger)
                            {
                                var screen = new TrailBurgerCustomizations();
                                screen.DataContext = trailBurger;
                                orderControl?.SwapScreen(screen);
                            }
                        }

                        else if(item is Side side)
                        {
                            string tag;
                            if (side is BakedBeans)
                                tag = "Baked Beans";
                            else if (side is ChiliCheeseFries)
                                tag = "Chili Cheese Fries";
                            else if (side is CornDodgers)
                                tag = "Corn Dodgers";
                            else
                                tag = "Pan De Campo";

                            var screen = new SideCustomizations(tag);
                            screen.DataContext = side;
                            orderControl?.SwapScreen(screen);
                        }

                        else if(item is Drink drink)
                        {
                            if (drink is CowboyCoffee cowboyCoffee)
                            {
                                var screen = new CowboyCoffeeCustomizations();
                                screen.DataContext = cowboyCoffee;
                                orderControl?.SwapScreen(screen);
                            }
                            else if (drink is JerkedSoda jerkedSoda)
                            {
                                var screen = new JerkedSodaCustomizations();
                                screen.DataContext = jerkedSoda;
                                orderControl?.SwapScreen(screen);
                            }
                            else if (drink is TexasTea texasTea)
                            {
                                var screen = new TexasTeaCustomizations();
                                screen.DataContext = texasTea;
                                orderControl?.SwapScreen(screen);
                            }
                            else if (drink is Water water)
                            {
                                var screen = new WaterCustomizations();
                                screen.DataContext = water;
                                orderControl?.SwapScreen(screen);
                            }
                        }
                    }
                }
            }
        }
    }
}
