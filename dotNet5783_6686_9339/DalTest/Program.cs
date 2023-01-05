/*
The shop of Amir Hai and Joseph Haim 
we annouced to open a special store of limited edition products from clothes branch.
the stroe will include sneakers, shirts, hats and more surprised things.
-------------
in our program we made an app for the store that will storage the data of the shop 
declered what do we have in the shop, amount, orders, dates and more.
[in Arrays]
*/
using Dal;
using DalApi;
using DO;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace Dal;
class Program
{
    //static DalProduct dalProduct = new DalProduct();
    //static DalOrder  dalOrder = new DalOrder();
    //static DalOrderItem   dalOrderItem = new DalOrderItem();

    private static IDal TestM = DalApi.Factory.Get();
    // private static IDal TestM = DalList.Instance;


    //public static object Config { get; private set; }


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
            do
            {
                System.Console.WriteLine("Enter the option: 1- producttest, 2- ordertest, 3- orderitemtest");
                status = int.TryParse(System.Console.ReadLine(), out op);

            } while (!status); // check if the input is correct
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
            case 1: // add Product
                ProductTestADD();
                break;
            case 2: // show the Product
                ProductTestSHOW();
                break;
            case 3: // the list of 
                ProductTestListShow();
                break;
            case 4: // updating the data of the
                ProductTestDataUpdate();
                break;
            case 5: // delete the Product from the list 
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
        Enums.ProductCategory category;
        System.Console.WriteLine("write: ID, Category, Price, Instock, name");
        id = int.Parse(System.Console.ReadLine());
        cate = int.Parse(System.Console.ReadLine());
        price = int.Parse(System.Console.ReadLine());
        inSt = int.Parse(System.Console.ReadLine());
        name = Console.ReadLine();
        category = (Enums.ProductCategory)cate;

        Product p = new Product
        {
            ID = id,
            Price = price,
            Name = name,
            Category = category,
            InStock = inSt
        };
        try
        {
            TestM.Product.Update(p);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR cant update");
        }
    }

    private static void ProductTestDelete()
    {
        System.Console.WriteLine("Enter the Product ID you intersting to delete");
        int id;
        id = int.Parse(System.Console.ReadLine());
        try
        {
            TestM.Product.Delete(id);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR cant delete");
        }
    }

    private static void ProductTestADD()
    {
        System.Console.WriteLine("Enter Product you want to add ");
        System.Console.WriteLine("write: ID, Category, Price, Instock, name");
        int id, price, inSt, cate;
        string name;
        Enums.ProductCategory category;
        id = int.Parse(System.Console.ReadLine());
        cate = int.Parse(System.Console.ReadLine());
        //cate = Console.ReadLine();
        price = int.Parse(System.Console.ReadLine());
        inSt = int.Parse(System.Console.ReadLine());
        name = Console.ReadLine();
        category = (Enums.ProductCategory)cate;
        Product p = new Product
        {
            ID = id,
            Price = price,
            Name = name,
            Category = category,
            //Cat = category,
            //InStock = 20
            InStock = inSt,
        };
        try
        {
            id = TestM.Product.Add(p);
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
            foreach (Product element in TestM.Product.GetAll())
            {
                if (element.ID != 0)
                    Console.WriteLine(element);
            }
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
        Product p;
        try
        {
            p = TestM.Product.GetObj(id);
            Console.WriteLine(p);

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
        System.Console.WriteLine("*Order* Enter the option: 1 - add, 2 - introduce, 3 - intorudce the list, 4 - update, 5 - delete ");
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
        System.Console.WriteLine("Enter the data of the order to add");
        System.Console.WriteLine("write: CostumerName, CostumerE, Adress, Date, ShipDate, EstimateDelivery");

        int price, inSt, cate;
        string costumerNmae, ostumerEmail, costumerAdress;
        DateTime orderDate, shipDate, deliveryrDate;

        costumerNmae = Console.ReadLine();
        ostumerEmail = Console.ReadLine();
        costumerAdress = Console.ReadLine();
        orderDate = DateTime.Parse(System.Console.ReadLine());
        shipDate = DateTime.Parse(System.Console.ReadLine());
        deliveryrDate = DateTime.Parse(System.Console.ReadLine());

        Order or = new Order
        {
            //  ID = DataSource.Config.LastOrder,
            CostumerName = costumerNmae,
            CostumerEmail = ostumerEmail,
            CostumerAdress = costumerAdress,
            OrderDate = orderDate,
            ShipDate = shipDate,
            DeliveryrDate = deliveryrDate
        };

        try
        {
            TestM.Order.Add(or);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR, cant add");
        }
    }

    private static void OrderTestDataUpdate()
    {
        System.Console.WriteLine("Enter what to update");
        System.Console.WriteLine("write: ID, CostumerE, costumerAdress, DateOfOrder, ShipDate, EstimatedDeliveryDate");

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
            CostumerName = costumerNmae,
            CostumerEmail = ostumerEmail,
            CostumerAdress = costumerAdress,
            OrderDate = orderDate,
            ShipDate = shipDate,
            DeliveryrDate = deliveryrDate
        };

        try
        {
            TestM.Order.Update(or);
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
            TestM.Order.Delete(id);
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
            foreach (Order element in TestM.Order.GetAll())
            {
                if (element.ID != 0)
                    Console.WriteLine(element);
            }
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
        Order O;
        try
        {
            O = TestM.Order.GetObj(id);
            Console.WriteLine(O);
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
            TestM.OrderItem.Delete(id);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " + aex.Message);
        }
    }

    private static void OrderIteamTestDataUpdate()
    {
        System.Console.WriteLine("Enter what to update");
        System.Console.WriteLine("write: ID,productID OrderID, amount, price");

        int productID, orderID, amount, id;
        double price;
        id = int.Parse(System.Console.ReadLine());
        productID = int.Parse(System.Console.ReadLine());
        orderID = int.Parse(System.Console.ReadLine());
        amount = int.Parse(System.Console.ReadLine());
        price = double.Parse(System.Console.ReadLine());

        OrderItem orI = new OrderItem
        {
            ID = id,
            Price = price,
            ProductID = productID,
            OrderID = orderID,
            Amount = amount
        };

        try
        {
            TestM.OrderItem.Update(orI);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " + aex.Message);
        }
    }

    private static void OrderIteamTestADD()
    {
        int productID, orderID, amount, id;
        double price;
        System.Console.WriteLine("Enter what to update");
        System.Console.WriteLine("write: ID, productID , OrderID, amount, price");

        id = int.Parse(System.Console.ReadLine());
        productID = int.Parse(System.Console.ReadLine());
        orderID = int.Parse(System.Console.ReadLine());
        amount = int.Parse(System.Console.ReadLine());
        price = double.Parse(System.Console.ReadLine());

        OrderItem orI = new OrderItem
        {
            ID = id,
            Price = price,
            ProductID = productID,
            OrderID = orderID,
            Amount = amount
        };

        try
        {
            TestM.OrderItem.Add(orI);
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
            foreach (OrderItem element in TestM.OrderItem.GetAll())
            {
                if (element.ID != 0)
                    Console.WriteLine(element);
            }
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
        OrderItem OI;
        try
        {
            OI = TestM.OrderItem.GetObj(id);
            Console.WriteLine(OI);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine("ERROR " + aex.Message);
        }
    }
}