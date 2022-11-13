

using System.Diagnostics;
using System.Xml.Linq;

namespace DO;

public struct Order
{
    public Order(int iD, string costumerNmae, string costumerEmail, string costumerAdress, DateTime orderDate, DateTime shipDate, DateTime deliveryrDate)
    {
        ID = iD;
        CostumerNmae = costumerNmae;
        CostumerEmail = costumerEmail;
        CostumerAdress = costumerAdress;
        OrderDate = orderDate;
        ShipDate = shipDate;
        DeliveryrDate = deliveryrDate;
    }

    public int ID { get; set; }
    public string CostumerNmae { get; set; }
    public string CostumerEmail { get; set; }
    public string CostumerAdress { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }
    public DateTime DeliveryrDate { get; set; }
    public override string ToString() => $@"
order ID : {ID} 
costumer name : {CostumerNmae} , costumer email : {CostumerEmail} , costumer adress {CostumerAdress}
order date : {OrderDate} , ship date : {ShipDate} , {DeliveryrDate}
";

}
