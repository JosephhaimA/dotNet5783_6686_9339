
using DalApi;
using DO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Xml.Linq;

namespace Dal;

public class DalOrder : IOrder
{
    DataSource ds = DataSource.Instance;
    public int Add(Order p) // function add a Product
    {
        {
            int i = DataSource.Config.IndexOrder;
            if (i < 200)
            {
                p.ID = i;
                ds.OrderList.Add(p);
                DataSource.Config.IndexOrder++;
                return (int)ds.OrderList[i]?.ID!;
            }
            else
                throw new Exception("No such place to add a Order you have to remove one");
        }
    }

    public Order GetObj(int id) // function to return one Product
    {
        if (exist(id))
        {
            Order orderReturn = (Order)ds.OrderList.FirstOrDefault(order => order?.ID == id)!;
            return orderReturn;
        }
        else
            throw new DO.DalDoesNotExistException("Order doesn't exist");


        //int index = OrderFind(id);
        //if (index != -999)
        //    return (Order)ds.OrderList[index]!; // return the Product 
        //else
        //    throw new Exception("Order doesn't exist");
    }
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? func) // print all the products
    {
        //List<Order?> list = new List<Order?>();
        if (func != null)
        {
            //foreach (Order element in ds.OrderList)
            //{
            //    if (func(element))
            //    {
            //        list.Add(element);
            //    }
            //}
            List<Order?> list = (List<Order?>)
                                (from order in ds.OrderList
                                 where func(order)
                                 select order);
            return list;
        }
        else
        {
            return ds.OrderList;
        }
    }
    public void Update(Order p)
    {
        //int i = OrderFind(p.ID);
        //if (i != -999)
        //{
        //    Delete(p.ID);
        //    ds.OrderList.Insert(p.ID - 1, p);
        //}
        //else
        //    throw new Exception("Order does not exist");

        int count = ds.OrderList.RemoveAll(st => p.ID == st?.ID);
        if (count == 0)
            throw new DO.DalDoesNotExistException("Student");
        ds.OrderList.Insert(p.ID - 1, p);

    }

    public void Delete(int id)
    {
        //int index = OrderFind(id);
        //if (index != -999) // if the id don't exist we cannot delete any Product
        //{
        //    for (int i = index; i < ds.OrderList.Count - 1; i++)
        //    {
        //        // DataSource.OrderList[i] = DataSource.OrderList[1 + i];// jump the Product at the arra[index] and copy the rest
        //        //if (i + 1 == DataSource.OrderList.Count)
        //        //  break;
        //        if (id == (int)ds.OrderList[i]?.ID!)
        //        {
        //            ds.OrderList.Remove(ds.OrderList[i]);
        //        }
        //    }
        //    ds.OrderList.SkipLast(1).ToArray();// delete the last Product beacause we copied at the last place
        //}
        //else
        //    throw new Exception("Order does not exist");

        int count = ds.OrderList.RemoveAll(st => id == st?.ID);
        if (count == 0)
            throw new DO.DalDoesNotExistException("Student");
    }
    // find function that help us with the main function like add, delete..... to check the exist
    public bool exist(int id)
    {
        for (int i = 0; i < ds.OrderList.Count ; i++)
        {
            if (id == (int)ds.OrderList[i]?.ID!)
                return true;
        }
        return false;
    }

    public Order GetSingle(Func<Order?, bool>? func)
    {
        Order order = new Order();
        if (func != null)
        {
            order = (Order)ds.OrderList?.FirstOrDefault(element => func(element))!;
        }
        return order;
    }
}
