//using BlApi;
//using BlImplementation;
//using BO;
//using Dal;
//using DalApi;
//using System.Security.Authentication;

//namespace BlTest;

//internal class Program
//{
//    static IBl TestM = new  Bl();

//    static BO.Product product = new BO.Product();

//    static BO.Order order = new BO.Order() { Details = new List<OrderItem>(), };

//    static BO.Cart cart = new BO.Cart()  {orderItemsList = new List<OrderItem>(),};
    

//    static void Main(string[] args)
//    {
//        int op; // option
//        bool status;

//        do
//        {
//            System.Console.WriteLine("Enter the option: 1- producttest, 2- ordertest, 3- cart ");
//            status = int.TryParse(System.Console.ReadLine(), out op);

//        } while (!status); // check if the input is correct

//        while (op != 0)
//        {
//            switch (op)
//            {
//                case 1:
//                   // try
//                    {
//                        ProductTest();
//                    }
//                   // catch (Exception masg)
//                    {
//                        //Console.WriteLine("ERROR " + masg.Message);
//                    }
//                    break;
//                case 2:
//                    try
//                    {
//                        OrderTest();
//                    }
//                    catch (Exception masg)
//                    {
//                        Console.WriteLine("ERROR " + masg.Message);
//                    }
//                    break;
//                case 3:
//                    try
//                    {
//                        CartTest();
//                    }
//                    catch (Exception masg)
//                    {
//                        Console.WriteLine("ERROR " + masg.Message);
//                    }
//                    break;
//            }
//            do
//            {
//                System.Console.WriteLine("Enter the option: 1- producttest, 2- ordertest, 3- cart");
//                status = int.TryParse(System.Console.ReadLine(), out op);

//            } while (!status); // check if the input is correct
//        }
//    }

//   static void ProductTest()
//    {
//        int op;
//        System.Console.WriteLine("*Product* Enter the option: 1 - return list of the products, 2 - update, 3 - confirm the order");
//        op = int.Parse(System.Console.ReadLine());
//        switch (op)
//        {
//            case 1: // add Product
//                ListProduct();
//                break;
//            case 2: // show the Product
//                GetProductAdmin();
//                break;
//            case 3: // the list of 
//                GetProductAdminCostumer();
//                break;
//            case 4:
//                ProductAdd();
//                break;
//            case 5:
//                ProductDelete();
//                break;
//            case 6:
//                ProductUpdate();
//                break;
//            default: // in case that the input incorrect
//                Console.WriteLine("wrong choose, must be between 1-5");
//                break;
//        }
//    }

//    private static void ListProduct()
//    {
//        foreach (ProductForList element in TestM.Product.ListProduct())
//        {
//            //element.ToString();
//            Console.WriteLine(element);
//        }
//    }

//    private static void GetProductAdmin()
//    {
//        throw new NotImplementedException();
//    }

//    private static void GetProductAdminCostumer()
//    {
//        throw new NotImplementedException();
//    }

//    private static void ProductAdd()
//    {
//        throw new NotImplementedException();
//    }

//    private static void ProductDelete()
//    {
//        throw new NotImplementedException();
//    }

//    private static void ProductUpdate()
//    {
//        throw new NotImplementedException();
//    }

//    static void OrderTest()
//    {

//    }

//    static void CartTest()
//    {
//        int op;
//        System.Console.WriteLine("*Product* Enter the option: 1 - add, 2 - update, 3 - confirm the order");
//        op = int.Parse(System.Console.ReadLine());
//        switch (op)
//        {
//            case 1: // add Product
//                AddItemToCARTTest();
//                break;
//            case 2: // show the Product
//                UpdateAmountOfProductTest();
//                break;
//            case 3: // the list of 
//                ConfirmationOfOrderTest();
//                break;
//            default: // in case that the input incorrect
//                Console.WriteLine("wrong choose, must be between 1-5");
//                break;
//        }
//    }

//    static void AddItemToCARTTest()
//    {

//        Console.Write("Please enter your name : ");
//        cart.CostumerName = Console.ReadLine();
//        Console.WriteLine("\nPlease enter your address : ");
//        cart.CostumerAdress = Console.ReadLine();
//        string email;
//        do
//        {
//            Console.WriteLine("\nPlease enter your email corectly : ");
//            email = Console.ReadLine();
//            cart.CostumerEmail = email;
//        } while (!email.Contains("@gmail.com"));

//        Console.WriteLine("Enter the ID number of the product you want to add : ");

//        int id;
//        int.TryParse(Console.ReadLine(), out id);

//        TestM.Cart.AddItemToCART(cart, id);
//        return;
//    }

//    static void UpdateAmountOfProductTest()
//    {
//        int id, quantity;
//        Console.WriteLine("Enter the product ID number and the quantity the you want to change");
//        int.TryParse(Console.ReadLine(), out id);
//        int.TryParse(Console.ReadLine(), out quantity);
//        TestM.Cart.UpdateAmountOfProduct(cart,id, quantity);
//        return;
//    }

