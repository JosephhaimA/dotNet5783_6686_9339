
using DO;
using System.ComponentModel;

namespace Dal;

internal static class DataSource
{
    // public static readonly DataSource num = new DataSource();
    static Random rand = new Random();
    static internal Order[] OrderArray = new Order[100];
    static internal OrderItem[] OrderIteamArray = new OrderItem[200];
    static internal Product[] ProductArray = new Product[50];
    private static void AddProduct(int ID, string Name, double Price, CategoryAttribute Category, int InStock)
    {
        Product ProductArray = new Product();
        ProductArray.ID = ID;
        ProductArray.Name = Name;
        ProductArray.Price = Price;
        ProductArray.Category = Category;
        ProductArray.InStock = InStock;
    }
    private static void AddOrderItem(int ProductID, int OrderID, double Price, int Amount)
    {
        OrderItem OrderIteamArray = new OrderItem();
        OrderIteamArray.ProductID = ProductID;
        OrderIteamArray.OrderID = OrderID;
        OrderIteamArray.Price = Price;
        OrderIteamArray.Amount = Amount;
    }

    private static void AddOrder(int ID, string CostumerNmae, string CostumerEmail, string CostumerAdress)//, DateTime OrderDate, DateTime ShipDate, DateTime DeliveryrDate)
    {
        Order OrderArray = new Order();
        OrderArray.ID = ID;
        OrderArray.CostumerNmae = CostumerNmae;
        OrderArray.CostumerEmail = CostumerEmail;
        OrderArray.CostumerAdress = CostumerAdress;
        OrderArray.OrderDate = DateTime.MinValue;// OrderDate;
        TimeSpan date = rand;
        OrderArray.ShipDate = TimeSpan+rand ;         //ShipDate;
        OrderArray.DeliveryrDate = ;          //DeliveryrDate;

    }

    private static void s_Initialize(int ID1, string Name, double Price1, CategoryAttribute Category, int InStock, int ProductID, int OrderID, double Price2, int Amount, int ID2, string CostumerNmae, string CostumerEmail, string CostumerAdress)//, DateTime OrderDate, DateTime ShipDate, DateTime DeliveryrDate)
    {
        AddProduct(ID1, Name, Price1, Category, InStock);
        AddOrderItem(ProductID, OrderID, Price2, Amount);
        AddOrder(ID2, CostumerNmae, CostumerEmail, CostumerAdress);//, OrderDate, ShipDate, DeliveryrDate);
    }
}
