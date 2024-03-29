﻿
using BlApi;
//using Dal;
//using DalApi;
using static BO.Enum;
using static DO.Enums;
using System.Linq;
using BO;

namespace BlImplementation;

//The implementation of the interface of the logical entity - Order

internal class Order : IOrder
{
    //private DalApi.IDal dal = new Dal.DalList();
    DalApi.IDal? dal = DalApi.Factory.Get();


    // The function returns a list of all orders
    public IEnumerable<BO.OrderForList?> OrderList()
    {
        List<BO.OrderForList> orderForList = new List<BO.OrderForList>();
        List<DO.Order?> DoOrders = new List<DO.Order?>();
        List<DO.OrderItem?> DoOrderItems = new List<DO.OrderItem?>();
        DoOrders = (List<DO.Order?>)dal!.Order.GetAll()!;
        DoOrderItems = (List<DO.OrderItem?>)dal.OrderItem.GetAll()!;

        //foreach (DO.Order DoOrder in DoOrders!) //We will go through all the products from the data layer
        //{
        //    BO.OrderForList orderForList1 = new BO.OrderForList();
        foreach (var (DoOrder, orderForList1) in from DO.Order DoOrder in DoOrders!//We will go through all the products from the data layer
                let orderForList1 = new BO.OrderForList()
                select (DoOrder, orderForList1))
                {
                    orderForList1.OrderId = DoOrder.ID;
                    orderForList1.BuyerName = DoOrder.CostumerName;
                    if (DoOrder.DeliveryrDate != null) //check if the data is exist
                    {
                        orderForList1.Status = OrderStatus.Delivered;
                    }
                    else if (DoOrder.ShipDate != null)// -||-
                    {
                        orderForList1.Status = OrderStatus.Sent;
                    }
                    else
                    {
                        orderForList1.Status = OrderStatus.Confirmed;
                    }
                    //foreach (var item in DoOrderItems) //We will go over all order items from the data layer
                    //{
                    //    if (item.OrderID == orderForList1.OrderId)
                    //    {
                    foreach (DO.OrderItem item in from item in DoOrderItems//We will go over all order items from the data layer
                             where item?.OrderID == orderForList1.OrderId
                             select item)
                    {
                        orderForList1.TotalPrice += item.Price * item.Amount;
                        orderForList1.AmountOfItems = item.Amount;
                    }

                    orderForList.Add(orderForList1);//We will add to the order list
                }

        return orderForList;
    }
    public BO.Order GetOrder(int id)
    {
        DO.Order DoOrder = new DO.Order();
        List<DO.OrderItem?> DoOrderItem = new List<DO.OrderItem?>();
        List<DO.Product?> DoProducts = new List<DO.Product?>();
        List<BO.OrderItem> boOrderItems = new List<BO.OrderItem>();
        BO.Order? BoOrder = new BO.Order();
        if (id > 0) //Check if the ID is valid
        {
            double finalTotalPrice = 0;
            DoOrder = dal!.Order.GetObj(id);
            DoOrderItem = (List<DO.OrderItem?>)dal.OrderItem.GetAll()!;
            DoProducts = (List<DO.Product?>)dal.Product.GetAll()!;

            BoOrder.Id = DoOrder.ID;
            BoOrder.CostumerName = DoOrder.CostumerName;
            BoOrder.CostumerEmail = DoOrder.CostumerEmail;
            BoOrder.CostumerAdress = DoOrder.CostumerAdress;
            if (DoOrder.OrderDate != null) //Check if the date exists
                BoOrder.OrderDate = (DateTime)DoOrder.OrderDate!;
            if (DoOrder.ShipDate != null) //Check if the date exists
                BoOrder.ShipDate = (DateTime)DoOrder.ShipDate;
            if (DoOrder.DeliveryrDate != null) //Check if the date exists
                BoOrder.DeliveryDate = (DateTime)DoOrder.DeliveryrDate;

            //foreach (DO.OrderItem item in DoOrderItem) //We will go through all the OrderItem from the data layer
            //{
            //    if (id == item.OrderID)
            //    {
            foreach (var (item, boOrderItem) in from DO.OrderItem item in DoOrderItem!//We will go through all the OrderItem from the data layer
                    where id == item.OrderID
                    let boOrderItem = new BO.OrderItem()
                    select (item, boOrderItem))
            {
                boOrderItem.Id = item.OrderID;
                boOrderItem.ProductId = item.ProductID;
                boOrderItem.ProductPrice = item.Price;
                boOrderItem.InOrder = item.Amount;
                boOrderItem.SumPrice = item.Price * item.Amount;
                finalTotalPrice += item.Price * item.Amount;

                //foreach (var product in DoProducts) //We will go over the entire product from the data layer
                //{
                //    if (boOrderItem.ProductId == product.ID)
                //    {
                foreach (var product in from product in DoProducts//We will go over the entire product from the data layer
                        where boOrderItem.ProductId == product?.ID
                        select product)
                {
                    boOrderItem.ProductName = product?.Name;
                    break;
                }

                boOrderItems.Add(boOrderItem);//We will add to the list of order items in the logic layer     
            }

            BoOrder.Details = boOrderItems!;
            BoOrder.TotalPrice = finalTotalPrice;
            if (DoOrder.DeliveryrDate <= DateTime.Now)
            {
                BoOrder.Status = OrderStatus.Delivered;
            }
            else if (DoOrder.ShipDate <= DateTime.Now)
            {
                BoOrder.Status = OrderStatus.Sent;
            }
            else
            {
                BoOrder.Status = OrderStatus.Confirmed;
            }

            return BoOrder;
        }
        throw new BO.BlDataCorruption("id is smaller than 0");
    }


