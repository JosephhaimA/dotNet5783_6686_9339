
using DO;

namespace Dal;

public class DalOrder
{
    public int OrderAdd(Order p) // function add a product
    {
        int index = OrderFind(p.ID);
        if (index == -999)
        {
            int i = DataSource.Config.IndexOrderItems;
            if (i < 200)
            {
                DataSource.OrderArray[i] = new Order();
                DataSource.OrderArray[i].ID = DataSource.Config.RunningIndexOrder;
                DataSource.OrderArray[i].CostumerNmae = p.CostumerNmae;
                DataSource.OrderArray[i].CostumerEmail = p.CostumerEmail;
                DataSource.OrderArray[i].CostumerAdress = p.CostumerAdress;
                DataSource.OrderArray[i].OrderDate = p.OrderDate;
                DataSource.OrderArray[i].ShipDate = p.ShipDate;
                DataSource.OrderArray[i].DeliveryrDate = p.DeliveryrDate;
                return DataSource.OrderArray[i].ID;
            }
            else
                throw new Exception("No such place to add a Order you have to remove one");
        }
        else
            throw new Exception("Order doesn't exist");
    }

    public Order ShowOrder(int id) // function to return one product
    {
        int index = OrderFind(id);
        if (index != -999)
            return DataSource.OrderArray[index]; // return the product 
        else
            throw new Exception("Order doesn't exist");
    }
    public void ShowAllOrder() // print all the products
    {
        foreach (Order element in DataSource.OrderArray)
        {
            if (element.ID == 0)
                break;
            Console.WriteLine(element);
        }
    }
    public void OrderItemUpdate(Order p)
    {
        int i = OrderFind(p.ID);
        if (i != -999)
        {
            DataSource.OrderArray[i].ID = p.ID;
            DataSource.OrderArray[i].CostumerNmae = p.CostumerNmae;
            DataSource.OrderArray[i].CostumerEmail = p.CostumerEmail;
            DataSource.OrderArray[i].CostumerAdress = p.CostumerAdress;
            DataSource.OrderArray[i].OrderDate = p.OrderDate;
            DataSource.OrderArray[i].ShipDate = p.ShipDate;
            DataSource.OrderArray[i].DeliveryrDate = p.DeliveryrDate;
        }
        else
            throw new Exception("Order does not exist");

    }

    public void OrderDelete(int id)
    {
        int index = OrderFind(id);
        if (index != -999) // if the id don't exist we cannot delete any product
        {
            for (int i = index; i < DataSource.OrderArray.Length - 1; i++)
            {
                DataSource.OrderArray[i] = DataSource.OrderArray[1 + i];// jump the product at the arra[index] and copy the rest
                if (i + 1 == DataSource.OrderArray.Length)
                    break;
            }
            DataSource.OrderArray.SkipLast(1).ToArray();// delete the last product beacause we copied at the last place
        }
        else
            throw new Exception("Order does not exist");
    }
    // find function that help us with the main function like add, delete..... to check the exist
    public int OrderFind(int id)
    {
        for (int i = 0; i < DataSource.OrderArray.Length; i++)
        {
            if (id == DataSource.OrderArray[i].ID)
                return i;
        }
        return -999;
    }
}
