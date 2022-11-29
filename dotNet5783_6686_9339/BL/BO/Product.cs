using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public ProductCategory Category { get;set; }
    public int InStock { get; set; }
    public override string ToString() => $@"
Product ID : {Id} 
Product name : {Name}
Product Price:{Price}
Category : {Category} 
Product stock : {InStock} ";
}

