using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQtest
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqMethod3();
        }

        private static void LinsqMethod1()
        {
            string[] countries =
            {
                "Albania", "UK", "Lithuania", "Andorra", "Austria", "Latvia", "Switzerland", "Ireland", "Sweden", "Italy", "France", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro", "Norway", "Finland", "Turkey", "Germany", "Switzerland", "Monaco", "Poland", "Portugal", "Lithuania" };
            var result = from c in countries
                         where c.StartsWith("L")
                         select c;
            var result1 = from c in countries
                          where c.Length > 10
                          select c;
            var result2 = from c in countries
                          where c.StartsWith("L")
                          orderby c.Length
                          select c;
            var result3 = (from c in countries
                           where c.StartsWith("L")

                           orderby c.Length descending
                           select c).Distinct();
            Console.WriteLine("Countries beginning with L: ");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press enter to complete");
            Console.ReadLine();
        }


        private static void LinqMethod2()
        {
            string[] countries =
            {
                "Albania", "UK", "Lithuania", "Andorra", "Austria", "Latvia", "Switzerland", "Ireland", "Sweden", "Italy", "France", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro", "Norway", "Finland", "Turkey", "Germany", "Switzerland", "Monaco", "Poland", "Portugal", "Lithuania" };
            var result = countries.Where(c => c.StartsWith("L"));

            var result1 = countries.OrderBy(c => c.Length).
                Where(c => c.StartsWith("L"));

            var result2 = (countries.OrderBy(c => c.Length).Where(c => c.StartsWith("L"))).Distinct();

            Console.WriteLine("Countries beginning with L: ");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
        }
        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Manufacturater { get; set; }
            public int Count { get; set; }
            public override string ToString()
            {
                return String.Format("{0} {1} {2} {3}", this.Name, this.Price, this.Manufacturater, this.Count);
            }
        }

        private static void LinqMethod3()
        {
            string[] countries =
            {
                "Albania", "UK", "Lithuania", "Andorra", "Austria", "Latvia", "Switzerland", "Ireland", "Sweden", "Italy", "France", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro", "Norway", "Finland", "Turkey", "Germany", "Switzerland", "Monaco", "Poland", "Portugal", "Lithuania" };
            List<Product> products = new List<Product>();

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                
                products.Add(new Product
                {
                    Name = "Product" + (i),
                    Price = rnd.Next(0, 1000),
                    Manufacturater = countries[(rnd.Next(0, countries.Length - 1))],
                    Count = rnd.Next(1, 10)
                }
                    );
            }
            Console.WriteLine("All products: ");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            var result = from c in products
                         where c.Price < 100
                         orderby c.Price
                         select c;
            var result1 = from c in products
                          where c.Price < 100
                          orderby c.Price
                          select c.Name;
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

        }
    }
}
