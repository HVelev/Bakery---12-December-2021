using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;

        private int numberOfPeople;


        private readonly List<IBakedFood> foods;

        private readonly List<IDrink> drinks;


        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {

            TableNumber = tableNumber;

            Capacity = capacity;

            PricePerPerson = pricePerPerson;

            this.IsReserved = false;

            foods = new List<IBakedFood>();

            drinks = new List<IDrink>();

        }

        public int TableNumber { get; }
        public int Capacity { get => capacity; private set
            {

                if (value < 0)
                {

                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);

                }

                capacity = value;

            } 
        }
        public int NumberOfPeople { get => numberOfPeople; private set
            {

                if (value <= 0)
                {

                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);

                }

                numberOfPeople = value; 
            } 
        }
        public decimal PricePerPerson { get; }
        public bool IsReserved { get; private set; }
        public decimal Price => foods.Select(f => f.Price).Sum() + drinks.Select(d => d.Price).Sum() + this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            IsReserved = false;
            drinks.Clear();
            foods.Clear();
            Capacity = 0;
        }

        public decimal GetBill()
        {
            return Price;
        }

        public string GetFreeTableInfo()
        {

            var sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");

            sb.AppendLine($"Type: {this.GetType().Name}");

            sb.AppendLine($"Capacity: {Capacity}");

            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();

        }

        public void OrderDrink(IDrink drink)
        {


            drinks.Add(drink);

        }

        public void OrderFood(IBakedFood food)
        {

            foods.Add(food);

        }

        public void Reserve(int numberOfPeople)
        {

            IsReserved = true;

            NumberOfPeople = numberOfPeople;

        }
    }
}
