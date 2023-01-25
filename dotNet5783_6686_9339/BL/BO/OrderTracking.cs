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
    public int OrderId { get; set; }
    public OrderStatus? Status { get; set; }
    public List<(DateTime?, string?)>? Tracking { get; set; }

    // public List
    public override string ToString()
    {
        string str = "Id: " + OrderId + "\nStatus: " + Status + "\nTracking:\n ";
        int i = 1;
        foreach (var tracking in Tracking)
        {

            str += i + ":\n" + tracking.Item1;
            str += "\n" + tracking.Item2;
            i++;
        }
        return str;
    }
}