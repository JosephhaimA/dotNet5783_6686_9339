

using System.Diagnostics;
using System.Xml.Linq;

namespace DO;

public struct Order
{
    public int ID { get; set; }
    public string CostumerNmae { get; set; }
    public string CostumerEmail { get; set; }
    public string CostumerAdress { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime shipDate { get; set; }
    public DateTime DeliveryrDate { get; set; }
    public override string ToString() => $@"
order ID : {ID} 
costumer name : {CostumerNmae} , costumer email : {CostumerEmail} , costumer adress {CostumerAdress}
order date : {OrderDate} , ship date : {shipDate} , {DeliveryrDate}
";

}
