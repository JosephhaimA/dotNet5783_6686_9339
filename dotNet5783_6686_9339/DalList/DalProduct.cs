
using DO;
using System.ComponentModel.Design;

namespace Dal;

public class DalProduct
{
    public int ProductAdd(Product p) // function add a product
    {
        //int index = ProductFind(p.ID);
        //if (index == -999)
        //{
            int i = DataSource.Config.IndexProduct;
            if (i < 50)
            {
                DataSource.ProductList[i] = p;
                //DataSource.ProductList[i].ID = p.ID;
                //DataSource.ProductList[i].Name = p.Name; 
                //DataSource.ProductList[i].Price = p.Price;
                //DataSource.ProductList[i].Cat = p.Cat;
                //DataSource.ProductList[i].InStock = p.InStock;
                DataSource.Config.IndexProduct++;
            return DataSource.ProductList[i].ID;
            }
            else
                throw new Exception("No such place to add a Product you have to remove one");
        //}
       // else
          //  throw new Exception("Product doesn't exist");
    }

    public Product ShowProduct(int id) // function to return one product
    {
        int index = ProductFind(id);
        if (index != -999)
            return DataSource.ProductList[index]; // return the product 
        else
            throw new Exception("Product doesn't exist");
    }
    public void ShowAllProduct() // print all the products
    {
        int i = 0;
        foreach (Product element in DataSource.ProductList)
        {
            if (element.ID != 0)
                Console.WriteLine(element);
        }
    }
    public void ProductsUpdate(Product p) // updating the product if exist, the price, the stock of the prudcut,....
    {
        int index = ProductFind(p.ID);
        if (index != -999)
        {
            DataSource.ProductList[index].ID = p.ID;
            DataSource.ProductList[index].Name = p.Name;
            DataSource.ProductList[index].Price = p.Price;
            DataSource.ProductList[index].Cat = p.Cat;
            DataSource.ProductList[index].InStock = p.InStock;
        }
        else
            throw new Exception("Product does not exist");
    }

    public void ProductsDelete(int id)
    {
        int index = ProductFind(id);
        if (index != -999) // if the id don't exist we cannot delete any product
        {
            for (int i = index; i < DataSource.ProductList.Length - 1; i++)
            {
                DataSource.ProductList[i] = DataSource.ProductList[1 + i];// jump the product at the arra[index] and copy the rest
                if (i + 1 == DataSource.ProductList.Length)
                    break;
            }
            DataSource.ProductList.SkipLast(1).ToArray();// delete the last product beacause we copied at the last place
        }
        else
            throw new Exception("Product does not exist");
    }

    // find function that help us with the main function like add, delete..... to check the exist
    public int ProductFind(int id)
    {
        for (int i = 0; i < DataSource.ProductList.Length; i++)
        {
            if (id == DataSource.ProductList[i].ID)
                return i;
        }
        return -999;
    }
}