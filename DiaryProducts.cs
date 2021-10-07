using System;

namespace Task2
{
    public enum ExpirationDatePercent { LessThanTenDays = 30, MoreThanTenDays = 10 }
    internal class DiaryProducts : Product
    {
        private ExpirationDatePercent datePercent;

        public DiaryProducts(string name, double price, double weight, int expirationDate, DateTime creationDate) 
            : base(name, price, weight, expirationDate, creationDate)
        {
            this.datePercent = expirationDate > 10 ? ExpirationDatePercent.MoreThanTenDays
               : ExpirationDatePercent.LessThanTenDays;
        }

        public DiaryProducts()
        {
            this.datePercent = ExpirationDatePercent.LessThanTenDays;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            var other = (DiaryProducts)obj;
            return (Name == other.Name) && (ExpirationDate == this.ExpirationDate);
        }

        public override string ToString()
        {
            return base.ToString();

        }

        public override void ChangePrice(int percent)
        {
            if(percent < -100 || percent > 100)
            {
                throw new ArgumentException("Incorrect value of percent");
            }
                Price += Price * (percent / 100.0) * ((int)datePercent / 100.0);
        }


    }
}
