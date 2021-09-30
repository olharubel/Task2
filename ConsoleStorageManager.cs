using System;


namespace Task2
{
    class ConsoleStorageManager
    {
        private Storage s;

        public ConsoleStorageManager(Storage s)
        {
            this.s = s;
        }

        private Category GetCategoryBySymbol(char grade)
        {
            switch (grade)
            {
                case 'H':
                    return Category.HighestGrade;
                case 'F':
                    return Category.FirstGrade;
                case 'S':
                    return Category.SecondGrade;
                default:
                    throw new ArgumentException("Uknown category");
            }

        }

        private Kind GetKindBySymbol(char kind)
        {
            switch (kind)
            {
                case 'L':
                    return Kind.Lamb;
                case 'V':
                    return Kind.Veal;
                case 'P':
                    return Kind.Pork;
                case 'C':
                    return Kind.Chicken;
                default:
                    throw new ArgumentException("Uknown kind");
            }
        }

        private (string, double, double) ReadParams()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price:");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter weight:");
            double weight = Convert.ToDouble(Console.ReadLine());
            return (name, price, weight);
        }

        public void Run()
        {
            Console.WriteLine("Enter the number of products you want to have in the storage:");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Cannot parse the value");
            }


            for (int i = 0; i < number; ++i)
            {
                Console.WriteLine("Choose the type of product (Enter 'P' for Product, 'M' for Meat, 'D' for DiaryProducts):");
                char type = (char)Console.Read();
                Console.ReadLine();

                switch (type)
                {
                    case 'P':
                        {
                            var data = ReadParams();

                                s.AddToStorage(new Product(data.Item1, data.Item2, data.Item3));

                        }
                        break;
                    case 'D':
                        {
                            var data = ReadParams();
                            Console.WriteLine("Enter expiration date:");
                            int expirationDate = Convert.ToInt32(Console.ReadLine());

                                s.AddToStorage(new DiaryProducts(data.Item1, data.Item2, data.Item3, expirationDate));

                            
                        }
                        break;
                    case 'M':
                        {
                            var data = ReadParams();
                            Console.WriteLine("Enter grade of meet ('H' for HighestGrade, " +
                          "'F' for FirstGrade, 'S' for SecondGrade):");
                            char grade = (char)Console.Read();
                            Console.ReadLine(); //read \n from buffer
                                Category category = GetCategoryBySymbol(grade);
                            Console.WriteLine("Enter kind of meet ('L' for Lamb, 'V' for Veal" +
                           "'P' for Pork, 'C' for Chicken):");
                            char kind = (char)Console.Read();
                            Console.ReadLine(); //read \n from buffer
                            Kind kindOfMeet = GetKindBySymbol(kind);
                                s.AddToStorage(new Meat(data.Item1, data.Item2, data.Item3, category, kindOfMeet));

                            
                        }
                        break;
                    default:
                        Console.WriteLine("Uknown type of product. Expected 'P'/'D'/'M'");
                        
                        break;
                }
            }
        }
    }
}
