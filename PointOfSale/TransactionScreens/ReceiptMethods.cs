using System;
using System.Collections.Generic;
using System.Text;
using CowboyCafe.Data;
using PointOfSale;
using PointOfSale.TransactionScreens.CashControls;

namespace PointOfSale.TransactionScreens
{
    public static class ReceiptMethods
    {
        private const string LINE = "########################################\n";

        /// <summary>
        /// Formats payments completed with cash.
        /// </summary>
        /// <param name="o">Order to format</param>
        /// <param name="payment">Initial payment</param>
        /// <param name="change">Change owed</param>
        /// <returns>Order formatted as receipt</returns>
        public static string FormatCashReceipt(this Order o, double payment, double change)
        {
            formatReceipt(o, out StringBuilder sb);

            sb.Append("\nAmount Paid:\t\t\t");
            sb.Append(payment.ToString("C2"));
            sb.Append("\nChange Owed:\t\t\t");
            sb.Append(change.ToString("C2"));
            sb.Append("\n");
            sb.Append(LINE);
            sb.Append(LINE);
            sb.Append("\n");

            return sb.ToString();
        }

        /// <summary>
        /// Formats payments done with a card.
        /// </summary>
        /// <param name="o">Order being formatted</param>
        /// <returns>Order formatted as receipt</returns>
        public static string FormatCardReceipt(this Order o)
        {
            formatReceipt(o, out StringBuilder sb);

            sb.Append("\n[Card Payment]\n");
            sb.Append(LINE);
            sb.Append(LINE);
            sb.Append("\n");

            return sb.ToString();
        }

        /// <summary>
        /// Formats Order to be receipt friendly
        /// </summary>
        /// <param name="o">Order to format</param>
        /// <param name="sb">Stringbuilder</param>
        private static void formatReceipt(Order o, out StringBuilder sb)
        {
            sb = new StringBuilder();
            sb.Append(LINE);
            sb.Append(LINE);
            sb.Append("\t\t");
            sb.Append(o.ToString());
            sb.Append("\n\t   ");
            sb.Append(DateTime.Now);
            sb.Append("\n");
            sb.Append(LINE);
            foreach (IOrderItem item in o.Items)
            {
                sb.Append(item);
                int itemLength = item.ToString().Length;
                sb.Append("\t");
                if (itemLength < 25) sb.Append("\t");
                if (itemLength < 17) sb.Append("\t");

                sb.Append(item.Price.ToString("C2"));
                if (item.SpecialInstructions != null)
                {
                    foreach (string instruction in item.SpecialInstructions)
                    {
                        sb.Append("\n\t");
                        sb.Append(instruction);
                    }
                }
                sb.Append("\n");
            }
            sb.Append(LINE);
            sb.Append("SUBTOTAL:\t\t\t");
            sb.Append(o.Subtotal.ToString("C2"));
            sb.Append("\nTOTAL:\t\t\t\t");
            sb.Append(o.Total.ToString("C2"));
        }
    }
}
