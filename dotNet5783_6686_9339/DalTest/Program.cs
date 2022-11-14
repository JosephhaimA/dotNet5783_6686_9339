using DO;
using System.Xml.Linq;

namespace Dal;
class Program
{
    static DalProduct dalProduct = new DalProduct();
    static DalOrder  dalOrder = new DalOrder();
    static DalOrderItem   dalOrderItem = new DalOrderItem();

    public static void Main(string[] args)
    {
  
        int op;
        bool status;

        do
        {
            System.Console.WriteLine("Enter the option <1,2,3>: ");
            status = int.TryParse(System.Console.ReadLine(), out op);

        } while (!status); 
        
        while (op != 0)
        {
            switch (op)
            {
                case 1:
                    ProductTest();
                    break;
                case 2:
                    OrderTest();
                    break;
                case 3:
                    OrderIteamTest();
                    break;
            }
        }
    }
    private static void ProductTest()
    {
        int op;
        System.Console.WriteLine("Product: Enter the option<1,2,3,4,5>");
        op = int.Parse(System.Console.ReadLine());
        switch (op)
        {
            case 1:
                ProductTestADD();
                break;
            case 2:
                ProductTestSHOW();
                break;
            case 3:
                ProductTestListShow();
                break;
            case 4:
                ProductTestDataUpdate();
                break;
            case 5:
                ProductTestDelete();
                break;
            default:
                Console.WriteLine("wrong choose, must be between 1-5");
                break;
        }
    }

    private static void ProductTestDataUpdate()
    {
        System.Console.WriteLine("Enter Product");
        int id, price, inSt, cate;
        string name;
        ProductCategory category;

        id = int.Parse(System.Console.ReadLine());
        cate = int.Parse(System.Console.ReadLine());
        price = int.Parse(System.Console.ReadLine());
        inSt = int.Parse(System.Console.ReadLine());
        name = Console.ReadLine();
        category = (ProductCategory)cate;

        Product p = new Product
        {
            ID = id,
            Price = price,
            Name = name,
            Cat = category,
            InStock = inSt

        };
        try
        {
            dalProduct.ProductsUpdate(p);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");
        }
    }

