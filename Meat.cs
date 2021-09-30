using System;

namespace Task2
{
    public enum Category { HighestGrade = 30, FirstGrade = 20, SecondGrade = 10};
    public enum Kind { Lamb , Veal, Pork , Chicken};
    internal class Meat : Product
    {
        Category category;
        Kind kind;

        public Meat(string name, double price, double weight, Category category, Kind kind): base(name, price, weight) {
            this.category = category;
            this.kind = kind;
        }

        public override string ToString()
        {
            return base.ToString() + $", category: {category}, kind: {kind}";
        }

        public override void ChangePrice(int percent)
        {
            if (percent < -100 || percent > 100)
            {
                throw new ArgumentException("Incorrect value of percent");
            }
            Price += Price * (percent / 100.0) * ((int)category / 100.0);
        }
    }
}
