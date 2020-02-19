﻿using System;
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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        /// <summary>
        /// Constructor for Order Control
        /// </summary>
        public OrderControl()
        {
            InitializeComponent();
        }

// ENTREE CLICK EVENT \\
        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddAngryChickenButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new AngryChicken());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddCowpokeChiliButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new CowpokeChili());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddDakotaDoubleBurgerButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new DakotaDoubleBurger());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddPecosPulledPork_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new PecosPulledPork());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddRustlersRibs_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new RustlersRibs());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddTexasTripleBurger_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new TexasTripleBurger());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddTrailBurger_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new Trailburger());
        }

 // SIDE CLICK EVENT 
        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddBakedBeans_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new BakedBeans());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddChiliCheeseFries_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new ChiliCheeseFries());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddCornDodgers_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new CornDodgers());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddPanDeCampo_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new PanDeCampo());
        }

// DRINK CLICK EVENT \\
        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddCowboyCoffee_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new CowboyCoffee());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddJerkedSoda_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new JerkedSoda());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddTexasTea_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new TexasTea());
        }

        /// <summary>
        /// Click event handler for adding item to order.
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Argument</param>
        private void AddWater_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new Water());
        }
    }
}
