﻿
using DalApi;
using DO;
using System.Data.Common;
using System.Xml.Linq;

namespace Dal;

public class DalOrder : IOrder
{
    public int Add(Order p) // function add a product
    {
        // int index = OrderFind(p.ID);
        //// if (index == -999)
        {
            int i = DataSource.Config.IndexOrder;
            if (i < 200)
            {
                p.ID = i;
                DataSource.OrderList.Add(p);
                //DataSource.OrderList[i].CostumerNmae = p.CostumerNmae;
                //DataSource.OrderList[i].CostumerEmail = p.CostumerEmail;
                //DataSource.OrderList[i].CostumerAdress = p.CostumerAdress;
                //DataSource.OrderList[i].OrderDate = p.OrderDate;
                //DataSource.OrderList[i].ShipDate = p.ShipDate;
                //DataSource.OrderList[i].DeliveryrDate = p.DeliveryrDate;
                DataSource.Config.IndexOrder++;
                return DataSource.OrderList[i].ID;
            }
            else
                throw new Exception("No such place to add a Order you have to remove one");
        }
       // else
         //   throw new Exception("Order doesn't exist");
    }

    public Order GetObj(int id) // function to return one product
    {
        int index = OrderFind(id);
        if (index != -999)
            return DataSource.OrderList[index]; // return the product 
        else
            throw new Exception("Order doesn't exist");
    }
    public IEnumerable<Order> GetAll() // print all the products
    {
        return DataSource.OrderList;
    }
    public void Update(Order p)
    {
        int i = OrderFind(p.ID);
        if (i != -999)
        {
            Delete(p.ID);
            DataSource.OrderList.Insert(p.ID - 1, p);
        }
        else
            throw new Exception("Order does not exist");

    }

    public void Delete(int id)
    {
        int index = OrderFind(id);
        if (index != -999) // if the id don't exist we cannot delete any product
        {
            for (int i = index; i < DataSource.OrderList.Count - 1; i++)
            {
                // DataSource.OrderList[i] = DataSource.OrderList[1 + i];// jump the product at the arra[index] and copy the rest
                //if (i + 1 == DataSource.OrderList.Count)
                //  break;
                if (id == DataSource.OrderList[i].ID)
                {
                    DataSource.OrderList.Remove(DataSource.OrderList[i]);
                }
            }
            DataSource.OrderList.SkipLast(1).ToArray();// delete the last product beacause we copied at the last place
        }
        else
            throw new Exception("Order does not exist");
    }
    // find function that help us with the main function like add, delete..... to check the exist
    public int OrderFind(int id)
    {
        for (int i = 0; i < DataSource.OrderList.Count ; i++)
        {
            if (id == DataSource.OrderList[i].ID)
                return i;
        }
        return -999;
    }
}
