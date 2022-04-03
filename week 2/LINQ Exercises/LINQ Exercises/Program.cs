using LINQ_Exercises.Classes;
using System;
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

            purchaseService.AddDiscountInStoreForConsumer(consumer1, "Store1", 20);
            purchaseService.AddDiscountInStoreForConsumer(consumer1, "Store2", 10);

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

            purchaseService.Buy(consumer3, product1, "Store1");
            purchaseService.Buy(consumer3, product2, "Store2");


            //purchaseService.StartActivityImitation();

            foreach (var item in purchaseService.purchaseInfos)
            {
                Console.WriteLine("{0}\n{1}\n{2}\n", item.ConsumerCode, item.ProductArticleNumber, item.StoreName);
            }

            //var temp1 = purchaseService.purchaseInfos
            //    .Join(purchaseService.consumersStores,
            //    pi => pi.ConsumerCode,
            //    sp => sp.ConsumerCode,
            //    (pi, sp) => new
            //    {
            //        ConsumerCode = pi.ConsumerCode,
            //        ProductArticleNumber = pi.ProductArticleNumber,
            //        StoreName = sp.StoreName,
            //        Discount = sp.Discount
            //    });
            
            var test = from pi in purchaseService.purchaseInfos
                       join cs in purchaseService.consumersStores
                           on new { pi.ConsumerCode, pi.StoreName } equals new { cs.ConsumerCode, cs.StoreName }
                       select new
                       {
                           ConsumerCode = pi.ConsumerCode,
                           ProductArticleNumber = pi.ProductArticleNumber,
                           StoreName = pi.StoreName,
                           Discount = cs.Discount
                       };


            //var temp2 = temp1.Join(purchaseService.products,
            //    current => current.ProductArticleNumber,
            //    p => p.ArticleNumber,
            //    (current, p) => new
            //    {
            //        ConsumerCode = current.ConsumerCode,
            //        ProductArticleNumber = current.ProductArticleNumber,
            //        StoreName = current.StoreName,
            //        Discount = current.Discount,
            //        ProductCategory = p.Category,
            //        MadeIn = p.CountryOfOrigin
            //    });

            foreach (var item in test)
            {
                Console.WriteLine(
                    "Consumer code:    {0}\n" +
                    "Product article:  {1}\n" +
                    "Store name:       {2}\n" +
                    "Discount:         {3}\n",
                    item.ConsumerCode,
                    item.ProductArticleNumber,
                    item.StoreName,
                    item.Discount);
            }
            return;



            //var temp2 = purchaseService.purchaseInfos.Join(purchaseService.consumers,
            //    pi => pi.ConsumerCode,
            //    c => c.ConsumerCode,
            //    (pi, c) => new
            //    {
            //        ConsumerCode = pi.ConsumerCode,
            //        ProductArticleNumber = pi.ProductArticleNumber,
            //        StoreName = pi.StoreName,
            //        YearOfBirth = c.YearOfBirth,
            //        Address = c.Address
            //    });
            //#region 2
            ///*   var temptemp = temp2.Join(purchaseService.consumersStores,
            //       current => current.ConsumerCode,
            //       cs => cs.ConsumerCode,
            //       (current, cs) => new
            //       {
            //           ConsumerCode = current.ConsumerCode,
            //           ConsumerAddress = current.Address,
            //           YearOfBirth = current.YearOfBirth,
            //           ProductArticleNumber = current.ProductArticleNumber,
            //           StoreName = current.StoreName,
            //           Discount = cs.Discount
            //       });
            //   foreach (var item in temptemp)
            //   {
            //       Console.WriteLine("Consumer code:    {0}\n" +
            //           "Year of birth:    {1}\n" +
            //           "Consumer address: {2}\n" +
            //           "Store name:       {3}\n" +
            //           "Product article:  {4}\n" +
            //           "Consumer discount:{5}\n\n",
            //           item.ConsumerCode,
            //           item.YearOfBirth,
            //           item.ConsumerAddress,
            //           item.StoreName,
            //           item.ProductArticleNumber,
            //           item.Discount);
            //   }
            //   return;*/

            //#endregion

            //var temp3 = temp2.Join(purchaseService.products,
            //    current => current.ProductArticleNumber,
            //    p => p.ArticleNumber,
            //    (current, p) => new
            //    {
            //        ConsumerCode = current.ConsumerCode,
            //        YearOfBirth = current.YearOfBirth,
            //        ConsumerAddress = current.Address,
            //        StoreName = current.StoreName,
            //        ProductArticleNumber = current.ProductArticleNumber,
            //        ProductCategory = p.Category,
            //        MadeIn = p.CountryOfOrigin
            //    });

            //var temp4 = temp3.Join(purchaseService.storesProducts,
            //    current => current.ProductArticleNumber,
            //    sp => sp.ProductArticleNumber,
            //    (current, sp) => new
            //    {
            //        ConsumerCode = current.ConsumerCode,
            //        YearOfBirth = current.YearOfBirth,
            //        ConsumerAddress = current.ConsumerAddress,
            //        StoreName = current.StoreName,
            //        ProductArticleNumber = current.ProductArticleNumber,
            //        ProductCategory = current.ProductCategory,
            //        MadeIn = current.MadeIn,
            //        ProductPrice = sp.ProductPrice
            //    });
            //var temp5 = temp4.Join(purchaseService.consumersStores,
            //    current => current.ConsumerCode,
            //    cs => cs.ConsumerCode,
            //    (current, cs) => new
            //    {
            //        ConsumerCode = current.ConsumerCode,
            //        YearOfBirth = current.YearOfBirth,
            //        ConsumerAddress = current.ConsumerAddress,
            //        StoreName = current.StoreName,
            //        ProductArticleNumber = current.ProductArticleNumber,
            //        ProductCategory = current.ProductCategory,
            //        MadeIn = current.MadeIn,
            //        ProductPrice = current.ProductPrice,
            //        ConsumerDiscount = cs.Discount
            //    });

            //foreach (var item in temp5)
            //{
            //    Console.WriteLine("Consumer code:    {0}\n" +
            //        "Year of birth:    {1}\n" +
            //        "Consumer address: {2}\n" +
            //        "Store name:       {3}\n" +
            //        "Product article:  {4}\n" +
            //        "Product category: {5}\n" +
            //        "Made in:          {6}\n" +
            //        "Product price:    {7}\n" +
            //        "Consumer discount:{8}\n\n",
            //        item.ConsumerCode,
            //        item.YearOfBirth,
            //        item.ConsumerAddress,
            //        item.StoreName,
            //        item.ProductArticleNumber,
            //        item.ProductCategory,
            //        item.MadeIn,
            //        item.ProductPrice,
            //        item.ConsumerDiscount);
            //}
        }
    }
}
