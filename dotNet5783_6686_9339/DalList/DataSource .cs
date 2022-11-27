
using DO;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace Dal;

internal sealed class DataSource
{
    private static  readonly DataSource _instance;
    public static DataSource Instance { get { return _instance; } }

    static DataSource()
    {
       _instance = new DataSource();
    }
    private DataSource()
    {
        s_Initialize();
    }
    internal  List<Order> OrderList = new List<Order>();
    internal  List<OrderItem> OrderIteamList = new List<OrderItem>();
    internal  List<Product> ProductList = new List<Product>();

    private  void InitProducts()
    {
        for (int i = 1; i < 7; i += 5)
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
                ID = i+1,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.Jordan,
                InStock = 20
            };
            ProductList.Add(pr);
            Config.IndexProduct++;

            Product pro = new Product()
            {
                ID = i+2,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.Sacai,
                InStock = 20
            };
            ProductList.Add(pro);
            Config.IndexProduct++;

            Product prod = new Product()
            {
                ID = i+3,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.DunkSB,
                InStock = 20
            };
            ProductList.Add(prod);
            Config.IndexProduct++;

            Product prode = new Product()
            {
                ID = i+4,
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
    private  void InitOrders()
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
    private  void InitOrderItem()
    {
        for (int i = 1; i < 6; i++)
        {
            OrderItem orderIteamLisl = new OrderItem()
            {
                ID = Config.LestOrderItems,
                ProductID = i,
                OrderID = i,
                Price = 450+10*i,
                Amount = 10+i*2,
            };
            OrderIteamList.Add(orderIteamLisl);
            Config.IndexOrderItems++;
        }
    }
    private  void s_Initialize()
    {
        InitProducts();
        InitOrderItem();
        InitOrders();
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
