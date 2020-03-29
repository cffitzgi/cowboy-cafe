using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data.Drinks
{
    public class Water : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public override event PropertyChangedEventHandler PropertyChanged;

        private bool lemon = false;
        /// <summary>
        /// Whether the water is served with a lemon.
        /// </summary> 
        public bool Lemon
        {
            get { return lemon; }
            set
            {
                if (lemon != value)
                {
                    lemon = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lemon"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        private Size size = Size.Small;
        /// <summary>
        /// Gets the size of the water
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set
            {
                if (size != value)
                {
                    size = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
                }
            }
        }

        private bool ice = true;
        /// <summary>
        /// Bool for whether water has ice.
        /// </summary>
        public override bool Ice
        {
            get { return ice; }
            set
            {
                if (ice != value)
                {
                    ice = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ice"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        /// <summary>
        /// Gets the price of the water
        /// </summary>
        public override double Price => 0.12;

        /// <summary>
        /// Gets the calories of the water
        /// </summary>
        public override uint Calories => 0;

        /// <summary>
        /// Gets the special instructions for the water.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
                {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");
                if (Lemon) instructions.Add("Add Lemon");

                return instructions;
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Water" with the size before.</returns>
        public override string ToString() { return Size.ToString() + " Water"; }
    }
}
