using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class ProductForList
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public double? ProductPrice { get; set; }
    public Enum.ProductCategory? Category { get; set; }
    public override string ToString() =>
$@"
product id : {ProductId} 
product name: {ProductName} 
product price {ProductPrice}
category : {Category} 
";
}

