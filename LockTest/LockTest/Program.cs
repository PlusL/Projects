using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//from:http://www.cnblogs.com/chenwolong/p/LoveFuTing.html
namespace LockTest
{
        class Program1
        {
            private static object o = new object();
            private static List<Product> _Products { get; set; }

            static void Main(string[] args)
            {
                _Products = new List<Product>();

                Task t1 = Task.Factory.StartNew(() =>
                {
                    AddProducts();
                });

                Task t2 = Task.Factory.StartNew(() =>
                {
                    AddProducts();
                });

                Task t3 = Task.Factory.StartNew(() =>
                {
                    AddProducts();
                });
                Task.WaitAll(t1, t2, t3);
                Console.WriteLine(_Products.Count);
                Console.ReadLine();
            }


            static void AddProducts()
            {
                Parallel.For(0, 1000, (i) =>
                {
                    lock (o)//lock to prevent threads error
                    {
                        Product product = new Product();
                        product.Name = "name" + i;
                        product.Category = "Category" + i;
                        product.SellPrice = i;
                        _Products.Add(product);
                    }
                });

            }
        }

        class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int SellPrice { get; set; }
        }
}
