using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation;
sealed public class Bl : IBl
{
    private static IBl instance;
    public static IBl Instance { get => instance; }
    static Bl() { instance = new Bl(); }
    private Bl() { }

    public IProduct Product => new Product();
    public IOrder Order => new Order();
    public ICart Cart => new Cart();

}

