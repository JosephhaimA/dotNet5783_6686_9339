

namespace DO;

public struct OrderItem
{

    // get and set metodot
    public int ProductID { get; set; }
    public int OrderID { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public override string ToString() => $@"
prodect ID : {ProductID} ,  order ID : {OrderID} 
price : {Price} , amount {Amount}
";
}
