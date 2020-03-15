using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class TexasTea : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public override event PropertyChangedEventHandler PropertyChanged;

        private bool sweet = true;
        /// <summary>
        /// Whether the tea is sweet.
        /// </summary>
        public bool Sweet
        {
            get { return sweet; }
            set
            {
                if (sweet != value)
                {
                    sweet = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sweet"));                }
            }
        }

        private bool lemon = false;
        /// <summary>
        /// Whether the tea is served with a lemon.
        /// </summary> 
        public bool Lemon
        {
            get { return lemon; }
            set
            {
                if (lemon != value)
                {
                    lemon = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lemon"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }
            }
        }

        private Size size = Size.Small;
        /// <summary>
        /// Gets the size of the tea
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
        /// Bool for whether tea has ice.
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
        /// Gets the price of the tea
        /// </summary>
        public override double Price
        {
            get
            {
                return Size switch
                {
                    Size.Small => 1.00,
                    Size.Medium => 1.50,
                    Size.Large => 2.00,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the calories of the tea
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Sweet)
                {
                    return Size switch
                    {
                        Size.Small => 10,
                        Size.Medium => 22,
                        Size.Large => 36,
                        _ => throw new NotImplementedException("Unknown size"),
                    };
                }
                return Size switch
                {
                    Size.Small => 5,
                    Size.Medium => 11,
                    Size.Large => 18,
                    _ => throw new NotImplementedException("Unknown size"),
                };
            }
        }

        /// <summary>
        /// Gets the special instructions for the tea.
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

        /// <summary>
        /// Coverts the object to a string
        /// </summary>
        /// <returns>The string "Texas Tea" with the size before.</returns>
        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Size.ToString());
            sb.Append(" Texas");
            if (Sweet) sb.Append(" Sweet");
            else sb.Append(" Plain");
            sb.Append(" Tea");

            return sb.ToString();
        }
    }
}
