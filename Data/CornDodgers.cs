/* CornDodgers.Cs
 * Author: Cashel FitzGibbons
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class CornDodgers : Side
    {
        /// <summary>
        /// The price of the Corn Dodgers (depending on the size).
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
        /// The calories of the Corn Dodgers (depending on the size).
        /// </summary>
        public override uint Calories
        {
            get
            {
                return Size switch
                {
                    Size.Small => 512,
                    Size.Medium => 685,
                    Size.Large => 717,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Corn Dodgers" with the size in the next line.</returns>
        public override string ToString() { return "Corn Dodgers\n\t" + Size.ToString(); }
    }
}
