/* CowpokeChili.cs
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data.Entrees
{
    /// <summary>
    /// A class representing the Cowpoke Chili entree
    /// </summary>
    public class CowpokeChili : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public override event PropertyChangedEventHandler PropertyChanged;

        private bool cheese = true;
        /// <summary>
        /// If the chili is topped with cheese
        /// </summary>
        public bool Cheese {
            get { return cheese; }
            set {
                if (cheese != value)
                {
                    cheese = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cheese"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            } }

        private bool sourCream = true;
        /// <summary>
        /// If the chili is topped with sour cream
        /// </summary>
        public bool SourCream {
            get { return sourCream; }
            set
            {
                if (sourCream != value)
                {
                    sourCream = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SourCream"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        private bool greenOnions = true;
        /// <summary>
        /// If the chili is topped with green onions
        /// </summary>
        public bool GreenOnions {
            get { return greenOnions; }
            set
            {
                if (greenOnions != value)
                {
                    greenOnions = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GreenOnions"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        private bool tortillaStrips = true;
        /// <summary>
        /// If the chili is topped with tortilla strips
        /// </summary>
        public bool TortillaStrips {
            get { return tortillaStrips; }
            set
            {
                if (tortillaStrips != value)
                {
                    tortillaStrips = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TortillaStrips"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        /// <summary>
        /// The price of the chili
        /// </summary>
        public override double Price => 6.10;

        /// <summary>
        /// The calories of the chili
        /// </summary>
        public override uint Calories => 171;

        /// <summary>
        /// Special instructions for the preparation of the chili
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Cheese) instructions.Add("hold cheese");
                if (!SourCream) instructions.Add("hold sour cream");
                if (!GreenOnions) instructions.Add("hold green onions");
                if (!TortillaStrips) instructions.Add("hold tortilla strips");

                return instructions;
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Cowpoke Chili"</returns>
        public override string ToString() { return "Cowpoke Chili"; }
    }
}

