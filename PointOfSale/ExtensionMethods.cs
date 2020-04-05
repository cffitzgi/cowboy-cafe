using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using CowboyCafe.Data;

namespace PointOfSale.ExtensionMethods
{
    /// <summary>
    /// Extension methods used for Point Of Sale
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Statically finds ancestor of type T
        /// </summary>
        /// <typeparam name="T">Type of ancestor being searched for</typeparam>
        /// <param name="element">The starting point.</param>
        /// <returns>The most recent ancestor of type T</returns>
        public static T FindAncestor<T>(this DependencyObject element) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(element);

            if (parent == null) return null;

            if (parent is T) return parent as T;

            return parent.FindAncestor<T>();
        }

        /// <summary>
        /// Determines if the enumerable Order Item list contains an object.
        /// </summary>
        /// <typeparam name="T">Type of object being enumeratored</typeparam>
        /// <param name="enumerator">Enumerator  to check</param>
        /// <returns>If the enumerator contains any items.</returns>
        public static bool Any<T>(this IEnumerable<T> enumerator) where T : IOrderItem
        {
            foreach (T item in enumerator) return true;
            return false;
        }
    }
}
