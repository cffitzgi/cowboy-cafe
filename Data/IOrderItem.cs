using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Order Item interface
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// Calories of order item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// Price of order item
        /// </summary>
        double Price { get; }

        /// <summary>
        /// Special Instructions of order item.
        /// </summary>
        List<string> SpecialInstructions { get; }
    }
}
