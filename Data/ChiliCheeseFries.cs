﻿/* ChiliCheeseFries.cs
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class ChiliCheeseFries : Side
    {
        /// <summary>
        /// The price of the Chili Cheese Fries (depending on the size).
        /// </summary>
        public override double Price
        {
            get
            {
                return Size switch
                {
                    Size.Small => 1.99,
                    Size.Medium => 2.99,
                    Size.Large => 3.99,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// The calories of the Chili Cheese Fries (depending on the size).
        /// </summary>
        public override uint Calories
        {
            get
            {
                return Size switch
                {
                    Size.Small => 433,
                    Size.Medium => 524,
                    Size.Large => 610,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }
    }
}
