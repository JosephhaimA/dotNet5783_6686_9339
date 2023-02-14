﻿
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal;
/// <summary>
/// class DalOrder: 
/// Implementation of add, delete, update and return operations
/// </summary>
internal class DalOrder : IOrder
{
    const string orderPath = "Order";
    static XElement config = XmlTools.LoadConfig();

    /// <summary>
    /// The operation accepts an order and adds it in the array
    /// </summary>
    /// <returns> returns order id </returns>
    public int Add(Order ord)
    {
        List<DO.Order?> ListOrder = XmlTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        if (ListOrder.FirstOrDefault(orderItem => orderItem?.ID == ord.ID) != null)
            throw new Exception("id already exist");

        ord.ID = int.Parse(config.Element("OrderID")!.Value) + 1;
        XmlTools.SaveConfigXElement("OrderID", ord.ID);

        ListOrder.Add(ord);

        XmlTools.SaveListToXMLSerializer(ListOrder, orderPath);

        return ord.ID;
    }

    /// <summary>
    ///  The operation deletes an order from the array (finds him by id)
    /// </summary>
    public void Delete(int ordId)
    {
        List<DO.Order?> ListOrder = XmlTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        if (ListOrder.Any(order => order?.ID == ordId))
            ListOrder.Remove(GetObj(ordId));
        else
            throw new DO.DalDoesNotExistException("order does not exist");
        XmlTools.SaveListToXMLSerializer(ListOrder, orderPath);
    }

    /// <summary>
    /// The operation returns list of orders (maybe after sort)
    /// </summary>
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? func = null)
    {
        List<DO.Order?> ListOrder = XmlTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        if (func == null)
            return ListOrder.Select(lec => lec).OrderBy(lec => lec?.ID);
        else
            return ListOrder.Where(func).OrderBy(lec => lec?.ID);
    }

    public Order GetSingle(Func<Order?, bool>? func)
    {
        List<DO.Order?> ListOrder = XmlTools.LoadListFromXMLSerializer<DO.Order>(orderPath);
        if (func != null)
        {
            var ord = ListOrder.FirstOrDefault(x => func(x));
            if (ord != null)
                return (DO.Order)ord;
        }
        throw new DO.DalDoesNotExistException("No object is of the delegate");
    }

    /// <summary>
    ///  The operation finds the order (finds him by id) and returns his details
    /// </summary>
    public Order GetObj(int ordId)
    {
        List<DO.Order?> ListOrder = XmlTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        var ord = ListOrder.FirstOrDefault(x => x?.ID == ordId);

        if (ord == null)
            throw new DO.DalDoesNotExistException("Order Id not found");
        else
            return (DO.Order)ord;
    }

    /// <summary>
    /// returns array length
    /// </summary>
    public int ListLength()
    {
        List<DO.Order?> ListOrder = XmlTools.LoadListFromXMLSerializer<DO.Order>(orderPath);
        return ListOrder.Count();
    }

    /// <summary>
    /// The operation updates an order in the array (finds him by id)
    /// </summary>
    public void Update(Order order)
    {
        List<DO.Order?> ListOrder = XmlTools.LoadListFromXMLSerializer<DO.Order>(orderPath);
        bool found = false;
        var foundOrder = ListOrder.FirstOrDefault(ord => ord?.ID == order.ID);
        if (foundOrder != null)
        {
            found = true;
            int index = ListOrder.IndexOf(foundOrder);
            ListOrder[index] = order;
        }
        if (found == false)
            throw new DO.DalDoesNotExistException("Order Id not found");
        XmlTools.SaveListToXMLSerializer(ListOrder, orderPath);

    }
}
