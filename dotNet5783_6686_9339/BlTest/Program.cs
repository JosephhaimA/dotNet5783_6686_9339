using BlApi;
using BlImplementation;
using BO;
namespace BlTest;

internal class Program
{
    IBl TestM = new  Bl();
    static void Main(string[] args)
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
                    CartTest();
                    break;
            }
            do
            {
                System.Console.WriteLine("Enter the option: 1- producttest, 2- ordertest, 3- orderitemtest");
                status = int.TryParse(System.Console.ReadLine(), out op);

            } while (!status); // check if the input is correct
        }
    }

   public void ProductTest()
    {

    }

    public void OrderTest()
    {

    }

    public void CartTest()
    {
        int op;
        System.Console.WriteLine("*Product* Enter the option: 1 - add, 2 - introduce, 3 - intorudce the list, 4 - update, 5 - delet");
        op = int.Parse(System.Console.ReadLine());
        switch (op)
        {
            case 1: // add Product
                AddItemToCARTTest();
                break;
            case 2: // show the Product
                ProductTestSHOWTest();
                break;
            case 3: // the list of 
                ProductTestListShowTest();
                break;
            default: // in case that the input incorrect
                Console.WriteLine("wrong choose, must be between 1-5");
                break;
        }
    }

    public void AddItemToCARTTest()
    {
        string name, email, adress;

        List<OrderItem> orderItems = new List<OrderItem>();
        int more = 1;
        do
        {


        } while (more == 0);
        double totalPrice;
        Cart cart = new Cart()
        {


        };





    }

    private void ProductTestSHOWTest()
    {
        throw new NotImplementedException();
    }

    private void ProductTestListShowTest()
    {
        throw new NotImplementedException();
    }
}