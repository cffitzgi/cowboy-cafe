/* AngryChicken.cs
 * Author: Cashel Fox FitzGibbons
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Angry Chicken entree
    /// </summary>
    public class AngryChicken : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private bool bread = true;
        /// <summary>
        /// If the chicken comes with bread.
        /// </summary>
        public bool Bread {
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
        /// If the chicken comes with a pickle
        /// </summary>
        public bool Pickle {
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
        /// The price of the chicken
        /// </summary>
        public override double Price => 5.99;

        /// <summary>
        /// The calories of the chicken
        /// </summary>
        public override uint Calories => 190;
       

        /// <summary>
        /// Special instructions for the preparation of the chicken
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
        /// <returns>The string "Angry Chicken"</returns>
        public override string ToString() { return "Angry Chicken"; }
    }
}

