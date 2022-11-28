using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public int InOrder { get; set; }
    public int SumPrice { get; set; }

    public override string ToString() => 
$@"
order item ID : {Id} 
order id : {OrderId} 
product name: {ProductName} 
product price {ProductPrice}
how much in order : {InOrder} 
sum price to this item : {SumPrice} 
";
}

