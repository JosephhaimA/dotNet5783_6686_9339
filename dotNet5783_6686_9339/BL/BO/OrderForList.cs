using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BO.Enum;

namespace BO;

public class OrderForList
{
    public int OrderId { get; set; }
    public string? BuyerName { get; set; }
    public  OrderStatus Status { get; set; }
    public int AmountOfItems { get; set; }
    public double TotalPrice { get; set; }

    public override string ToString() => $@"
Order ID : {OrderId} 
Buyer name : {BuyerName}
order status:{Status}
Items amount : {AmountOfItems} 
Total order price : {TotalPrice}";


}
