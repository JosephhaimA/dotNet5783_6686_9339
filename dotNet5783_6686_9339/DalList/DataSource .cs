
using DO;
using System.ComponentModel;

namespace Dal;

internal static class DataSource
{
   // public static readonly DataSource num = new DataSource();
    static internal Order[] OrderArray = new Order[100];
    static internal OrderItem[] OrderIteamArray = new OrderItem[200];
    static internal Product[] ProductArray = new Product[50];
    private static void AddOrderItem(int ProductID, int OrderID, double Price, int Amount)
    {
        OrderItem OrderIteamArray = new OrderItem();
        OrderIteamArray.ProductID = ProductID;
        OrderIteamArray.OrderID = OrderID;
        OrderIteamArray.Price = Price;
        OrderIteamArray.Amount = Amount;
    }
    private static void AddProduct(int ID, string Name, double Price, CategoryAttribute Category, int InStock)
    {
        Product ProductArray = new Product();
        ProductArray.ID = ID;
        ProductArray.Name = Name;
        ProductArray.Price = Price;
        ProductArray.Category = Category;
        ProductArray.InStock = InStock;
    }

    private static void AddOrder(int ID, string CostumerNmae, string CostumerEmail, string CostumerAdress, DateTime OrderDate , DateTime ShipDate, DateTime DeliveryrDate)
    {
        Order OrderArray = new Order();
        OrderArray.ID = ID;
        OrderArray.CostumerNmae = CostumerNmae;
        OrderArray.CostumerEmail = CostumerEmail;
        OrderArray.CostumerAdress = CostumerAdress;
        OrderArray.OrderDate = OrderDate;
        OrderArray.ShipDate = ShipDate;
        OrderArray.DeliveryrDate = DeliveryrDate;

    }

    private static int s_Initialize;

}