    private static void ProductTestDelete()
    {
        System.Console.WriteLine("Enter Product id");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalProduct.ProductsDelete(id);
        }
        catch(ArgumentException)
        {
            Console.WriteLine("ERROR");

        }
    }

    private static void ProductTestADD()
    {
        System.Console.WriteLine("Enter Product");
        int id, price, inSt, cate;
        string name;
        ProductCategory category;
        id = int.Parse(System.Console.ReadLine());
        cate = int.Parse(System.Console.ReadLine());
        price = int.Parse(System.Console.ReadLine());
        inSt = int.Parse(System.Console.ReadLine());
        name = Console.ReadLine();
        category = (ProductCategory)cate;
        Product p = new Product
        {
            ID = id,
            Price = price,
            Name = name,
            Cat = category,
            InStock = 20
        };
        try
        {
            id = dalProduct.ProductAdd(p);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");
        }
    }

    private static void ProductTestListShow()
    {
        try
        {
            dalProduct.ShowAllProduct();
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");

        }
    }

    private static void ProductTestSHOW()
    {
        System.Console.WriteLine("Enter Product id");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalProduct.ShowProduct(id);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");

        }
    }

    private static void OrderTest()
    {
        int op;
        System.Console.WriteLine("Enter the option");
        op = int.Parse(System.Console.ReadLine());
        switch (op)
        {
            case 1:
                OrderTestADD();
                break;
            case 2:
                OrderTestSHOW();
                break;
            case 3:
                OrderTestListShow();
                break;
            case 4:
                OrderTestDataUpdate();
                break;
            case 5:
                OrderTestDelete();
                break;
            default:
                Console.WriteLine("wrong choose, must be between 1-5");
                break;
        }
    }

    private static void OrderTestADD()
    {
        System.Console.WriteLine("Enter order");
        int id, price, inSt, cate;
        string costumerNmae, ostumerEmail, costumerAdress;
        DateTime orderDate, shipDate, deliveryrDate;

        id = int.Parse(System.Console.ReadLine());
        costumerNmae = Console.ReadLine();
        ostumerEmail = Console.ReadLine();
        costumerAdress = Console.ReadLine();
        orderDate = DateTime.Parse(System.Console.ReadLine());
        shipDate = DateTime.Parse(System.Console.ReadLine());
        deliveryrDate = DateTime.Parse(System.Console.ReadLine());

        Order or = new Order
        {
            ID = id,
            CostumerNmae = costumerNmae,
            CostumerEmail = ostumerEmail,
            CostumerAdress = costumerAdress,
            OrderDate = orderDate,
            ShipDate = shipDate,
            DeliveryrDate = deliveryrDate
        };

        try
        {
           id = dalOrder.OrderAdd(or);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");
        }
    }

    private static void OrderTestDataUpdate()
    {
        System.Console.WriteLine("Enter order");
        int id, price, inSt, cate;
        string costumerNmae, ostumerEmail, costumerAdress;
        DateTime orderDate, shipDate, deliveryrDate;

        id = int.Parse(System.Console.ReadLine());
        costumerNmae = Console.ReadLine();
        ostumerEmail = Console.ReadLine();
        costumerAdress = Console.ReadLine();
        orderDate = DateTime.Parse(System.Console.ReadLine());
        shipDate = DateTime.Parse(System.Console.ReadLine());
        deliveryrDate = DateTime.Parse(System.Console.ReadLine());

        Order or = new Order
        {
            ID = id,
            CostumerNmae = costumerNmae,
            CostumerEmail = ostumerEmail,
            CostumerAdress = costumerAdress,
            OrderDate = orderDate,
            ShipDate = shipDate,
            DeliveryrDate = deliveryrDate
        };
        
        try
        {
            dalOrder.OrderItemUpdate(or);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");
        }
    }

    private static void OrderTestDelete()
    {
        System.Console.WriteLine("Enter Product id");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalOrder.OrderDelete(id);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");
        }
    }

    private static void OrderTestListShow()
    {
        try
        {
            dalOrder.ShowAllOrder();
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");

        }
    }

    private static void OrderTestSHOW()
    {
        System.Console.WriteLine("Enter Product id");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalOrder.ShowOrder(id);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR");

        }
    }

    private static void OrderIteamTest()
    {
        int op;
        System.Console.WriteLine("Enter the option");
        op = int.Parse(System.Console.ReadLine());
        switch (op)
        {
            case 1:
                OrderIteamTestADD();
                break;
            case 2:
                OrderIteamTestSHOW();
                break;
            case 3:
                OrderIteamTestListShow();
                break;
            case 4:
                OrderIteamTestDataUpdate();
                break;
            case 5:
                OrderIteamTestDelete();
                break;
            default:
                Console.WriteLine("wrong choose, must be between 1-5");
                break;
        }
    }

    private static void OrderIteamTestDelete()
    {
        System.Console.WriteLine("Enter Product id");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalOrderItem.OrderItemDelete(id);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " +aex.Message);
        }
    }

    private static void OrderIteamTestDataUpdate()
    {
        int productID, orderID, amount;
        double price;

        productID = int.Parse(System.Console.ReadLine());
        orderID = int.Parse(System.Console.ReadLine());
        amount = int.Parse(System.Console.ReadLine());
        price = double.Parse(System.Console.ReadLine());

        OrderItem orI = new OrderItem
        {
            Price = price,  
            ProductID = productID,
            OrderID = orderID,
            Amount = amount
        };

        try
        {
            dalOrderItem.OrderItemUpdate(orI);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " + aex.Message);
        }
    }

    private static void OrderIteamTestADD()
    {
        int productID, orderID, amount;
        double price;

        productID = int.Parse(System.Console.ReadLine());
        orderID = int.Parse(System.Console.ReadLine());
        amount = int.Parse(System.Console.ReadLine());
        price = double.Parse(System.Console.ReadLine());

        OrderItem orI = new OrderItem
        {
            Price = price,
            ProductID = productID,
            OrderID = orderID,
            Amount = amount
        };

        try
        {
            dalOrderItem.OrderItemAdd(orI);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " + aex.Message);
        }
    }

    private static void OrderIteamTestListShow()
    {
        try
        {
            dalOrderItem.ShowAllOrderItem();
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " + aex.Message);
        }
    }

    private static void OrderIteamTestSHOW()
    {
        System.Console.WriteLine("Enter Product id");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalOrderItem.ShowOrderItem(id);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " + aex.Message);
        }
    }
}