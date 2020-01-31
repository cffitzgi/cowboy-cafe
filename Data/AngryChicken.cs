/* AngryChicken.cs
 * Author: Cashel Fox FitzGibbons
 */
using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Angry Chicken entree
    /// </summary>
    public class AngryChicken
    {
        /// <summary>
        /// If the chicken comes with bread.
        /// </summary>
        public bool Bread { get; set; } = true;


        /// <summary>
        /// If the chicken comes with a pickle
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// The price of the chicken
        /// </summary>
        public double Price => 5.99;

        /// <summary>
        /// The calories of the chicken
        /// </summary>
        public uint Calories => 190;
       

        /// <summary>
        /// Special instructions for the preparation of the chicken
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Bread) instructions.Add("hold bread");
                if (!Pickle) instructions.Add("hold pickle");

                return instructions;
            }
        }
    }
}

