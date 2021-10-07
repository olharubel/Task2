using System;

namespace Task2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Storage s = new Storage();
            ConsoleStorageManager storageManager = new ConsoleStorageManager(s);
            Product p = new Product();
            try
            {
                s.ReadFromFile(@"C:\Users\Ростик\source\repos\Task2\ListOfProducts.txt");
                Console.WriteLine(storageManager.PrintAllProducts());
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadLine();
        }
    }
}
