using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


using BlApi;
using static BO.Enum;
using static DO.Enums;
//using BO;
//using DO;

namespace BlImplementation;
internal class Product : IProduct
{
    private DalApi.IDal dal = new Dal.DalList();

    public IEnumerable<BO.ProductForList> ListProduct()
    {
        List<DO.Product> L_P = dal.Product.GetAll().ToList();
        List<BO.ProductForList> productForLists = new List<BO.ProductForList>();
        //{
        //    new BO.ProductForList(),
        // };
        for (int i = 0; i < L_P.Count; i++)
        {
            //Console.WriteLine(i);

            //int cat = (int)L_P[i].Category;
            BO.ProductForList PFR = new BO.ProductForList()
            {
                ProductId = L_P[i].ID,
                ProductName = L_P[i].Name,
                ProductPrice = L_P[i].Price,
                //Category = (BO.Enum.ProductCategory)cat,
            };
            productForLists.Add(PFR);
            //productForLists[i].ProductId = L_P[i].ID;
            //productForLists[i].ProductName = L_P[i].Name;
            //productForLists[i].ProductPrice = L_P[i].Price;
            //int cat = (int)L_P[i].Category;
            //productForLists[i].Category = (BO.Enum.ProductCategory)cat;
        }
        return productForLists;
    }

    public BO.Product GetProductAdmin(int id)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            int cat = (int)product.Category;
            product = dal.Product.GetObj(id);
            BO.Product NewProduct = new BO.Product()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.Enum.ProductCategory)cat,
                InStock = product.InStock,
            };
            return NewProduct;
        }
        else
        {
            throw new Exception("ERROR the id was - ");
        }
    }

    public BO.ProductItem GetProductAdminCostumer(int id, BO.Cart cart)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            int cat = (int)product.Category;
            product = dal.Product.GetObj(id);
            bool exsixs;
            if (product.InStock != 0)
                exsixs = true;
            else
                exsixs = false;
            BO.ProductItem productItem = new BO.ProductItem()
            {
                ProductId = product.ID,
                ProductName = product.Name,
                ProductPrice = product.Price,
                Category = (BO.Enum.ProductCategory)cat,
                InStock = exsixs,
                Amount = product.InStock,
            };
            return productItem;
        }
        else
        {
            throw new Exception("ERROR the id was - ");
        }
    }

    public void ProductAdd(int id, string name, double price, BO.Enum.ProductCategory category, int intStock)
    {
        if (id <= 0)
        {
            throw new Exception("ERROR: ID WAS -");
        }

        if (name == null)
        {
            throw new Exception("the name empty");
        }

        if (price <= 0)
        {
            throw new Exception("ERROR: price WAS -");
        }

        if (intStock <= 0)
        {
            throw new Exception("ERROR in stock WAS -");
        }

        DO.Product product = new DO.Product()
        {
            ID = id,
            Name = name,    
            Price = price,
            Category = (DO.Enums.ProductCategory)category,
            InStock = intStock
        };
        try
        {
            dal.Product.Add(product);

        }
        catch (Exception mas)
        {
            throw new BO.BlAlreadyExistException("invalid product operation",mas);
        }
    }

    public void ProductDelete(int id)
    {
        List<DO.OrderItem> ListItem = new List<DO.OrderItem>();
        ListItem = dal.OrderItem.GetAll().ToList();
        for (int i = 0; i < ListItem.Count; i++)
        {
            if (ListItem[i].ProductID==id)
            {
                throw new Exception("error cant delete because the product is usd ");
            }
        }
        try
        {
            dal.Product.Delete(id);
        }
        catch (Exception masg)
        {

            throw masg;
        }
    }

    public void ProductUpdate(DO.Product product)
    {
        if (product.ID <= 0)
        {
            throw new Exception("ERROR: ID WAS -");
        }

        if (product.Name == null)
        {
            throw new Exception("the name empty");
        }

        if (product.Price <= 0)
        {
            throw new Exception("ERROR: price WAS -");
        }

        if (product.InStock <= 0)
        {
            throw new Exception("ERROR in stock WAS -");
        }

        try
        {
            dal.Product.Update(product);

        }
        catch (Exception mas)
        {
            throw mas;
        }
    }

}

