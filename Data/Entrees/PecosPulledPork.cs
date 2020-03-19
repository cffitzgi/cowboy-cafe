/* PecosPulledPork.cs
 * Author: Cashel Fox FitzGibbons
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data.Entrees
{
    /// <summary>
    /// A class representing the Pecos Pulled Pork entree
    /// </summary>
    public class PecosPulledPork : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public override event PropertyChangedEventHandler PropertyChanged;

        private bool bread = true;
        /// <summary>
        /// If the pork comes with bread.
        /// </summary>
        public bool Bread
        {
            get { return bread; }
            set
            {
                if (bread != value)
                {
                    bread = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bread"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        private bool pickle = true;
        /// <summary>
        /// If the pork comes with a pickle
        /// </summary>
        public bool Pickle
        {
            get { return pickle; }
            set
            {
                if (pickle != value)
                {
                    pickle = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pickle"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }
        /// <summary>
        /// The price of the pork
        /// </summary>
        public override double Price => 5.88;

        /// <summary>
        /// The calories of the pork
        /// </summary>
        public override uint Calories => 528;

        /// <summary>
        /// Special instructions for the preparation of the pork
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Bread) instructions.Add("hold bread");
                if (!Pickle) instructions.Add("hold pickle");

                return instructions;
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Pecos Pulled Pork"</returns>
        public override string ToString() { return "Pecos Pulled Pork"; }
    }
}

