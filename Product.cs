using System;

namespace Task2
{
    internal class Product
    {
        private string name;
        private double price;
        private double weight;
        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0.0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value of price");
                }
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0.0)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value of weight");
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) 
                return false;

            var other = (Product)obj;
            return (name == other.name);
        }

        public override String ToString()
        {
            return $"Name: {name}, price = {price}, weight = {weight}";
        }

        public virtual void ChangePrice(int percent) //
        {
            if(percent < -100 || percent > 100)
            {
                throw new ArgumentException("Incorrect value of percent");
            }
            Price += Price * (percent / 100.0);
        }
    }
}
