/* BakedBeans.cs
 * Author: Cashel FitzGibbons
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class BakedBeans : Side, INotifyPropertyChanged
    {

        /// <summary>
        /// The price of the Baked Beans (depending on the size).
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
        /// The calories of the Baked Beans (depending on the size).
        /// </summary>
        public override uint Calories
        {
            get
            {
                return Size switch
                {
                    Size.Small => 312,
                    Size.Medium => 378,
                    Size.Large => 410,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Baked Beans" with the size before.</returns>
        public override string ToString() { return Size.ToString() + " Baked Beans"; }
    }
}
