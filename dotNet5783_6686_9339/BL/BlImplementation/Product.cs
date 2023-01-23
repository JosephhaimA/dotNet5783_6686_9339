using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;
using DO;
//using Dal;
using static BO.Enum;
using static DO.Enums;
// we implement the functions thay we've created

namespace BlImplementation;
sealed public class Product : IProduct
{
    // private DalApi.IDal dal = new Dal.DalList();
    DalApi.IDal? dal = DalApi.Factory.Get();


    public IEnumerable<BO.ProductForList?> ListProduct(Func<DO.Product?, bool>? func)
    {
        List<DO.Product?> L_P = dal!.Product.GetAll()!.ToList();
        List<BO.ProductForList> productForLists = new List<BO.ProductForList>();
        if (func == null)
        {
            productForLists.AddRange(from DO.Product? product in L_P
                                     let PFR = new BO.ProductForList()
                                     {
                                         ProductId = (int)product?.ID!,
                                         ProductName = (string)product?.Name!,
                                         ProductPrice = (double)product?.Price!,
                                         Category = (BO.Enum.ProductCategory?)product?.Category!,
                                     }
                                     select PFR);
        }
        else
        {
            productForLists.AddRange(from DO.Product? product in L_P
                                     where func(product)

                                     let PFR = new BO.ProductForList()
                                     {
                                         ProductId = (int)product?.ID!,
                                         ProductName = (string)product?.Name!,
                                         ProductPrice = (double)product?.Price!,
                                         Category = (BO.Enum.ProductCategory?)product?.Category!,
                                     }
                                     select PFR);
        }
        return productForLists;
    }

    // for the admin access
    public BO.Product GetProductAdmin(int id)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            product = dal!.Product.GetObj(id);
            int cat = (int)product.Category!;
            BO.Product NewProduct = new BO.Product()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.Enum.ProductCategory)cat,
                InStock = (int)product.InStock!,
            };
            return NewProduct;
        }
        else
        {
            throw new BO.BlIdNegative("ERROR the id was - ");
        }
    }

    public BO.ProductItem GetProductAdminCostumer(int id, BO.Cart cart)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            int cat = (int)product.Category!;
            product = dal!.Product.GetObj(id);
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
                Amount = (int)product.InStock!,
            };
            return productItem;
        }
        else
        {
            throw new BO.BlIdNegative("ERROR the id was - ");
        }
    }

    public void ProductAdd(BO.Product product)
    {
        if (product.Id <= 0)
        {
            throw new BO.BlIdNegative("ERROR: ID WAS -");
        }

        if (product.Name == null)
        {
            throw new BO.BlNameWasNull("Error: the name empty");
        }

        if (product.Price <= 0)
        {
            throw new BO.BlInPriceNegative("ERROR: price WAS -");
        }

        if (product.InStock <= 0)
        {
            throw new BO.BlInStockIsNegative("Error: in stock was negativ");
        }

        DO.Product product1 = new DO.Product()
        {
            ID = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = (DO.Enums.ProductCategory)product.Category!,
            InStock = product.InStock
        };
        try
        {
            dal!.Product.Add(product1);

        }
        catch (Exception mas)
        {
            throw new BO.BlAlreadyExistException("invalid product operation", mas);
        }
    }

    public void ProductDelete(int id)
    {
        List<DO.OrderItem?> ListItem = new List<DO.OrderItem?>();
        ListItem = dal!.OrderItem.GetAll()!.ToList();
        //foreach (DO.OrderItem? product in ListItem)//אין צורך לעבור ללינק כי זה עובר על הכל כדאי לבןד אם קיים כזה איי דיי
        //{
        //    if ((int?)product?.ProductID==id)
        //    {
        //        throw new BO.BlCantDeleteB_Used("error cant delete because the product is usd ");
        //    }
        //}

        foreach (var a in from DO.OrderItem? product in ListItem//אין צורך לעבור ללינק כי זה עובר על הכל כדאי לבןד אם קיים כזה איי דיי
                          where (int?)product?.ProductID == id
                          select new { })
        {
            throw new BO.BlCantDeleteB_Used("error cant delete because the product is usd ");
        }

        try
        {
            dal.Product.Delete(id);
        }
        catch (Exception masg)
        {

            throw new BO.BlDoesNotExistException("ERROR: not exist " + masg);
        }
    }

    public void ProductUpdate(BO.Product product)
    {
        if (product.Id <= 0)
        {
            throw new BO.BlIdNegative("ERROR: ID WAS -");
        }

        if (product.Name == null)
        {
            throw new BO.BlNameWasNull("the name empty");
        }

        if (product.Price <= 0)
        {
            throw new BO.BlInPriceNegative("ERROR: price WAS -");
        }

        if (product.InStock <= 0)
        {
            throw new BO.BlInStockIsNegative("ERROR in stock WAS -");
        }
        DO.Product product1 = new DO.Product();
        product1.Name = product.Name;
        product1.Price = product.Price;
        product1.InStock = product.InStock;
        product1.ID = product.Id;
        product1.Category = (Enums.ProductCategory)product.Category!;

        try
        {
            dal?.Product.Update(product1);

        }
        catch (Exception mas)
        {
            throw new BO.BlDoesNotExistException("Error: not exist " + mas);
        }
    }

    public IEnumerable<ProductItem?> GetProductItem(Func<DO.Product?, bool>? func = null)
    {
        List<DO.Product?> products;
        products = dal!.Product.GetAll()!.ToList();
        if (func != null)
        {
            List<BO.ProductItem> productsItem = (List<BO.ProductItem>)products
                  .Where(product => func(product))
                  .Select(product => new BO.ProductItem
                  {
                      ProductId = (int)product?.ID!,
                      Category = (BO.Enum.ProductCategory)product?.Category!,
                      ProductName = product?.Name,
                      ProductPrice = (int)product?.Price!,
                      InStock = product?.InStock > 0 ? true : false,
                      Amount = (int)product?.InStock!,

                  }).ToList();



            return productsItem;
        }
        else
        {
            List<BO.ProductItem> productsItem = (List<BO.ProductItem>)products
                .Select(product => new BO.ProductItem
                {
                    ProductId = (int)product?.ID!,
                    Category = (BO.Enum.ProductCategory)product?.Category!,
                    ProductName = product?.Name,
                    ProductPrice = (int)product?.Price!,
                    InStock = product?.InStock > 0 ? true : false,
                    Amount = (int)product?.InStock!,
                }).ToList();

            return productsItem;
        }
    }
}

