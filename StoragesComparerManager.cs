using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public delegate bool CompareStorageProducts(Product p1, Product p2);

    class StoragesComparerManager
    {
        public static List<Product> GetAllCommonProducts(Storage s1, Storage s2, CompareStorageProducts comparer)
        {
            IEnumerable<Product> commonProduct = s1.GetProductList().Intersect(s2.GetProductList(), new Comparer());
            return commonProduct.ToList();
        }

        public static List<Product> GetAllDifferentProducts(Storage s1, Storage s2, CompareStorageProducts comparer)
        {

            IEnumerable<Product> differentProduct = s1.GetProductList().Except(s2.GetProductList(), new Comparer()).
                Concat(s2.GetProductList().Except(s1.GetProductList(), new Comparer()));
            return differentProduct.ToList();
            
        }

        public static List<Product> GetFirstDefferentProducts(Storage s1, Storage s2, CompareStorageProducts comparer)
        {
            IEnumerable<Product> differentFirst = s1.GetProductList().Except(s2.GetProductList(), new Comparer());
            return differentFirst.ToList();
        }
    }
}
