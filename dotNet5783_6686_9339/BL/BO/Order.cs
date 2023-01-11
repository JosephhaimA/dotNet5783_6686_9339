using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enum;
namespace BO;
public class Order
{
    public int Id { get; set; }
    public string? CostumerName { get; set; }
    public string? CostumerEmail { get; set; }
    public string? CostumerAdress { get; set; }
    public OrderStatus? Status { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public List<OrderItem?>? Details {get; set; }
    public double TotalPrice { get; set; }

    public override string ToString() => $@"
order ID : {Id} 
costumer name : {CostumerName} 
costumer email : {CostumerEmail} 
costumer adress {CostumerAdress}
order date : {OrderDate} 
ship date : {ShipDate} 
dalivery date : {DeliveryDate}
order status : {Status}
order details: { Details}
total price : {TotalPrice}
";
}
