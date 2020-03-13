using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class CowboyCoffee : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        private bool roomForCream = false;
        /// <summary>
        /// Whether there should be room for cream.
        /// </summary>
        public bool RoomForCream
        {
            get { return roomForCream; }
            set
            {
                if (roomForCream != value)
                {
                    roomForCream = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RoomForCream"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        private bool decaf = false;
        /// <summary>
        /// Whether the coffee is decaf.
        /// </summary>
        public bool Decaf
        {
            get { return decaf; }
            set
            {
                if (decaf != value)
                {
                    decaf = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Decaf"));
                }
            }
        }

        private bool ice = false;
        /// <summary>
        /// Bool for whether coffee has ice.
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
        /// Gets the price of the coffee
        /// </summary>
        public override double Price
        {
            get
            {
                return Size switch
                {
                    Size.Small => 0.60,
                    Size.Medium => 1.10,
                    Size.Large => 1.60,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the calories of the coffee
        /// </summary>
        public override uint Calories
        {
            get
            {
                return Size switch
                {
                    Size.Small => 3,
                    Size.Medium => 5,
                    Size.Large => 7,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the special instructions for the coffee.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
                {
                var instructions = new List<string>();

                if (RoomForCream) instructions.Add("Room for Cream");
                if (Ice) instructions.Add("Add Ice");

                return instructions;
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Cowboy Coffee" with the size before.</returns>
        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Size.ToString());
            if (Decaf) sb.Append(" Decaf");
            sb.Append(" Cowboy Coffee");

            return sb.ToString();
        }
    }
}
