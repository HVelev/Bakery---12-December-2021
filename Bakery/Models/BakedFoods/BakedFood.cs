using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;

        private int portion;

        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }

        public string Name
        {

            get => this.name;

            private set
            {

                if (String.IsNullOrWhiteSpace(value))
                {

                    throw new ArgumentException(ExceptionMessages.InvalidName);

                }

                this.name = value;

            }
        }

        public int Portion
        {

            get => this.portion;

            private set
            {

                if (value <= 0)
                {

                    throw new ArgumentException(ExceptionMessages.InvalidPortion);

                }

                this.portion = value;

            }

        }

        public decimal Price
        {

            get => this.price;

            private set
            {

                if (value <= 0)
                {

                    throw new ArgumentException(ExceptionMessages.InvalidPrice);

                }

                this.price = value;

            }

        }

        public override string ToString()
        {

            var sb = new StringBuilder();

            sb.Append($"{this.GetType().Name}: {Portion}g - {Price:F2}");

            return sb.ToString();

        }

    }
}
