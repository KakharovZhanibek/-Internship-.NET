using LINQ_Exercises.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseService purchaseService = new PurchaseService();

            Product product1 = new Product() { ArticleNumber = "a", Category = "Electronic", CountryOfOrigin = "China" };
            Product product2 = new Product() { ArticleNumber = "b", Category = "Home", CountryOfOrigin = "Germany" };
            Product product3 = new Product() { ArticleNumber = "c", Category = "Sport", CountryOfOrigin = "Hungary" };
            Product product4 = new Product() { ArticleNumber = "d", Category = "Garden", CountryOfOrigin = "USA" };
            Product product5 = new Product() { ArticleNumber = "e", Category = "Building", CountryOfOrigin = "China" };
            Product product6 = new Product() { ArticleNumber = "f", Category = "Gadjet", CountryOfOrigin = "Germany" };
            Product product7 = new Product() { ArticleNumber = "g", Category = "Sport", CountryOfOrigin = "Hungary" };
            Product product8 = new Product() { ArticleNumber = "h", Category = "Watch", CountryOfOrigin = "USA" };

            Consumer consumer1 = new Consumer() { ConsumerCode = 1, YearOfBirth = 2002, Address = "st.12" };
            Consumer consumer111 = new Consumer() { ConsumerCode = 111, YearOfBirth = 2002, Address = "st.111" };
            Consumer consumer2 = new Consumer() { ConsumerCode = 2, YearOfBirth = 1997, Address = "st.11" };
            Consumer consumer3 = new Consumer() { ConsumerCode = 3, YearOfBirth = 1985, Address = "st.97" };
            Consumer consumer4 = new Consumer() { ConsumerCode = 4, YearOfBirth = 1972, Address = "st.46" };

            purchaseService.AddProduct(product1);
            purchaseService.AddProduct(product2);
            purchaseService.AddProduct(product3);
            purchaseService.AddProduct(product4);
            purchaseService.AddProduct(product5);
            purchaseService.AddProduct(product6);
            purchaseService.AddProduct(product7);
            purchaseService.AddProduct(product8);

            purchaseService.AddConsumer(consumer1);
            purchaseService.AddConsumer(consumer2);
            purchaseService.AddConsumer(consumer3);
            purchaseService.AddConsumer(consumer4);
            purchaseService.AddConsumer(consumer111);

            purchaseService.AddDiscountInStoreForConsumer(consumer1, "Store1", 20);
            purchaseService.AddDiscountInStoreForConsumer(consumer1, "Store2", 10);

            purchaseService.AddDiscountInStoreForConsumer(consumer111, "Store1", 25);
            purchaseService.AddDiscountInStoreForConsumer(consumer111, "Store2", 30);

            purchaseService.AddDiscountInStoreForConsumer(consumer2, "Store1", 5);
            purchaseService.AddDiscountInStoreForConsumer(consumer2, "Store2", 30);

            purchaseService.AddDiscountInStoreForConsumer(consumer3, "Store1", 15);

            purchaseService.AddDiscountInStoreForConsumer(consumer4, "Store2", 5);


            purchaseService.AddProductToStore(product1, "Store1", 500);
            purchaseService.AddProductToStore(product1, "Store2", 520);
            purchaseService.AddProductToStore(product1, "Store3", 510);

            purchaseService.AddProductToStore(product2, "Store1", 1000);
            purchaseService.AddProductToStore(product2, "Store2", 1100);

            purchaseService.AddProductToStore(product3, "Store1", 2289);
            purchaseService.AddProductToStore(product3, "Store3", 2299);

            purchaseService.AddProductToStore(product3, "Store1", 5480);

            purchaseService.AddProductToStore(product4, "Store3", 700);

            purchaseService.AddProductToStore(product5, "Store2", 560);

            purchaseService.AddProductToStore(product5, "Store3", 600);

            purchaseService.AddProductToStore(product6, "Store1", 4560);
            purchaseService.AddProductToStore(product7, "Store2", 2020);
            purchaseService.AddProductToStore(product8, "Store3", 30000);

            //purchaseService.Buy(consumer3, product1, "Store1");
            //purchaseService.Buy(consumer3, product2, "Store2");


            purchaseService.StartActivityImitation();


            var anonType = new
            {
                ConsumerCode = 0,
                ProductArticleNumber = "",
                StoreName = "",
                Discount = 0
            };

            var list = new[] { anonType }.ToList();
            list.Clear();

            foreach (var item in purchaseService.purchaseInfos)
            {
                if (!purchaseService.consumersStores.Exists(x => x.ConsumerCode == item.ConsumerCode && x.StoreName == item.StoreName))
                {
                    list.Add(new
                    {
                        ConsumerCode = item.ConsumerCode,
                        ProductArticleNumber = item.ProductArticleNumber,
                        StoreName = item.StoreName,
                        Discount = 0
                    });
                }
                else
                {
                    list.Add(new
                    {
                        ConsumerCode = item.ConsumerCode,
                        ProductArticleNumber = item.ProductArticleNumber,
                        StoreName = item.StoreName,
                        Discount = purchaseService.consumersStores.Find(x => x.ConsumerCode == item.ConsumerCode && x.StoreName == item.StoreName).Discount
                    });
                }
            }

            var temp1 = list.Join(purchaseService.products,
                current => current.ProductArticleNumber,
                p => p.ArticleNumber,
                (current, p) => new
                {
                    ConsumerCode = current.ConsumerCode,
                    ProductArticleNumber = current.ProductArticleNumber,
                    StoreName = current.StoreName,
                    Discount = current.Discount,
                    ProductCategory = p.Category,
                    MadeIn = p.CountryOfOrigin
                });


            var temp2 = temp1.Join(purchaseService.consumers,
                current => current.ConsumerCode,
                c => c.ConsumerCode,
                (current, c) => new
                {
                    ConsumerCode = current.ConsumerCode,
                    ProductArticleNumber = current.ProductArticleNumber,
                    StoreName = current.StoreName,
                    Discount = current.Discount,
                    ProductCategory = current.ProductCategory,
                    MadeIn = current.MadeIn,
                    YearOfBirth = c.YearOfBirth,
                    Address = c.Address
                });

            var temp3 = from current in temp2
                        join sp in purchaseService.storesProducts
                            on new { current.ProductArticleNumber, current.StoreName } equals new { sp.ProductArticleNumber, sp.StoreName }
                        select new
                        {
                            ConsumerCode = current.ConsumerCode,
                            YearOfBirth = current.YearOfBirth,
                            Address = current.Address,
                            ProductArticleNumber = current.ProductArticleNumber,
                            ProductCategory = current.ProductCategory,
                            MadeIn = current.MadeIn,
                            StoreName = current.StoreName,
                            ProductPrice = sp.ProductPrice,
                            Discount = current.Discount
                        };

            Console.WriteLine("Before LINQ");
            foreach (var item in temp3.OrderBy(o => o.MadeIn).ThenBy(o => o.StoreName).ThenBy(o => o.ConsumerCode))
            {
                Console.WriteLine("Consumer code:    {0}\n" +
                    "Year of birth:    {1}\n" +
                    "Consumer address: {2}\n" +
                    "Product article:  {3}\n" +
                    "Product category: {4}\n" +
                    "Made in:          {5}\n" +
                    "Store name:       {6}\n" +
                    "Product price:    {7}\n" +
                    "Consumer discount:{8}\n\n",
                    item.ConsumerCode,
                    item.YearOfBirth,
                    item.Address,
                    item.ProductArticleNumber,
                    item.ProductCategory,
                    item.MadeIn,
                    item.StoreName,
                    item.ProductPrice,
                    item.Discount);
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");


            //Task LINQ---------------------

            var resultSequence = temp3
                                        .OrderBy(o => o.MadeIn)
                                        .ThenBy(o => o.StoreName)
                                        .ThenBy(o => o.ConsumerCode)
                                        .GroupBy(t => new
                                        {
                                            t.StoreName,
                                            t.MadeIn,
                                        })
                                        .SelectMany(sm => sm.Where(w => w.YearOfBirth == sm.Max(m => m.YearOfBirth)).Select(s => new
                                        {
                                            MadeIn = s.MadeIn,
                                            StoreName = s.StoreName,
                                            YearOfBirth = s.YearOfBirth, /* x.Max(e => e.YearOfBirth),*/
                                            ConsumerCode = s.ConsumerCode,
                                            ProductArticleNumber = s.ProductArticleNumber,
                                            ProductCategory = s.ProductCategory,
                                            ProductPrice = s.ProductPrice,
                                            Discount = s.Discount,
                                        }))
                                        .GroupBy(gr => new
                                        {
                                            gr.StoreName,
                                            gr.MadeIn,
                                            gr.ConsumerCode
                                        })
                                        .Select(x => new
                                        {
                                            MadeIn = x.Key.MadeIn,
                                            StoreName = x.Key.StoreName,
                                            YearOfBirth = x.FirstOrDefault(f => f.ConsumerCode == x.Key.ConsumerCode).YearOfBirth,
                                            ConsumerCode = x.Key.ConsumerCode,
                                            Discount = x.FirstOrDefault(f => f.ConsumerCode == x.Key.ConsumerCode).Discount,
                                            TotalSumOfAllPurchases = x.Sum(s => s.ProductPrice - s.ProductPrice * s.Discount / 100)
                                        });


            Console.WriteLine("\nAfter LINQ\n");

            foreach (var item in resultSequence)
            {
                Console.WriteLine(
                                    "\nMade in:          {0}\n" +
                                    "Store Name:       {1}\n" +
                                    "   Consumer code:     {2}\n" +
                                    "   Year of birth:     {3}\n" +
                                    "   Discount:          {4} %\n"+
                                    "   SumOfAllPurchases: {5}\n\n",
                                    item.MadeIn,
                                    item.StoreName,
                                    item.ConsumerCode,
                                    item.YearOfBirth,
                                    item.Discount,
                                    item.TotalSumOfAllPurchases
               );
            }
        }
    }
}

