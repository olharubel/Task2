using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Storage
    {
        private List<Product> products;

        public Storage()
        {
            products = new List<Product>();
        }
        public void FillArrayOfProducts()
        {
            products.Add(new Product("Banana", 33.5, 0.970));
            products.Add(new Product("Apple", 17.5, 1.4));
            products.Add(new DiaryProducts("Milk", 28.9, 0.875, 7));
            products.Add(new Meat("Chicken", 189, 1.23, Category.FirstGrade, Kind.Chicken));
            products.Add(new DiaryProducts("Cheese", 239.8, 1.65, 4));
        }


        public void AddToStorage(Product product)
        {
            products.Add(product);
        }

        public void PrintAllProducts()
        {
            foreach(var elem in products)
            {
                Console.WriteLine(elem);
            }
            Console.ReadLine();
        }

        public void ChangePrice(int percent)
        {
            foreach(var elem in products)
            {
                elem.ChangePrice(percent);
            }
        }

        //public Product[] GetAllMeetProducts()
        //{
        //   // Product[] meat = products.Where(x => x is Meat).ToArray();
        //    Product[] meat = new Product[products.Length];
        //    uint index = 0;
        //    foreach(var elem in products)
        //    {
        //       if( elem.GetType() == typeof(Meat))
        //        {
        //            meat[index++] = elem;
        //        }
        //    }
        //    return meat;
        //}

        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }
    }
}
