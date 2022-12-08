using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class Enum
{
    public enum ProductCategory { Jordan, Yeezy, Dunk, DunkSB, Sacai } // categories that exist in the store, the types.

    public enum OrderStatus { Confirmed, Sent, Delivered };
}