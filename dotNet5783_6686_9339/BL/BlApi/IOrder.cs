using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BlApi;
public interface IOrder
{
    public IEnumerable<OrderForList> OrderList();
    public Order GetOrder(int id);
    public Order ShipOrderUpate(int Orderid);
    public Order DeliveryrOrderUpate(int id);
    public OrderTracking orderTracking(int id);

}

