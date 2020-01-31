using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Dakota Double Burger entree
    /// </summary>
    public class DakotaDoubleBurger
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

        /// <summary>
        /// If the burger has cheese
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// If the burger has tomato
        /// </summary>
        public bool Tomato { get; set; } = true;

        /// <summary>
        /// If the burger has lettuce
        /// </summary>
        public bool Lettuce { get; set; } = true;

        /// <summary>
        /// If the burger has mayo
        /// </summary>
        public bool Mayo { get; set; } = true;

        /// <summary>
        /// The price of the burger
        /// </summary>
        public double Price
        {
            get
            {
                return 5.20;
            }
        }

        /// <summary>
        /// The calories of the burger
        /// </summary>
        public uint Calories
        {
            get
            {
                return 464;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the burger
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Bun) instructions.Add("hold bun");
                if (!Ketchup) instructions.Add("hold ketchup");
                if (!Mustard) instructions.Add("hold mustard");
                if (!Pickle) instructions.Add("hold pickle");
                if (!Cheese) instructions.Add("hold cheese");
                if (!Tomato) instructions.Add("hold tomato");
                if (!Lettuce) instructions.Add("hold lettuce");
                if (!Mayo) instructions.Add("hold mayo");

                return instructions;
            }
        }
    }
}

