
using DO;
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
    static internal Order[] OrderArray = new Order[100];
    static internal OrderItem[] OrderIteamArray = new OrderItem[200];
    static internal Product[] ProductArray = new Product[50];
    private static void AddProduct()
    {
        for (int i = 0; i < 2; i++)
        {
            ProductArray[i] = new Product
            {
                ID = i,
                Price = 500,
                Name = "shirt",
                Cat = ProductCategory.Jordan,
                InStock = 20
            };
            Config.IndexProduct++;

            ProductArray[i+1] = new Product
            {
                ID = i+1,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.Jordan,
                InStock = 20

            };
            Config.IndexProduct++;

            ProductArray[i+2] = new Product
            {
                ID = i+2,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.Sacai,
                InStock = 20

            };
            Config.IndexProduct++;

            ProductArray[i+3] = new Product
            {
                ID = i+3,
                Price = 500,
                Name = "sneakers",
                Cat = ProductCategory.DunkSB,
                InStock = 20

            }; Config.IndexProduct++;

            ProductArray[i+4] = new Product
            {
                ID = i+4,
                Price = 500,
                Name = "hat",
                Cat = ProductCategory.Yeezy,
                InStock = 20

            }; Config.IndexProduct++;
        }
    }

    static readonly Random rand = new Random();

    public static CategoryAttribute Jorden { get; private set; }
    public static CategoryAttribute Yeezy { get; private set; }
    public static CategoryAttribute DunkSB { get; private set; }

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
            Order OrderArray = new Order()
            {
                ID = Config.LestOrder,
                CostumerNmae = names[i],
                CostumerEmail = names[i] + "@gameil.com",
                CostumerAdress = adresss[i],
                OrderDate = randDate,
                ShipDate = date1,
                DeliveryrDate = date2,
            };
                Config.IndexOrder++;
        }
    }
    private static void AddOrderItem()
    {
        OrderItem OrderIteamArray = new()
        {
            ProductID = Config.LestOrderItems,
            OrderID = Config.LestOrder,
            Price = 550,
            Amount = 3,
        };
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
