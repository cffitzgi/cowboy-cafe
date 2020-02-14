﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class Water : Drink
    {
        // Whether the water is served with a lemon.
        public bool Lemon { get; set; } = false;

        /// <summary>
        /// Gets the price of the water
        /// </summary>
        public override double Price => 0.12;

        /// <summary>
        /// Gets the calories of the water
        /// </summary>
        public override uint Calories => 0;

        /// <summary>
        /// Gets the special instructions for the water.
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
    }
}
