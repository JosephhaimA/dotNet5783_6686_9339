//using BlImplementation;
using Dal;
using DalApi;
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
    static IBl? bl = BlApi.Factory.Get();
   // static IBl bl = Bl.Instance;


    //When the user select CART
    static void optionCart()
    {
        int id = 0, Quantity = 0;
        char option = '1';
        Console.WriteLine(
            "a: To adding an Product to cart\n" +
            "b: To Update Product Quantity in cart\n" +
            "c: To Confirme the Order \n" +
            "press '0' to exit\n");
        bool isRead = char.TryParse(Console.ReadLine(), out option);
        switch (option)
        {
            case 'a':
                Console.WriteLine("Enter the ID number of the product you want to add\n");
                int.TryParse(Console.ReadLine(), out id);
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

    //When the user select ORDER
    static void optionOrder()
    {
         BO.Order order = new BO.Order() { Details = new List<BO.OrderItem>(), };

        Console.WriteLine("\nOrder\n" +
            "a: To receive all orders\n" +
            "b: To receive a certain order, according to Id\n" +
            "c: To update the shipping date of the shipment \n" +
            "d: To update the delivery date of the shipment \n" +
            "e: To get the tracking of the order \n" +
            "any other letter to exit");
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

    //When the user select PRODUCT
    static void optionProduct()
    {
        BO.Product product = new BO.Product();
        Console.WriteLine("\nProduct\n" +
    "a: To view products catalog \n" +
    "b: To view the details of a product by his ID \n" +
    "c: To view the details of a product by his id and cart\n" +    
    "d: To add a product\n" +
    "e: To delete a product\n" +
    "f: To update a product\n" +
    "any other letter to exit");
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
                Console.WriteLine("Enter the ID product you want to view\n");
                isRead = int.TryParse(Console.ReadLine(), out int ID);
                product.Id = ID;
                Console.WriteLine(bl.Product.GetProductAdmin(ID));
                break;


            case 'c':
                Console.WriteLine("Enter the ID product\n");
                isRead = int.TryParse(Console.ReadLine(), out int Id);

                Console.WriteLine(bl.Product.GetProductAdminCostumer(Id, cart));


                break;

            case 'd':
                Console.WriteLine("Enter the ID ,Name ,Price ,Category ,InStock of product to add\n");


                int  inStoce, id , cate ;
                double price;
                string? name;
                BO.Enum.ProductCategory category;
                id = int.Parse(System.Console.ReadLine());
                cate = int.Parse(System.Console.ReadLine());
                inStoce = int.Parse(System.Console.ReadLine());
                price = double.Parse(System.Console.ReadLine());
                name = string.Concat(System.Console.ReadLine());
                category = (BO.Enum.ProductCategory)cate;
                BO.Product NewProduct = new BO.Product()
                {
                    Id = id,
                    Name = name,
                    Category = category,
                    Price = price,
                    InStock = inStoce,
                };
                bl.Product.ProductAdd(NewProduct);
                Console.WriteLine();
                break;

            case 'e':
                Console.WriteLine("Enter the ID of the product to delete\n");
                isRead = int.TryParse(Console.ReadLine(), out ID);
                bl.Product.ProductDelete(ID);

                break;

            case 'f':


                Console.WriteLine("Enter the ID ,Name ,Price ,Category ,InStock  of product you seek to update\n");
                isRead = int.TryParse(Console.ReadLine(), out ID);
                product.Id = ID;
                product.Name = Console.ReadLine();
                isRead = int.TryParse(Console.ReadLine(), out int _price);
                product.Price = _price;
                BO.Enum.ProductCategory c;
                BO.Enum.ProductCategory.TryParse(Console.ReadLine(), out c);
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

        //IDal access = new DalList(); // Access to the data layer



        //Catalog of the products
        IEnumerable<BO.ProductForList> products = (IEnumerable<BO.ProductForList>)bl.Product.ListProduct();
        foreach (var item in products)
        {
            Console.WriteLine(item);
        }

        // the purpose's program is to check the Dal layer
        Console.WriteLine("welcome, please enter your choise\n" +
            "0 for exit \n" +
            "1 for Cart \n" +
            "2 for Order \n" +
            "3 for product.\n" +
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
                        Console.WriteLine("Thank you, would like to see you next time!");
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
            catch (BO.BlDoesNotExistException exe)
            {
                Console.WriteLine(exe.Message);
            }
            if (choice != "0") // if the user haven't enter 0 ask for a new choice
            {
                Console.WriteLine("please enter another choice\n");
            }
        }
    }

    //Asking the user for correct Email input
    public static void EnterEmail()
    {
        do
        {
            Console.WriteLine("\nPlease enter your email address: ");
            cart.CostumerEmail = Console.ReadLine();
        } while (!IsValid(cart.CostumerEmail)); //Checking if the email entered is correct
    }


    // Function for checking the correct of an email address
    public static bool IsValid(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false; 
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

