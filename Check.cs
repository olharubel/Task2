using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    sealed internal class Check
    {
        public static void PrintProductData(ref Product product)
        {
            Console.WriteLine("Name of the product: " + product.Name);
            Console.WriteLine("Price of the product: " + product.Price);
            Console.WriteLine("Weight of the product: " + product.Weight);
            Console.ReadLine();
        }

        public static void PrintBuyData(ref Product product, ref Buy buy)
        {
            PrintProductData(ref product);
            Console.WriteLine("Amount of the products: " + buy.Amount);
            Console.WriteLine("Total price of the products: " + buy.TotalPrice);
            Console.WriteLine("Total weight of the products: " + buy.TotalWeight);
            Console.ReadLine();
        }
    }
}
