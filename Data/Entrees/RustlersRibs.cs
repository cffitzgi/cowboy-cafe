/* RustlersRibs.cs
 * Author: Cashel FitzGibbons
 */
using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the RustlersRibs entree
    /// </summary>
    public class RustlersRibs : Entree
    {
        /// <summary>
        /// The price of the chili
        /// </summary>
        public override double Price => 7.50;

        /// <summary>
        /// The calories of the chili
        /// </summary>
        public override uint Calories => 894;

        /// <summary>
        /// Special instructions for the preparation of the ribs
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Rustler's Ribs"</returns>
        public override string ToString() { return "Rustler's Ribs"; }
    }
}

