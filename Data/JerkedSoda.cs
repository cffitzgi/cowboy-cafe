using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class JerkedSoda : Drink
    {

        /// <summary>
        /// The flavor of the soda.
        /// </summary>
        public SodaFlavor Flavor { get; set; }

        /// <summary>
        /// Gets the price of the soda
        /// </summary>
        public override double Price
        {
            get
            {
                return Size switch
                {
                    Size.Small => 1.59,
                    Size.Medium => 2.10,
                    Size.Large => 2.59,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the calories of the soda
        /// </summary>
        public override uint Calories
        {
            get
            {
                return Size switch
                {
                    Size.Small => 110,
                    Size.Medium => 146,
                    Size.Large => 198,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the special instructions for the soda.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
                {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }
    }
}
