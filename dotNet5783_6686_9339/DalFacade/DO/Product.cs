

using System.ComponentModel;

namespace DO;

/// <summary>
/// structure 
/// </summary>
public struct Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Enums.ProductCategory Category { get; set; }
    public int InStock { get; set; }

    public override string ToString() => $@"
Product ID : {ID} ,
Product name : {Name}
Product Price:{Price},
Category : {Category} 
Product stock : {InStock} ";

}
