using RedisRepository;
using System;
using System.Collections.Generic;

namespace RedisRepositoryTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RedisQuery<Product> query = new RedisQuery<Product>();
            query.Add(new Product() { Name="cxb",CreateTime= "2020-3-17 16:28:31" });
            query.Add(new Product() { Name = "utr", CreateTime = "2020-3-19 16:28:31" });
            var nWhere= query.Where(n => n.Name == "cxb");
            var cWhere = nWhere.Where(c=>c.CreateTime=="2020-3-17 16:28:31");
            var eWhere = cWhere.AsEnumerable();
            var list = cWhere.ToList();

            Console.WriteLine("Hello World!");
        }

        public class Product {
            public string Name { get; set; }
            public string CreateTime { get; set; }
        }
    }
}
