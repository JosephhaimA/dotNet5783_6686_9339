using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class Order
{

    public int Id { get; set; }
    public string CostumerName { get; set; }
    public string Costumermail { get; set; }
    public string CostumerAdress { get; set; }
    public bool StatusOrder { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public List<OrderItem> Details {get; set; }
    public float TotalPrice { get; set; }

    public override string ToString() => $@"
order ID : {Id} 
costumer name : {CostumerName} 
costumer email : {Costumermail} 
costumer adress {CostumerAdress}
order date : {OrderDate} 
ship date : {ShipDate} 
dalivery date : {DeliveryDate}
order status : {StatusOrder}
order details: { Details}
total price : {TotalPrice}
";
}