    // The function returns the tracking of the order
    public BO.OrderTracking orderTracking(int id)
    {
        string Item;
        List<DO.Order?> DoOrders = new List<DO.Order?>();
        DoOrders = (List<DO.Order?>)dal!.Order.GetAll()!;
        BO.OrderTracking BoOrderTracking = new BO.OrderTracking();
        bool check = false; //Does such an ID exist?

        //foreach (DO.Order doOrder in DoOrders) // We will go through each order from the data layer
        //{
        //    if (id == doOrder.ID)
        //    {
        foreach (var doOrder in from DO.Order doOrder in DoOrders!// We will go through each order from the data layer
                where id == doOrder.ID
                select doOrder)
        {
            check = true;//Such an ID exists
            BoOrderTracking.OrderId = doOrder.ID;
            if (doOrder.DeliveryrDate != null && doOrder.DeliveryrDate <= DateTime.Now)
            {
                BoOrderTracking.Status = OrderStatus.Delivered;
                Item = "the package was deliverd";
            }
            else if (doOrder.ShipDate != null && doOrder.ShipDate <= DateTime.Now)
            {
                BoOrderTracking.Status = OrderStatus.Sent;
                Item = "the package was sent";
            }
            else
            {
                BoOrderTracking.Status = OrderStatus.Confirmed;
                Item = "the order is confermed in the system";
            }

            var tupleList = new List<(DateTime? myTime, string? Name)>
            {
                (DateTime.Now, Item)
            };
            BoOrderTracking.Tracking = tupleList!;
            break;
        }

        if (!check) //If there was no such ID
        {
            throw new BO.BlDoesNotExistException("The Id Does Not Exist");
        }
        return BoOrderTracking;

    }

