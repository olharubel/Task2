using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
            products.Add(new DiaryProducts("Milk", 28.9, 0.875, 0, new DateTime(2021,08,20)));
            products.Add(new Meat("Chicken", 189, 1.23, MeatType.Category.FirstGrade, MeatType.Kind.Chicken));
            products.Add(new DiaryProducts("Cheese", 239.8, 1.65, 0, new DateTime(2021, 04, 10)));
        }


        public void AddToStorage(Product product)
        {
            products.Add(product);
        }

        public void ChangePrice(int percent)
        {
            foreach(var elem in products)
            {
                elem.ChangePrice(percent);
            }
        }

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

        public override string ToString()
        {
            string str = "";
            foreach(var product in products)
            {
                str += product.ToString() + "\n";
            }
            return str;

        }

        public List<Product> GetAllMeetProducts()
        {
            return products.Where(x => x is Meat).ToList();
        }

        public void RemoveDiaryProducts(string path)
        {
            var diaryProducts = products.Where(x => x is DiaryProducts).ToList();
            StreamWriter sw = new StreamWriter(path);
            foreach (var product in diaryProducts)
            {
                TimeSpan days = (DateTime.Now.Date - product.CreationDate);
                if (days.Days == 0)
                {
                    sw.WriteLine(product.ToString());
                    products.Remove(product);
                    
                }
            }
            sw.Close();
        }

        private Product InitProductByCategory(char category)
        {
            switch (category)
            {
                case 'P':
                    return new Product();
                case 'M':
                    return new Meat();
                case 'D':
                    return new DiaryProducts();
                default:
                    throw new ArgumentException("Uknown category. Expected 'P', 'M' or 'D'");
                     
            }
        }

        public void ReadFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {

                    string data;
                    while (!sr.EndOfStream)
                    {
                        char category = (char)sr.Read();
                        sr.Read();
                        data = sr.ReadLine();
                        Product p = InitProductByCategory(category);
                        p.Parse(data);
                        products.Add(p);
                    }

                    sr.Close();
                }
            }
              catch(Exception exc)
            {
                throw exc;
            } 
        }
    }
}
