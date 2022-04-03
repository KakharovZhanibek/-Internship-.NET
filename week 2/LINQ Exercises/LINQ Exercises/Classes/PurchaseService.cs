using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises.Classes
{
    class PurchaseService
    {
        public List<Consumer> consumers = new List<Consumer>();
        public List<Product> products = new List<Product>();
        public List<ConsumerStore> consumersStores = new List<ConsumerStore>();
        public List<StoreProduct> storesProducts = new List<StoreProduct>();
        public List<PurchaseInfo> purchaseInfos = new List<PurchaseInfo>();

        Random rnd = new Random();
        public void StartActivityImitation()
        {
            foreach (Consumer consumer in consumers)
            {
                foreach (Product product in products)
                {
                    if (rnd.Next() % 2 == 0)
                    {
                        Buy(consumer, product, GetStoreWithProduct(product));
                    }
                }
            }
        }
        public void Buy(Consumer consumer, Product product, string storeName)
        {
            if (consumers.Exists(x => x.ConsumerCode == consumer.ConsumerCode)
                && products.Exists(p => p.ArticleNumber == product.ArticleNumber)
                && storesProducts.Exists(x => x.StoreName == storeName && x.ProductArticleNumber == product.ArticleNumber))
            {
                purchaseInfos.Add(new PurchaseInfo()
                {
                    ConsumerCode = consumer.ConsumerCode,
                    ProductArticleNumber = product.ArticleNumber,
                    StoreName = storeName
                });
            }
        }
        public void AddConsumer(Consumer consumer)
        {
            if (consumers.Exists(x => x.ConsumerCode == consumer.ConsumerCode))
                Console.WriteLine("Consumer with this consumer code is already exists!");
            consumers.Add(consumer);
        }
        public void AddProduct(Product product)
        {
            if (products.Exists(x => x.ArticleNumber == product.ArticleNumber))
                Console.WriteLine("Product with this article number is already exists!");
            products.Add(product);
        }

        public void AddDiscountInStoreForConsumer(Consumer consumer, string storeName, int discount)
        {
            if (!consumers.Exists(x => x.ConsumerCode == consumer.ConsumerCode))
                Console.WriteLine("Consumer with this consumer code is not exists!");
            consumersStores.Add(new ConsumerStore()
            {
                ConsumerCode = consumer.ConsumerCode,
                StoreName = storeName,
                Discount = discount
            });
        }
        public void AddProductToStore(Product product, string storeName, int price)
        {
            if (!products.Exists(x => x.ArticleNumber == product.ArticleNumber))
                Console.WriteLine("Product with this article number is not exists!");
            storesProducts.Add(new StoreProduct()
            {
                ProductArticleNumber = product.ArticleNumber,
                StoreName = storeName,
                ProductPrice = price
            });
        }
        private string GetStoreWithProduct(Product product)
        {
            var temp = storesProducts.Where(x => x.ProductArticleNumber == product.ArticleNumber).ToList();
            if (temp.Count == 1)
                return temp.FirstOrDefault().StoreName;
            else if (temp.Count == 0)
                return "";
            return temp[rnd.Next(temp.Count()-1)].StoreName;
        }
    }
}
