using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Storage s = new Storage();
            ConsoleStorageManager storageManager = new ConsoleStorageManager(s);
            Storage s1 = new Storage();
            ConsoleStorageManager storageManager1 = new ConsoleStorageManager(s1);
            try
            {
                s.ReadFromFile(@"C:\Users\Ростик\source\repos\Task2\ListOfProducts.txt");
                Console.WriteLine(storageManager.PrintAllProducts());
                s1.ReadFromFile(@"C:\Users\Ростик\source\repos\Task2\ListOfProducts2.txt");
                Console.WriteLine("\n New storage");
                Console.WriteLine(storageManager1.PrintAllProducts());

                CompareStorageProducts comparer = new CompareStorageProducts(Storage.CompareStorageProducts);
                List<Product> differentProd = StoragesComparerManager.GetAllDifferentProducts(s, s1, comparer);

                List<Product> commonProd = StoragesComparerManager.GetAllCommonProducts(s, s1, comparer);
                List<Product> differentFirst = StoragesComparerManager.GetFirstDefferentProducts(s, s1, comparer);

                Console.WriteLine("All different products");
                foreach (Product p in differentProd)
                {
                    Console.WriteLine(p.ToString());
                }

                Console.WriteLine("All common products");
                foreach (Product p in commonProd)
                {
                    Console.WriteLine(p.ToString());
                }

                Console.WriteLine("All common products");
                foreach (Product p in differentFirst)
                {
                    Console.WriteLine(p.ToString());
                }


            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadLine();
        }
    }
}
