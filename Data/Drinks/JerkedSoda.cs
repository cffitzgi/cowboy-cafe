using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class JerkedSoda : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public override event PropertyChangedEventHandler PropertyChanged;


        private SodaFlavor flavor;
        /// <summary>
        /// The flavor of the soda.
        /// </summary>
        public SodaFlavor Flavor
        {
            get { return flavor; }
            set
            {
                flavor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Flavor"));
            }
        }

        private Size size = Size.Small;
        /// <summary>
        /// Gets the size of the soda
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set
            {
                if (size != value)
                {
                    size = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                }
            }
        }

        private bool ice = true;
        /// <summary>
        /// Bool for whether soda has ice.
        /// </summary>
        public override bool Ice
        {
            get { return ice; }
            set
            {
                if (ice != value)
                {
                    ice = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ice"));
                }
            }
        }

        /// <summary>
        /// Gets the price of the soda
        /// </summary>
        public override double Price
        {
            get
            {
                return Size switch
                {
                    Size.Small => 1.59,
                    Size.Medium => 2.10,
                    Size.Large => 2.59,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the calories of the soda
        /// </summary>
        public override uint Calories
        {
            get
            {
                return Size switch
                {
                    Size.Small => 110,
                    Size.Medium => 146,
                    Size.Large => 198,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the special instructions for the soda.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
                {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Jerked Soda" with the Flavor and Size before.</returns>
        public override string ToString() 
        {
            string flavor;
            switch(Flavor)
            {
                case (SodaFlavor.BirchBeer):
                    flavor = " Birch Beer";
                    break;
                case (SodaFlavor.CreamSoda):
                    flavor = " Cream Soda";
                    break;
                case (SodaFlavor.OrangeSoda):
                    flavor = " Orange Soda";
                    break;
                case (SodaFlavor.RootBeer):
                    flavor = " Root Beer";
                    break;
                default:
                    flavor = " Sarsparilla";
                    break;
            }
            return Size.ToString() + flavor + " Jerked Soda"; 
        }
    }
}
