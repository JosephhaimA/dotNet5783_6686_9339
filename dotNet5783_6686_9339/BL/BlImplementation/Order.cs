using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlApi;

namespace BlImplementation;
internal class Order : IOrder 
{
    private DalApi.IDal dal = new Dal.DalList();

    public BO.Order DeliveryrOrderUpate(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Order GetOrder(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.OrderForList> OrderList()
    {
        throw new NotImplementedException();
    }

    public BO.OrderTracking orderTracking(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Order ShipOrderUpate(int id)
    {
        throw new NotImplementedException();
    }
}

