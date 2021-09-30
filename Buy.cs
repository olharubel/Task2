namespace Task2
{
    internal class Buy
    {
        private readonly Product productData;
        private uint amount;
        private double totalPrice;
        private double totalWeight;

        public Buy(Product productData, uint amount)
        {
            this.productData = productData;
            this.amount = amount;
            totalPrice = this.amount * this.productData.Price;
            totalWeight = this.amount * this.productData.Weight;
        }

        public uint Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value > 0)
                {
                    amount = value;
                }
            }
        }

        public double TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
            }
        }

        public double TotalWeight
        {
            get
            {
                return totalWeight;
            }
            set
            {
                totalWeight = value;
            }
        }
    }
}
