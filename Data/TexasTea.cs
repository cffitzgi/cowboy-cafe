using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class TexasTea : Drink
    {
        /// <summary>
        /// Whether the tea is sweet.
        /// </summary>
        public bool Sweet { get; set; } = true;

        /// <summary>
        /// Whether the tea is served with a lemon.
        /// </summary> 
        public bool Lemon { get; set; } = false;

        /// <summary>
        /// Gets the price of the tea
        /// </summary>
        public override double Price
        {
            get
            {
                return Size switch
                {
                    Size.Small => 1.00,
                    Size.Medium => 1.50,
                    Size.Large => 2.00,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the calories of the tea
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Sweet)
                {
                    return Size switch
                    {
                        Size.Small => 10,
                        Size.Medium => 22,
                        Size.Large => 36,
                        _ => throw new NotImplementedException("Unknown size"),
                    };
                }
                return Size switch
                {
                    Size.Small => 5,
                    Size.Medium => 11,
                    Size.Large => 18,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the special instructions for the tea.
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
        /// <returns>The string "Texas Tea" with the size before.</returns>
        public override string ToString() 
        {
            string mod = " Plain";
            if (Sweet) mod = " Sweet";
            return Size.ToString() + " Texas" + mod + " Tea"; 
        }
    }
}
