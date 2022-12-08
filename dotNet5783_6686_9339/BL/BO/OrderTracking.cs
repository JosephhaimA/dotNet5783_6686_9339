using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BO.Enum;

namespace BO;

public class OrderTracking
{
    public int  OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public List<(DateTime?,string)> Tracking { get; set; }

    // public List
    public override string ToString() => $@"
Order ID : {OrderId} 
Order Status : {Status}
list of twins: {Tracking}
";
}
