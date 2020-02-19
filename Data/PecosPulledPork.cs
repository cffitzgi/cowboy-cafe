/* PecosPulledPork.cs
 * Author: Cashel Fox FitzGibbons
 */
using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Pecos Pulled Pork entree
    /// </summary>
    public class PecosPulledPork : Entree
    {
        /// <summary>
        /// If the pork comes with bread
        /// </summary>
        public bool Bread { get; set; } = true;

        /// <summary>
        /// If the pork comes with a pickle
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// The price of the pork
        /// </summary>
        public override double Price => 5.88;

        /// <summary>
        /// The calories of the pork
        /// </summary>
        public override uint Calories => 528;

        /// <summary>
        /// Special instructions for the preparation of the pork
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
        /// <returns>The string "Pecos Pulled Pork"</returns>
        public override string ToString() { return "Pecos Pulled Pork"; }
    }
}

