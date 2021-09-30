using System;

namespace Task2
{
    public enum ExpirationDatePercent { LessThanTenDays = 30, MoreThanTenDays = 10 }
    internal class DiaryProducts : Product
    {
        private ExpirationDatePercent datePercent;
        private int expirationDate;
        public DiaryProducts(string name, double price, double weight, int expirationDate) : base(name, price, weight)
        {
            this.expirationDate = expirationDate;
            datePercent = this.expirationDate > 10 ? ExpirationDatePercent.MoreThanTenDays
                : ExpirationDatePercent.LessThanTenDays;
        }

        public int ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                if(value > 0)
                {
                    expirationDate = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value of expiration date");
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            var other = (DiaryProducts)obj;
            return (expirationDate == other.expirationDate);
        }

        public override string ToString()
        {
            return base.ToString() + $", expiration date = {expirationDate}";

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