    // The function updates the dispatch date of the shipment
    public BO.Order ShipOrderUpate(int id)
    {
        List<BO.OrderItem> boOrderItems = new List<BO.OrderItem>();
        List<DO.Product?> DoProducts = new List<DO.Product?>();
        DoProducts = (List<DO.Product?>)dal!.Product.GetAll()!;
        double finalTotalPrice = 0;
        List<DO.OrderItem?> orderItems = new List<DO.OrderItem?>();
        orderItems = (List<DO.OrderItem?>)dal.OrderItem.GetAll()!;
        List<DO.Order?> DoOrders = new List<DO.Order?>();
        DoOrders = (List<DO.Order?>)dal.Order.GetAll()!;
        BO.Order BoOrder = new BO.Order();
        DO.Order temp = new DO.Order();
        bool check = false;

        //foreach (DO.Order doOrder in DoOrders) //We will go through each order from the data layer
        //{
        //    if (id == doOrder.ID)
        //    {
        foreach (var doOrder in from DO.Order doOrder in DoOrders//We will go through each order from the data layer
                where id == doOrder.ID
                select doOrder)
        {
            check = true;
            if (doOrder.ShipDate == null) //check that the date exists
            {
                BoOrder.ShipDate = temp.ShipDate = DateTime.Now;
            }
            else
            {
                BoOrder.ShipDate = temp.ShipDate = doOrder.ShipDate;
            }

            BoOrder.Id = temp.ID = doOrder.ID;
            BoOrder.CostumerName = temp.CostumerName = doOrder.CostumerName;
            BoOrder.CostumerAdress = temp.CostumerAdress = doOrder.CostumerAdress;
            BoOrder.CostumerEmail = temp.CostumerEmail = doOrder.CostumerEmail;
            BoOrder.OrderDate = temp.OrderDate = doOrder.OrderDate;
            if (doOrder.DeliveryrDate != null) //check that the date exists
                BoOrder.DeliveryDate = temp.DeliveryrDate = doOrder.DeliveryrDate;
            BoOrder.Status = OrderStatus.Sent;
            
            //foreach (var item in orderItems) //We will go through each order item from the data layer
            //{
            //    if (id == item.OrderID)
            //    {
            foreach (var (item, boOrderItem) in from item in orderItems//We will go through each order item from the data layer
                    where id == item?.OrderID
                    let boOrderItem = new BO.OrderItem()
                    select (item, boOrderItem))
            {
                boOrderItem.Id = (int)item?.OrderID!;
                boOrderItem.ProductId = (int)item?.ProductID!;
                boOrderItem.ProductPrice = (int)item?.Price!;
                boOrderItem.InOrder = (int)item?.Amount!;
                boOrderItem.SumPrice = (int)item?.Price! * (int)item?.Amount!;
                finalTotalPrice += (int)item?.Price! * (int)item?.Amount!;

                //foreach (var product in DoProducts)
                //{
                //    if (boOrderItem.ProductId == product.ID)
                //    {
                foreach (var product in from product in DoProducts
                        where boOrderItem.ProductId == product?.ID
                        select product)
                {
                    boOrderItem.ProductName = product?.Name;
                    break;
                }

                boOrderItems.Add(boOrderItem);//We will add order item to the logical layer
            }
        }

        if (check)
        {
            BoOrder.TotalPrice = finalTotalPrice;
            BoOrder.Details = boOrderItems!;
            dal.Order.Update(temp);
            BoOrder.TotalPrice = finalTotalPrice;
            return BoOrder;
        }

        throw new BO.BlDoesNotExistException("No ID Exist");

    }

