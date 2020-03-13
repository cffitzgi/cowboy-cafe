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
                    }
                }
            }
        }

// ENTREE CLICK EVENT \\
        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddAngryChickenButton_Click(object sender, RoutedEventArgs e)
        {

            if (DataContext is Order order) order.Add(new AngryChicken());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddCowpokeChiliButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new CowpokeChili());

        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddDakotaDoubleBurgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new DakotaDoubleBurger());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddPecosPulledPork_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new PecosPulledPork());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddRustlersRibs_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new RustlersRibs());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddTexasTripleBurger_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new TexasTripleBurger());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddTrailBurger_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new TrailBurger());
        }

// SIDE CLICK EVENT 
        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddBakedBeans_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new BakedBeans());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddChiliCheeseFries_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new ChiliCheeseFries());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddCornDodgers_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new CornDodgers());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddPanDeCampo_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new PanDeCampo());
        }

// DRINK CLICK EVENT \\
        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddCowboyCoffee_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new CowboyCoffee());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddJerkedSoda_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new JerkedSoda());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddTexasTea_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new TexasTea());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddWater_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) order.Add(new Water());
        }
    }
}
