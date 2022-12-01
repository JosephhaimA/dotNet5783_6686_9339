
using DalApi;
using DO;
using System.Data.Common;
using System.Xml.Linq;

namespace Dal;

public class DalOrder : IOrder
{
    DataSource ds = DataSource.Instance;
    public int Add(Order p) // function add a Product
    {
        // int index = OrderFind(p.ID);
        //// if (index == -999)
        {
            int i = DataSource.Config.IndexOrder;
            if (i < 200)
            {
                p.ID = i;
                ds.OrderList.Add(p);
                //DataSource.OrderList[i].CostumerName = p.CostumerName;
                //DataSource.OrderList[i].CostumerEmail = p.CostumerEmail;
                //DataSource.OrderList[i].CostumerAdress = p.CostumerAdress;
                //DataSource.OrderList[i].OrderDate = p.OrderDate;
                //DataSource.OrderList[i].ShipDate = p.ShipDate;
                //DataSource.OrderList[i].DeliveryrDate = p.DeliveryrDate;
                DataSource.Config.IndexOrder++;
                return ds.OrderList[i].ID;
            }
            else
                throw new Exception("No such place to add a Order you have to remove one");
        }
       // else
         //   throw new Exception("Order doesn't exist");
    }

    public Order GetObj(int id) // function to return one Product
    {
        int index = OrderFind(id);
        if (index != -999)
            return ds.OrderList[index]; // return the Product 
        else
            throw new Exception("Order doesn't exist");
    }
    public IEnumerable<Order> GetAll() // print all the products
    {
        return ds.OrderList;
    }
    public void Update(Order p)
    {
        int i = OrderFind(p.ID);
        if (i != -999)
        {
            Delete(p.ID);
            ds.OrderList.Insert(p.ID - 1, p);
        }
        else
            throw new Exception("Order does not exist");

    }

    public void Delete(int id)
    {
        int index = OrderFind(id);
        if (index != -999) // if the id don't exist we cannot delete any Product
        {
            for (int i = index; i < ds.OrderList.Count - 1; i++)
            {
                // DataSource.OrderList[i] = DataSource.OrderList[1 + i];// jump the Product at the arra[index] and copy the rest
                //if (i + 1 == DataSource.OrderList.Count)
                //  break;
                if (id == ds.OrderList[i].ID)
                {
                    ds.OrderList.Remove(ds.OrderList[i]);
                }
            }
            ds.OrderList.SkipLast(1).ToArray();// delete the last Product beacause we copied at the last place
        }
        else
            throw new Exception("Order does not exist");
    }
    // find function that help us with the main function like add, delete..... to check the exist
    public int OrderFind(int id)
    {
        for (int i = 0; i < ds.OrderList.Count ; i++)
        {
            if (id == ds.OrderList[i].ID)
                return i;
        }
        return -999;
    }
}