//    static void ConfirmationOfOrderTest()
//    {
//        TestM.Cart.ConfirmationOfOrder(cart);
//        return;
//    }
//}




//////////////////////////////////////////////////////////////////////////////////////////////





using BlImplementation;

using Dal;
using DalApi;
//using DalList;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DO;
using BO;
using BlApi;

namespace BlTest;

internal class Program
{
    static BO.Cart cart = new BO.Cart() { orderItemsList = new List<BO.OrderItem>(), };
    static IBl bl = Bl.Instance;

    //static BO.Cart cart = new BO.Cart();

    //When the user selects the Cart option
    static void optionCart()
    {
        int id = 0, Quantity = 0;
        char option = '1';
        Console.WriteLine(
            "a in order to adding an Product to cart\n" +
            "b in order to Update Product Quantity in cart\n" +
            "c in order to Confirme the Order \n" +
            "0 to exit\n");
        bool isRead = char.TryParse(Console.ReadLine(), out option);
        switch (option)
        {
            case 'a':
                Console.WriteLine("Enter the ID number of the product you want to add\n");
                int.TryParse(Console.ReadLine(), out id);
               // Console.WriteLine(access.Cart.AddItemToCART(cart, id));
                bl.Cart.AddItemToCART(cart, id);
                break;


            case 'b':
                Console.WriteLine("Enter the product ID number and the quantity the you want to change\n");
                int.TryParse(Console.ReadLine(), out id);
                int.TryParse(Console.ReadLine(), out Quantity);
                Console.WriteLine(bl.Cart.UpdateAmountOfProduct(cart, id, Quantity));
                break;


            case 'c':
                bl.Cart.ConfirmationOfOrder(cart);
                break;

            case '0':
                break;

            default:
                Console.WriteLine("wrong input");
                break;
        }



    }

    //When the user selects the Order option
    static void optionOrder()
    {
        //BO.Order order = new BO.Order();
         BO.Order order = new BO.Order() { Details = new List<BO.OrderItem>(), };

        Console.WriteLine("\nOrder\n" +
            "a in order to receive all orders\n" +
            "b in order to receive a certain order, according to Id\n" +
            "c in order to update the shipping date of the shipment \n" +
            "d in order to update the delivery date of the shipment \n" +
            "e in order to get the tracking of the order \n" +
            "any other letter in order to exit");
        bool isRead = char.TryParse(Console.ReadLine(), out char option);
        switch (option)
        {
            case 'a':
                List<BO.OrderForList> boOrderForLists = bl.Order.OrderList().ToList();
                foreach (var boOrder in boOrderForLists)
                {
                    Console.WriteLine(boOrder);
                }
                break;


            case 'b':
                int id;
                Console.WriteLine("Enter the ID number of the order you want to get\n");
                int.TryParse(Console.ReadLine(), out id);
                Console.WriteLine(bl.Order.GetOrder(id));
                break;


            case 'c':
                Console.WriteLine("Enter the ID of the order for which you want to change the shipping time\n");
                int.TryParse(Console.ReadLine(), out id);
                Console.WriteLine(bl.Order.ShipOrderUpate(id));
                break;

            case 'd':
                Console.WriteLine("Enter the ID of the order for which you want to change the delivery time\n");
                int.TryParse(Console.ReadLine(), out id);
                Console.WriteLine(bl.Order.DeliveryrOrderUpate(id));
                break;

            case 'e':
                Console.WriteLine("Enter the order number you want to track\n");
                int.TryParse(Console.ReadLine(), out id);
                Console.WriteLine(bl.Order.orderTracking(id));

                break;

            default:
                break;
        }
    }

    //When the user selects the Product option
    static void optionProduct()
    {
        DO.Product product = new DO.Product();
        Console.WriteLine("\nProduct\n" +
    "a in order to view products catalog \n" +
    "b in order to view the details of a poduct by its id \n" +
    "c in order to view the details of a poduct by its id and cart\n" +    /////
    "d in order to add a prudoct\n" +
    "e in order to delete a product\n" +
    "f in order to update a product\n" +
    "any other letter in order to exit");
        char option;
        bool isRead = char.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 'a':
                IEnumerable<BO.ProductForList> products = bl.Product.ListProduct();
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                };
                break;

            case 'b':
                Console.WriteLine("Enter the ID product you seek to view\n");
                isRead = int.TryParse(Console.ReadLine(), out int ID);
                product.ID = ID;
                Console.WriteLine(bl.Product.GetProductAdmin(ID));
                break;


            case 'c':
                Console.WriteLine("Enter the ID product\n");
                isRead = int.TryParse(Console.ReadLine(), out int Id);

                Console.WriteLine(bl.Product.GetProductAdminCostumer(Id, cart));


