
using DO;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace Dal;

internal static class DataSource
{
    static DataSource()
    {
        s_Initialize();
    }
    internal static List<Order> OrderList = new List<Order>();
    internal static List<OrderItem> OrderIteamList = new List<OrderItem>();
    internal static List<Product> ProductList = new List<Product>();


    private static void AddProduct()
    {
        for (int i = 1; i < 3; i++)
        {
            Product p = new Product()
            {
                ID = i,
                Price = 500,
                Name = "shirt",
                Cat = ProductCategory.Jordan,
                InStock = 20
            };
            ProductList.Add(p);
            Config.IndexProduct++;

            Product pr = new Product()
            {
                ID = i+2,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.Jordan,
                InStock = 20
            };
            ProductList.Add(pr);
            Config.IndexProduct++;

            Product pro = new Product()
            {
                ID = i+4,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.Sacai,
                InStock = 20
            };
            ProductList.Add(pro);
            Config.IndexProduct++;

            Product prod = new Product()
            {
                ID = i+6,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.DunkSB,
                InStock = 20
            };
            ProductList.Add(prod);
            Config.IndexProduct++;

            Product prode = new Product()
            {
                ID = i+8,
                Price = 500,
                Name = "hat",
                Cat = ProductCategory.Yeezy,
                InStock = 20
            };
            ProductList.Add(prode);
            Config.IndexProduct++;
        }
    }

    static readonly Random rand = new Random();

   // public static CategoryAttribute Jorden { get; private set; }
    //public static CategoryAttribute Yeezy { get; private set; }
    //public static CategoryAttribute DunkSB { get; private set; }

    private static DateTime RandomDay(DateTime date, int startdays, int endays)
    {
        DateTime start = DateTime.Today.AddDays(startdays);
        int range = (DateTime.Today.AddDays(endays) - start).Days;
        return start.AddDays(rand.Next(range));
    }

    // list of names of costumers of orders + cities of costumers 20 each
    private static void AddOrder()
    {
        string[] names = new string[] { "Amir", "Avi", "Yoni", "Dan", "Yali","Joseph", "David", "Maor", " Shira", "Emma", "Agam",
                                         "Haim", "Josephine","Jeremy","Daniel", "Yossi", "Nathan", "Eliyhou", "Hila","Hodaya"};
        string[] adresss = new string[] { "jlm", "Maale adumim", "bni brak", "tlv", "eilat", "rishon lezion", "petah tikva", "ramat gan",
                                           "modiin", "afula", "Herzeliya", "Rosh pinha", "dimona", "dead sea", "ovnat", "Ness ziona", "kiryat ono"
                                          , "ashdod", "ashkelon", "beer sheva"};
        for (int i = 0; i < 20; i++) // updating them
        {
            DateTime randDate = DateTime.MinValue;
            DateTime date1 = RandomDay(randDate, 2, 7);
            DateTime date2 = RandomDay(date1, 1, 2);
  
            Order order = new Order()
            {
                ID = Config.LestOrder,
                CostumerNmae = names[i],
                CostumerEmail = names[i] + "@gameil.com",
                CostumerAdress = adresss[i],
                OrderDate = randDate,
                ShipDate = date1,
                DeliveryrDate = date2,
            };
            OrderList.Add(order);
            Config.IndexOrder++;
        }
    }
    private static void AddOrderItem()
    {
        OrderItem orderIteamLisl = new OrderItem()
        {
            ID = Config.LestOrderItems,
            ProductID = 1,
            OrderID = Config.LestOrder,
            Price = 550,
            Amount = 3,
        };
        OrderIteamList.Add(orderIteamLisl);
        Config.IndexOrderItems++;

    }
    private static void s_Initialize()
    {
        AddProduct();
        AddOrderItem();
        AddOrder();
    }

    internal static class Config
    {
        internal static int IndexOrder = 0;
        internal static int IndexOrderItems = 0;
        internal static int IndexProduct = 0;

        private static int RunningOrderId = 0;
        private static int RunningOrderItemId = 0;
        public static int LestOrder { get => RunningOrderId++; }
        public static int LestOrderItems { get => RunningOrderItemId++; }
    }
}
