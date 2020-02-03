using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Trail Burger entree
    /// </summary>
    public class Trailburger : Entree
    {
        /// <summary>
        /// If the burger comes on a bun
        /// </summary>
        public bool Bun { get; set; } = true;

        /// <summary>
        /// If the burger has ketchup
        /// </summary>
        public bool Ketchup { get; set; } = true;

        /// <summary>
        /// If the burger has mustard
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// If the burger has pickles
        /// </summary>
        public bool Pickle { get; set; } = true;
/* My cat pickles jumped into my lap when I wrote this one :) */

        /// <summary>
        /// If the burger has cheese
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// The price of the burger
        /// </summary>
        public override double Price => 4.50;

        /// <summary>
        /// The calories of the burger
        /// </summary>
        public override uint Calories => 288;

        /// <summary>
        /// Special instructions for the preparation of the burger
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Bun) instructions.Add("hold bun");
                if (!Ketchup) instructions.Add("hold ketchup");
                if (!Mustard) instructions.Add("hold mustard");
                if (!Pickle) instructions.Add("hold pickle");
                if (!Cheese) instructions.Add("hold cheese");

                return instructions;
            }
        }
    }
}

