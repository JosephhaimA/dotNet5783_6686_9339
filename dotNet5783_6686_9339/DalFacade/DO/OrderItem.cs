

namespace DO;

public struct OrderItem
{

    // get and set metodot
    public int ID { get; set; }
    public int ProductID { get; set; }
    public int OrderID { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public override string ToString() => $@"
ID : {ID}
prodect ID : {ProductID} 
order ID : {OrderID} 
price : {Price}
amount {Amount}
";
}