                break;

            case 'd':
                Console.WriteLine("Enter the ID ,Name ,Price ,Category ,InStock  of product you seek to add\n");


                int  inStoce, id , cate ;
                double price;
                string? name;
              //  isRead = int.TryParse(Console.ReadLine(), out Id);
              // // ID = Id;
              //  string name = "aaa";
              //  int cate, inStock;

              //  Cate = int.Parse(System.Console.ReadLine());
              ////  name = Console.ReadLine();
              //  isRead = int.TryParse(Console.ReadLine(), out int price);
              //  isRead = int.TryParse(Console.ReadLine(), out int cate);
                BO.Enum.ProductCategory category;
                id = int.Parse(System.Console.ReadLine());
                cate = int.Parse(System.Console.ReadLine());
                inStoce = int.Parse(System.Console.ReadLine());
                price = double.Parse(System.Console.ReadLine());
                name = string.Concat(System.Console.ReadLine());
                category = (BO.Enum.ProductCategory)cate;

                //  BO.Enum.ProductCategory.TryParse(Console.ReadLine(), out a);
                //  //product.Category = a;

                //  isRead = int.TryParse(Console.ReadLine(), out int inSstock);
                // inStock = inSstock;
                //access.Product.ProductAdd(1, "aa", 12.3, category, 12);
                bl.Product.ProductAdd(id,name, price, category, inStoce);
                Console.WriteLine();
                break;

            case 'e':
                Console.WriteLine("Enter the product ID of the product you want to delete\n");
                isRead = int.TryParse(Console.ReadLine(), out ID);
                bl.Product.ProductDelete(ID);

                break;

            case 'f':


                Console.WriteLine("Enter the ID ,Name ,Price ,Category ,InStock  of product you seek to update\n");
                isRead = int.TryParse(Console.ReadLine(), out ID);
                product.ID = ID;
                product.Name = Console.ReadLine();
                isRead = int.TryParse(Console.ReadLine(), out int _price);
                product.Price = _price;
                DO.Enums.ProductCategory c;
                DO.Enums.ProductCategory.TryParse(Console.ReadLine(), out c);
                product.Category = c;
                int inStock;
                isRead = int.TryParse(Console.ReadLine(), out inStock);
                product.InStock = inStock;
                bl.Product.ProductUpdate(product);

                break;
            default:
                break;
        }

    }



    static void Main(string[] args)
    {
        //The user is asked for his data to enter it in his shopping cart.
        Console.Write("Please enter your name: ");
        cart.CostumerName = Console.ReadLine();
        Console.WriteLine("\nPlease enter your address: ");
        cart.CostumerAdress = Console.ReadLine();


        EnterEmail();
        Console.WriteLine();

        IDal access = new DalList(); // Access to the data layer



        //Catalog of all products
        IEnumerable<BO.ProductForList> products = (IEnumerable<BO.ProductForList>)bl.Product.ListProduct();
        foreach (var item in products)
        {
            Console.WriteLine(item);
        }

        // the purpose's program is to check the Dal layer
        Console.WriteLine("welcome, please enter your choise\n" +
            "0 - exit \n" +
            "1 - Cart \n" +
            "2 - Order \n" +
            "3 - product.\n" +
            "please enter a choice\n");

        string choice = "";

        while (choice != "0") // as long as the user haven't enter 0 continue to ask for new choice
        {
            try
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("goodbye");
                        break;
                    case "1":
                        optionCart();
                        break;
                    case "2":
                        optionOrder();
                        break;
                    case "3":
                        optionProduct();
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
            }
            // Each exception has its own "cathe".
            catch (BO.BlDoesNotExistException exe)
            {
                Console.WriteLine(exe.Message);
            }
            //catch (BO.DalAlreadyExistException exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}
            //catch (BO.DalDataCorruption exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}
            //catch (BO.DalAlreadyExistException exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}
            //catch (BO.OutOfStock exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}
            //catch (BO.InputError exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}
            //catch (BO.IsEmpty exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}


            //catch (DO.DalDoesNotExistException exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}
            //catch (DO.DalAlreadyExistException exe)
            //{
            //    Console.WriteLine(exe.Message);
            //}
            //catch (Exception messege)
            //{
            //    Console.WriteLine(messege.Message);
            //}

            if (choice != "0") // if the user haven't enter 0 ask for a new choice
            {
                Console.WriteLine("please enter another choice\n");
            }
        }
    }


    //Ask the user again and again until he enters a correct email address
    public static void EnterEmail()
    {
        do
        {
            Console.WriteLine("\nPlease enter your email address: ");
            cart.CostumerEmail = Console.ReadLine();
        } while (!IsValid(cart.CostumerEmail)); //Check if the email address entered by the user is correct.
    }


    // Auxiliary function for checking the correctness of an email address
    public static bool IsValid(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false; // suggested by @TK-421
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }
}

