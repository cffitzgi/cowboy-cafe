using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class CowboyCoffee : Drink
    {
        /// <summary>
        /// Whether there should be room for cream.
        /// </summary>
        public bool RoomForCream { get; set; } = false;

        /// <summary>
        /// Whether the coffee is decaf.
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// Bool for whether coffee has ice.
        /// </summary>
        public override bool Ice { get; set; } = false;

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
        /// <returns>The string "Cowboy Coffee" with the size in the next line.</returns>
        public override string ToString() { return "Cowboy Coffee\n\t" + Size.ToString(); }
    }
}
