using DalApi;
using DO;
using System;

namespace Dal;

public class DalOrderItem : IOrderIteam
{

    public int OrderItemAdd(OrderItem p) // function add a product
    {
       // int index = OrderItemFind(p.ProductID);
       // if (index == -999)
        {
            int i = DataSource.Config.IndexOrderItems;
            if (i < 200)
            {
                DataSource.OrderIteamList.Add(p);
               //DataSource.OrderIteamList[i].ID = DataSource.Config.LestOrderItems;
                //DataSource.OrderIteamList[i].OrderID = DataSource.Config.LestOrder;
                //DataSource.OrderIteamList[i].Price = p.Price;
                //DataSource.OrderIteamList[i].Amount = p.Amount;
                DataSource.Config.IndexOrderItems++;
                return DataSource.OrderIteamList[i].OrderID;
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
            return DataSource.OrderIteamList[index]; // return the product 
        else
            throw new Exception("OrderItem doesn't exist");
    }
    public void ShowAllOrderItem() // print all the products
    {
        foreach (OrderItem element in DataSource.OrderIteamList)
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
            OrderItemDelete(i);
            DataSource.OrderIteamList.Add(p);
        }
        else
            throw new Exception("OrderItem does not exist");

    }

    public void OrderItemDelete(int id)
    {
        int index = OrderItemFind(id);
        if (index != -999) // if the id don't exist we cannot delete any product
        {
            for (int i = index; i < DataSource.OrderIteamList.Count - 1; i++)
            {
                //DataSource.OrderIteamList[i] = DataSource.OrderIteamList[1 + i];// jump the product at the arra[index] and copy the rest
                //if (i + 1 == DataSource.OrderIteamList.Count)
                //  break;
                if (id == DataSource.OrderIteamList[i].ID)
                {
                    DataSource.OrderIteamList.Remove(DataSource.OrderIteamList[i]);
                }
            }
            DataSource.OrderIteamList.SkipLast(1).ToArray();// delete the last product beacause we copied at the last place
        }
        else
            throw new Exception("OrderItem does not exist");
    }

    // find function that help us with the main function like add, delete..... to check the exist
    public int OrderItemFind(int id)
    {
        for (int i = 0; i < DataSource.OrderIteamList.Count; i++)
        {
            if (id == DataSource.OrderIteamList[i].ID)
                return i;
        }
        return -999;
    }
}
