using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public double? ProductPrice { get; set; }
    public int? InOrder { get; set; }
    public double? SumPrice { get; set; }

    public override string ToString() => 
$@"
order item ID : {Id} 
product id : {ProductId} 
product name: {ProductName} 
product price {ProductPrice}
how much in order : {InOrder} 
sum price to this item : {SumPrice} 
";
}

