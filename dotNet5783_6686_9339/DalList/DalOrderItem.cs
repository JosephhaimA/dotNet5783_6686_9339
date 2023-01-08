using DalApi;
using DO;
using System;

namespace Dal;

public class DalOrderItem : IOrderItem
{
    DataSource ds = DataSource.Instance;
    public int Add(OrderItem p) // function add a Product
    {
        // int index = OrderItemFind(p.ProductID);
        // if (index == -999)
        {
            int i = DataSource.Config.IndexOrderItems;
            if (i < 200)
            {
                ds.OrderIteamList.Add(p);
                //DataSource.OrderIteamList[i].ID = DataSource.Config.LestOrderItems;
                //DataSource.OrderIteamList[i].OrderID = DataSource.Config.LestOrder;
                //DataSource.OrderIteamList[i].Price = p.Price;
                //DataSource.OrderIteamList[i].Amount = p.Amount;
                DataSource.Config.IndexOrderItems++;
                return (int)ds.OrderIteamList[i]?.OrderID!;
            }
            else
                throw new Exception("No such place to add a OrderItem you have to remove one");
        }
        //  else
        //    throw new Exception("OrderItem doesn't exist");
    }

    public OrderItem GetObj(int id) // function to return one Product
    {
        int index = OrderItemFind(id);
        if (index != -999)
            return (OrderItem)ds.OrderIteamList[index]!; // return the Product 
        else
            throw new Exception("OrderItem doesn't exist");
    }
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? func) // print all the products
    {
        //List<OrderItem?> list = new List<OrderItem?>();
        if (func != null)
        {
            //foreach (OrderItem element in ds.OrderIteamList)
            //{
            //    if (func(element))
            //    {
            //        list.Add(element);
            //    }
            //}
            List<OrderItem?> list = (List<OrderItem?>)
                                 (from order in ds.OrderIteamList
                                  where func(order)
                                  select order);
            return list;
        }
        else
        {
            return ds.OrderIteamList;
        }
    }
    public void Update(OrderItem p)
    {
        //int i = OrderItemFind(p.ID);
        //if (i != -999)
        //{
        //    Delete(p.ID);
        //    ds.OrderIteamList.Insert(p.ID - 1, p);
        //}
        //else
        //    throw new Exception("OrderItem does not exist");
        int count = ds.OrderIteamList.RemoveAll(st => p.ID == st?.ID);
        if (count == 0)
            throw new DO.DalDoesNotExistException("Student");
        ds.OrderIteamList.Insert(p.ID - 1, p);

    }

    public void Delete(int id)
    {
        //int index = OrderItemFind(id);
        //if (index != -999) // if the id don't exist we cannot delete any Product
        //{
        //    for (int i = index; i < ds.OrderIteamList.Count - 1; i++)
        //    {
        //        //DataSource.OrderIteamList[i] = DataSource.OrderIteamList[1 + i];// jump the Product at the arra[index] and copy the rest
        //        //if (i + 1 == DataSource.OrderIteamList.Count)
        //        //  break;
        //        if (id == (int)ds.OrderIteamList[i]?.ID!)
        //        {
        //            ds.OrderIteamList.Remove(ds.OrderIteamList[i]);
        //        }
        //    }
        //    ds.OrderIteamList.SkipLast(1).ToArray();// delete the last Product beacause we copied at the last place
        //}
        //else
        //    throw new Exception("OrderItem does not exist");
        int count = ds.OrderIteamList.RemoveAll(st => id == st?.ID);
        if (count == 0)
            throw new DO.DalDoesNotExistException("Student");
    }

    // find function that help us with the main function like add, delete..... to check the exist
    public int OrderItemFind(int id)
    {
        //Console.WriteLine(DataSource.OrderIteamList.Count);

        for (int i = 0; i < ds.OrderIteamList.Count; i++)
        {
            if (id == (int)ds.OrderIteamList[i]?.ID!)
                return i;
        }
        return -999;
    }

    public OrderItem GetSingle(Func<OrderItem?, bool>? func)
    {
        OrderItem ordOrderItemer = new OrderItem();
        if(func != null)
        {
            ordOrderItemer = (OrderItem)ds.OrderIteamList?.FirstOrDefault(element => func(element))!;
        }
        return ordOrderItemer;
    }
}