    public BO.Order DeliveryrOrderUpate(int id)
    {

        List<BO.OrderItem> boOrderItems = new List<BO.OrderItem>();
        List<DO.Product?> DoProducts = new List<DO.Product?>();
        DoProducts = (List<DO.Product?>)dal!.Product.GetAll()!;
        double finalTotalPrice = 0;
        List<DO.OrderItem?> orderItems = new List<DO.OrderItem?>();
        orderItems = (List<DO.OrderItem?>)dal.OrderItem.GetAll()!;
        List<DO.Order?> DoOrders = new List<DO.Order?>();
        DoOrders = (List<DO.Order?>)dal.Order.GetAll()!;
        BO.Order BoOrder = new BO.Order();
        DO.Order temp = new DO.Order();
        bool check = false;

        //foreach (DO.Order doOrder in DoOrders) ////We will go through each order from the data layer
        //{
        //    if (id == doOrder.ID) //Is this the order we are looking for?
        //    {
        foreach (var doOrder in from DO.Order doOrder in DoOrders!////We will go through each order from the data layer
                where id == doOrder.ID//Is this the order we are looking for?
                select doOrder)
        {
            check = true;
            if (doOrder.DeliveryrDate == null) //Does the date exist?
            {
                BoOrder.DeliveryDate = temp.DeliveryrDate = DateTime.Now;
            }
            else
            {
                BoOrder.DeliveryDate = temp.DeliveryrDate = doOrder.DeliveryrDate;
            }

            BoOrder.Id = temp.ID = doOrder.ID;
            BoOrder.CostumerName = temp.CostumerName = doOrder.CostumerName;
            BoOrder.CostumerAdress = temp.CostumerAdress = doOrder.CostumerAdress;
            BoOrder.CostumerEmail = temp.CostumerEmail = doOrder.CostumerEmail;
            BoOrder.OrderDate = temp.OrderDate = doOrder.OrderDate;
            if (doOrder.ShipDate != null) //Does the date exist?
                BoOrder.ShipDate = temp.ShipDate = doOrder.ShipDate;
            BoOrder.Status = OrderStatus.Sent;

            //foreach (var item in orderItems) //We will go through each order item from the data layer
            //{
            //    if (id == item.OrderID) //Is this the order item we are looking for?
            //    {
            foreach (var (item, boOrderItem) in from item in orderItems//We will go through each order item from the data layer
                    where id == item?.OrderID//Is this the order item we are looking for?
                    let boOrderItem = new BO.OrderItem()
                    select (item, boOrderItem))
            {
                boOrderItem.Id = (int)item?.OrderID!;
                boOrderItem.ProductId = (int)item?.ProductID!;
                boOrderItem.ProductPrice = (int)item?.Price!;
                boOrderItem.InOrder = (int)item?.Amount!;
                boOrderItem.SumPrice = (int)item?.Price! * (int)item?.Amount!;
                finalTotalPrice += (int)item?.Price! * (int)item?.Amount!;

                //foreach (var product in DoProducts)  //We will go through each product from the data layer
                //{
                //    if (boOrderItem.ProductId == product.ID)//Is this the product we are looking for?
                //    {
                foreach (var product in from product in DoProducts//We will go through each product from the data layer
                        where boOrderItem.ProductId == product?.ID//Is this the product we are looking for?
                        select product)
                {
                    boOrderItem.ProductName = product?.Name;
                    break;
                }

                boOrderItems.Add(boOrderItem);//We will add order item to the logical layer
            }
        }

        if (check)
        {
            BoOrder.TotalPrice = finalTotalPrice;
            BoOrder.Details = boOrderItems!;
            dal.Order.Update(temp); //We will update the Order object in the data layer
            BoOrder.TotalPrice = finalTotalPrice;
            return BoOrder;
        }

        throw new BO.BlDoesNotExistException("No ID exist");
    }

    /// <returns></returns>
    public int? PriorityOrder(Func<DO.Order?, bool>? filter = null)
    {
        DO.Order order = new DO.Order();

        if (filter != null)
        {
            order = dal!.Order.GetSingle(filter);
        }
        else
        {
            DO.Order? OrderOrderDate = dal?.Order.GetAll(x => x?.ShipDate == null)!.MinBy(x => x?.OrderDate);
            DO.Order? OrderShipDate = dal?.Order.GetAll(x => x?.DeliveryrDate == null)!.MinBy(x => x?.ShipDate);

            if (OrderOrderDate != null && OrderOrderDate?.OrderDate < OrderShipDate?.ShipDate)
            {
                return OrderOrderDate?.ID;
            }
            else if (OrderShipDate != null)
            {
                return OrderShipDate?.ID;
            }

            return null;
        }

        return order.ID;
    }

}