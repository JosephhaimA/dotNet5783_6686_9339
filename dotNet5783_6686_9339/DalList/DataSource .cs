
using DO;
using System;
using System.ComponentModel;

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
        Product ProductArray = new Product();
        ProductArray.ID = //ID;
        ProductArray.Name = //Name;
        ProductArray.Price = //Price;
        ProductArray.Category = //Category;
        ProductArray.InStock = //InStock;
    }

    private static void AddOrderItem()
    {
        OrderItem OrderIteamArray = new OrderItem();
        OrderIteamArray.ProductID = //ProductID;
        OrderIteamArray.OrderID = //OrderID;
        OrderIteamArray.Price = //Price;
        OrderIteamArray.Amount = //Amount;
    }
    private static void s_Initialize()
    {
        AddProduct();
        AddOrderItem();
        AddOrder();
    }

    static readonly Random rand = new Random();
    private static DateTime RandomDay(DateTime date, int startdays, int endays)
    {
        DateTime start = DateTime.Today.AddDays(startdays);
        int range = (DateTime.Today.AddDays(endays) - start).Days;
        return start.AddDays(rand.Next(range));
    }
    private static void AddOrder()
    { 
        Order OrderArray = new Order();
        OrderArray.ID = //ID;
        OrderArray.CostumerNmae = //CostumerNmae;
        OrderArray.CostumerEmail = //CostumerEmail;
        OrderArray.CostumerAdress = //CostumerAdress;
        OrderArray.OrderDate = DateTime.MinValue;// OrderDate;
        DateTime date = RandomDay(OrderArray.OrderDate,2, 7) ;
        OrderArray.ShipDate = date ;         //ShipDate;
        DateTime date2 = RandomDay(OrderArray.ShipDate,1,2);   //הוראות על פי המרצה
        OrderArray.DeliveryrDate = date2;          //DeliveryrDate;

    }
    internal static class Config
    {
        internal static int IndexOrder = 0;
        internal static int IndexOrderItems = 0;
        internal static int IndexProduct = 0;

        public static int RunningIndexOrder = 0;
        public static int RunningIndexOrderItems = 0;
        private static int LestOrder { get => RunningIndexOrder++ ; }
        private static int LestOrderItems { get => RunningIndexOrderItems++ ; }
    }
}
/*
using DO;

namespace Dal;

/// <summary>
/// Data container for DalList 
/// </summary>
internal sealed class DataSource
{
    internal static DataSource s_instance { get; } = new DataSource();
    private DataSource()
    {
        initialize();
    }

    private static readonly Random s_rand = new();

    internal static class Config
    {
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrderNumber { get => s_nextOrderNumber++; }
    }

    internal List<Order?> _orders { get; } = new List<Order?> { };
    internal List<Product?> _products { get; } = new List<Product?> { };
    internal List<OrderItem?> _orderItems { get; } = new List<OrderItem?> { };

    private void initialize()
    {
        createProducts();
        createOrders();
        createOrderItems();
    }

    private void createOrders()
    {
        String[] cities = { "Tel Aviv", "Jerusalem", "Haifa", "Ashdod", "Lod", "Bnei Brak", "Ramat Gan", "Giv'ataim",
            "Holon", "Bat Yam", "Rishon le-Zion", "Karnei Shomron", "Ariel", "Efrat", "Nokdim", "Ashkelon", "Kiriat Gat" };
        Tuple<string, string>[] customers = { new ("Avi Rosenfield", "avi"), new ("", "yossi"),
            new("Dani Zzilberstein", "dani"), new("Boris Lifshitz", "boris"), new("Yanki Schwarz", "yanki"),
            new("Hadar Sofief", "hadar"), new("David Kidron", "david"), new("Orit Rosenblit", "orit"),
            new("Efrat Amar", "efrat"), new("Yitzik Liebenson", "yitzik"), new("Shimi Weiss", "shimi"),
            new("Rubi Shilat", "rubi"), new("Yudi Noiman", "yudi"), new("Sara Genut", "sara"),
            new("Leale Rachimi", "leale"), new("Rivcki Itzchaki", "rivki"), new("Rochky Raz", "rochky"),
            new("Dina Shuster", "dina"), new("Sachi Shalom", "sachi"), new("Moty Moravia", "moti"),
            new("Zelda Singer", "zelda"), new("Tzila Lisogorsky", "tzila"), new("Ronnie Ben-Zaken", "ronnie"),
            new("Frieda Levin", "frieda"),};
        for (int i = 20; i > 0; --i)
        {
            int customer = s_rand.Next(customers.Length);
            bool shipped = s_rand.NextDouble() < 0.7D;
            bool delivered = s_rand.NextDouble() < 0.3D;
            Order order = new ()
            {
                ID = Config.NextOrderNumber,
                CustomerName = customers[customer].Item1,
                CustomerAddress = cities[s_rand.Next(cities.Length)],
                CustomerEmail = customers[customer].Item2 + "@jctmail.com",
            };
            if (shipped)
            {
                if (delivered)
                {
                    order.DeliveryDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
                    order.ShipDate = order.DeliveryDate - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 7L));
                }
                else
                {
                    order.ShipDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 7L));
                }
                order.OrderDate = order.ShipDate - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 3L));
            }
            else
                order.OrderDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L));

            _orders.Add(order);
        }
    }

    private void createOrderItems()
    {
        for (int i = 0; i < 10; i++)
        {
            Product? product = _products[s_rand.Next(_products.Count)];
            _orderItems.Add(
                new OrderItem
                {
                    OrderID = s_rand.Next(Config.s_startOrderNumber, Config.s_startOrderNumber + _orders.Count),
                    ProductID = product?.ID ?? 0,
                    Price = product?.Price ?? 0,
                    Amount = s_rand.Next(5),
                });
        }
    }
    [Forwarded from Eliezer Gensburger]
private void createProducts()
    {
        for (int i = 0; i < 10; i++)
        {
            _products.Add(
                new Product
                {
                    ID = i,
                    Name = "aaa",
                    Price = s_rand.Next(200),
                    Category = (Category)s_rand.Next(5),
                    InStock = s_rand.Next(50),
                });
        }
    }
}
*/