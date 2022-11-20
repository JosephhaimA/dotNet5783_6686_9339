
using DO;
using System;

namespace Dal;

public class DalOrderItem
{

    public int OrderItemAdd(OrderItem p) // function add a product
    {
       // int index = OrderItemFind(p.ProductID);
       // if (index == -999)
        {
            int i = DataSource.Config.IndexOrderItems;
            if (i < 200)
            {
                DataSource.OrderIteamArray[i] = p;
                DataSource.OrderIteamArray[i].ID = DataSource.Config.LestOrderItems;
                //DataSource.OrderIteamArray[i].OrderID = DataSource.Config.LestOrder;
                //DataSource.OrderIteamArray[i].Price = p.Price;
                //DataSource.OrderIteamArray[i].Amount = p.Amount;
                DataSource.Config.IndexOrderItems++;
                return DataSource.OrderIteamArray[i].OrderID;
            }
            else
                throw new Exception("No such place to add a OrderItem you have to remove one");
        }
      //  else
        //    throw new Exception("OrderItem doesn't exist");
    }

    public OrderItem ShowOrderItem(int id) // function to return one product
    {
        int index = OrderItemFind(id);
        if (index != -999)
            return DataSource.OrderIteamArray[index]; // return the product 
        else
            throw new Exception("OrderItem doesn't exist");
    }
    public void ShowAllOrderItem() // print all the products
    {
        foreach (OrderItem element in DataSource.OrderIteamArray)
        {
            if (element.ProductID != 0) 
                Console.WriteLine(element);

        }
    }
    public void OrderItemUpdate(OrderItem p)
    {
        int i = OrderItemFind(p.ProductID);
        if (i != -999)
        {
            DataSource.OrderIteamArray[i].ID = p.ID;
            DataSource.OrderIteamArray[i].ProductID = p.ProductID;
            DataSource.OrderIteamArray[i].OrderID = p.OrderID;
            DataSource.OrderIteamArray[i].Price = p.Price;
            DataSource.OrderIteamArray[i].Amount = p.Amount;
        }
        else
            throw new Exception("OrderItem does not exist");

    }

    public void OrderItemDelete(int id)
    {
        int index = OrderItemFind(id);
        if (index != -999) // if the id don't exist we cannot delete any product
        {
            for (int i = index; i < DataSource.OrderIteamArray.Length - 1; i++)
            {
                DataSource.OrderIteamArray[i] = DataSource.OrderIteamArray[1 + i];// jump the product at the arra[index] and copy the rest
                if (i + 1 == DataSource.OrderIteamArray.Length)
                    break;
            }
            DataSource.OrderIteamArray.SkipLast(1).ToArray();// delete the last product beacause we copied at the last place
        }
        else
            throw new Exception("OrderItem does not exist");
    }

    // find function that help us with the main function like add, delete..... to check the exist
    public int OrderItemFind(int id)
    {
        for (int i = 0; i < DataSource.OrderIteamArray.Length; i++)
        {
            if (id == DataSource.OrderIteamArray[i].ID)
                return i;
        }
        return -999;
    }
}
