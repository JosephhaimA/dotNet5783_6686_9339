using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Cart
{
    public string? CostumerName { get; set; }
    public string? CostumerEmail { get; set; }
    public string? CostumerAdress { get; set; }
    public List<OrderItem>? orderItemsList { get; set; }
    public double? TotalPrice { get; set; }

    public override string ToString() =>
$@"
costumer name : {CostumerName} 
costumer email : {CostumerEmail} 
costumer adress: {CostumerAdress} 
order item list {orderItemsList}
total price : {TotalPrice} 
";
}

