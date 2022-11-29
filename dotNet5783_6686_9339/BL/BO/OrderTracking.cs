using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BO;

public class OrderTracking
{
    public int  OrderId { get; set; }
    public bool OrderStatus { get; set; }

    // public List
    public override string ToString() => $@"
Order ID : {OrderId} 
Order Status : {OrderStatus}";
}
