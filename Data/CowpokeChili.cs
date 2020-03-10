/* CowpokeChili.cs
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Cowpoke Chili entree
    /// </summary>
    public class CowpokeChili : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private bool cheese = true;
        /// <summary>
        /// If the chili is topped with cheese
        /// </summary>
        public bool Cheese {
            get { return cheese; }
            set { cheese = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cheese")); 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            } }

        /// <summary>
        /// If the chili is topped with sour cream
        /// </summary>
        public bool SourCream { get; set; } = true;

        /// <summary>
        /// If the chili is topped with green onions
        /// </summary>
        public bool GreenOnions { get; set; } = true;

        /// <summary>
        /// If the chili is topped with tortilla strips
        /// </summary>
        public bool TortillaStrips { get; set; } = true;

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

