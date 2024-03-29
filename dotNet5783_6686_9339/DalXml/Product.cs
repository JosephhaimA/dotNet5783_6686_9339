﻿
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal;

internal class DalProduct : IProduct
{
    string productPath = @"Product";
    static XElement config = XmlTools.LoadConfig();
    static DO.Product? createProductfromXElement(XElement s)
    {
        return new DO.Product
        {
            ID = s.ToIntNullable("ID") ?? throw new FormatException("ID"),
            Name = (string?)s.Element("Name")!.Value,
            Category = s.ToEnumNullable<DO.Enums.ProductCategory>("Category"),
            Price = (double)s.Element("Price")!,
            InStock = (int)s.Element("InStock")!
        };
    }

    /// <summary>
    /// The operation accepts a product and adds it in the list
    /// </summary>
    /// <returns> returns order id </returns>
    public int Add(Product product)
    {
        Random rnd = new Random();
        XElement product_root = XmlTools.LoadListFromXMLElement(productPath);
        if (product.ID == 0)
        {
            product.ID = rnd.Next(100000, 999999);
            XmlTools.SaveConfigXElement("ID", product.ID);
        }
        XElement? prod = (from st in product_root.Elements()
                          where st.ToIntNullable("ID") == product.ID
                          select st).FirstOrDefault();
        if (prod != null)
            throw new Exception("ID already exist");
        product_root.Add(new XElement("Product",
                                   new XElement("ID", product.Name),
                                   new XElement("Name", product.Name),
                                   new XElement("Category", product.Category),
                                   new XElement("Price", product.Price),
                                   new XElement("InStock", product.InStock)
                                   ));
        XmlTools.SaveListToXMLElement(product_root, productPath);
        return product.ID;
    }

    /// <summary>
    ///  The operation deletes a product from the array (finds him by id)
    /// </summary>
    public void Delete(int prodId)
    {
        XElement product_root = XmlTools.LoadListFromXMLElement(productPath);

        XElement? prod = (from st in product_root.Elements()
                          where (int?)st.Element("ID") == prodId
                          select st).FirstOrDefault() ?? throw new Exception("Missing ID");
        prod.Remove();  //<==> Remove stud from studentsRootElem

        XmlTools.SaveListToXMLElement(product_root, productPath);

    }


    ///     /// <summary>
    /// The operation returns the list of products
    /// </summary>
    public IEnumerable<Product?> GetAll(Func<Product?, bool>? func = null)
    {
        XElement? product_root = XmlTools.LoadListFromXMLElement(productPath);
        if (func != null)
        {
            return from s in product_root.Elements()
                   let prod = createProductfromXElement(s)
                   where func(prod)
                   select prod;
        }
        else
        {
            return from s in product_root.Elements()
                   select createProductfromXElement(s);
        }
    }

    /// <summary>
    ///  The operation finds the product and returns him
    /// </summary>
    public Product GetSingle(Func<Product?, bool>? func)
    {
        if (func == null)
            throw new Exception("missing function");

        XElement product_root = XmlTools.LoadListFromXMLElement(productPath);
        return ((from p in product_root.Elements()
                 where func(p.ConvertProduct_Xml_to_D0())
                 select p.ConvertProduct_Xml_to_D0()).FirstOrDefault());
    }

    /// <summary>
    ///  The operation finds the product (by id) and returns him
    /// </summary>
    public Product GetObj(int productId)
    {
        List<DO.Product?> ListProduct = XmlTools.LoadListFromXMLSerializer<DO.Product>(productPath);

        var product = ListProduct.FirstOrDefault(x => x?.ID == productId);

        if (product == null)
            throw new DO.DalDoesNotExistException("Product Id not found");
        else
            return (DO.Product)product;
    }

    /// <summary>
    /// returns list length
    /// </summary>
    public int ListLength()
    {
        List<DO.Product?> ListProduct = XmlTools.LoadListFromXMLSerializer<DO.Product>(productPath);
        return ListProduct.Count;
    }

    /// <summary>
    /// The operation updates an product in the array (finds him by id)
    /// </summary>
    public void Update(Product product)
    {
        List<DO.Product?> ListProduct = XmlTools.LoadListFromXMLSerializer<DO.Product>(productPath);

        bool found = false;
        var foundProduct = ListProduct.FirstOrDefault(prod => prod?.ID == product.ID);
        if (foundProduct != null)
        {
            found = true;
            int index = ListProduct.IndexOf(foundProduct);
            ListProduct[index] = product;
        }
        if (found == false)
            throw new DO.DalDoesNotExistException("order item id not found");
        XmlTools.SaveListToXMLSerializer(ListProduct, productPath);
    }
}

