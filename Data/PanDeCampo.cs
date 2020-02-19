/* PanDeCampo.cs
 * Author: Cashel FitzGibbons
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class PanDeCampo : Side
    {
        /// <summary>
        /// The price of the Pan de campo (depending on the size).
        /// </summary>
        public override double Price
        {
            get
            {
                return Size switch
                {
                    Size.Small => 1.59,
                    Size.Medium => 1.79,
                    Size.Large => 1.99,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// The calories of the Pan de campo (depending on the size).
        /// </summary>
        public override uint Calories
        {
            get
            {
                return Size switch
                {
                    Size.Small => 227,
                    Size.Medium => 269,
                    Size.Large => 367,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Pan De Campo" with the size in the next line.</returns>
        public override string ToString() { return "Pan De Campo\n\t" + Size.ToString(); }
    }
}
