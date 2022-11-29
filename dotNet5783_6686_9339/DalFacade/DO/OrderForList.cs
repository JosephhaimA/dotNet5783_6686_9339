using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DO;

public class OrderForList
{
    public int OrderId { get; set; }
    public string BuyerName { get; set; }
    public bool StatusOrder { get; set; }
    public int AmountOfItems { get; set; }
    public float TotalPrice { get; set; }

    public override string ToString() => $@"
Order ID : {OrderId} 
Buyer name : {BuyerName}
order status:{StatusOrder}
Items amount : {AmountOfItems} 
Total order price : {TotalPrice}";


}
