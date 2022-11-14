 /*
The shop of Amir Hai and Joseph Haim 
we annouced to open a special store of limited edition products from clothes branch.
 the stroe will include sneakers, shirts, hats and more surprised things.
 -------------
 in our program we made an app for the store that will storage the data of the shop 
 declered what do we have in the shop, amount, orders, dates and more.
 [in Arrays]
 */

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
  
        int op; // option
        bool status;

        do
        {
            System.Console.WriteLine("Enter the option: 1- producttest, 2- ordertest, 3- orderitemtest");
            status = int.TryParse(System.Console.ReadLine(), out op);

        } while (!status); // check if the input is correct
        
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
    // ------------------ If the user chose option 1 in main menu -------------- \\
    private static void ProductTest()
    {
        int op;
        System.Console.WriteLine("*Product* Enter the option: 1 - add, 2 - introduce, 3 - intorudce the list, 4 - update, 5 - delet");
        op = int.Parse(System.Console.ReadLine());
        switch (op)
        {
            case 1: // add product
                ProductTestADD();
                break;
            case 2: // show the product
                ProductTestSHOW();
                break;
            case 3: // the list of 
                ProductTestListShow();
                break;
            case 4: // updating the data of the
                ProductTestDataUpdate();
                break;
            case 5: // delete the product from the list 
                ProductTestDelete();
                break;
            default: // in case that the input incorrect
                Console.WriteLine("wrong choose, must be between 1-5");
                break;
        }
    }

    private static void ProductTestDataUpdate()
    {
        System.Console.WriteLine("Enter Product you want to update");
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
            Console.WriteLine("ERROR cant update");
        }
    }

    private static void ProductTestDelete()
    {
        System.Console.WriteLine("Enter the product ID you intersting to delete");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalProduct.ProductsDelete(id);
        }
        catch(ArgumentException)
        {
            Console.WriteLine("ERROR cant delete");

        }
    }

    private static void ProductTestADD()
    {
        System.Console.WriteLine("Enter Product you want to add ");
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
            Console.WriteLine("ERROR cant add");
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
            Console.WriteLine("ERROR cant show");

        }
    }

    private static void ProductTestSHOW()
    {
        System.Console.WriteLine("Enter Product id you want to introduce");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            dalProduct.ShowProduct(id);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR cant intorduce");

        }
    }
    // ------------------ If the user chose option 2 -------------- \\
    private static void OrderTest()
    {
        int op;
        System.Console.WriteLine("*Order* Enter the option: 1 - add, 2 - introduce, 3 - intorudce the list, 4 - update, 5 - delete");
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
        System.Console.WriteLine("Enter the data of the product to add");
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
            Console.WriteLine("ERROR, cant add");
        }
    }

    private static void OrderTestDataUpdate()
    {
        System.Console.WriteLine("Enter what to update");
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
            Console.WriteLine("ERROR cant update");
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
            Console.WriteLine("ERROR cant delete");
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
            Console.WriteLine("ERROR cant show");

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
            Console.WriteLine("ERROR cant show");

        }
    }
    // ------------------ If the user chose option 3 -------------- \\
    private static void OrderIteamTest()
    {
        int op;
        System.Console.WriteLine("*OrderItem* Enter the option: 1 - add, 2 - introduce, 3 - intorudce the list, 4 - update, 5 - delete");
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