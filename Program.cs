using System;

namespace Task2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Storage s = new Storage();
            //s.FillArrayOfProducts();
            //s.PrintAllProducts();
            //var meat = s.GetAllMeetProducts();
            //foreach(var elem in meat)
            //{
            //    Console.WriteLine(elem);
            //}
            //Console.ReadLine();
            Storage s2 = new Storage();
            ConsoleStorageManager storageManager = new ConsoleStorageManager(s2);
            try
            {
                storageManager.Run();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            s2.ChangePrice(15);
            s2.PrintAllProducts();
            Console.ReadLine();
            


        }
    }
}
