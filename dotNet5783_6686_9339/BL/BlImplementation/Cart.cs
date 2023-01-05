using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;
using DalApi;
using static System.Net.Mime.MediaTypeNames;

namespace BlImplementation;
internal class Cart : ICart
{
    //private DalApi.IDal dal = new Dal.DalList(); 
    DalApi.IDal? dal = DalApi.Factory.Get();

    public BO.Cart AddItemToCART(BO.Cart item, int id)
    {
        //DO.Product? product = dal.Product.GetAll().ToList().Find(itemm => (int)itemm?.ID! == id);//מחזיר לי את המוצר אם אותו איי די
        //DO.Product? product = dal.Product.GetObj(id);
        DO.Product? product = dal.Product.GetSingle(itemm => (int)itemm?.ID! == id);

        int i = item.orderItemsList.FindIndex(itemm => itemm.ProductId == id);

        bool exists = item.orderItemsList.Exists(itemm => itemm.ProductId == id);
        if (exists)
        {
            if ((int)product?.InStock! != 0)
            {
                item.orderItemsList[i].InOrder++;
                item.orderItemsList[i].SumPrice += (double)product?.Price!;
                item.TotalPrice += (double)product?.Price!;
            }
            else
            {
                throw new BO.BlDoesNotExistException("error");
            }
        }
        else
        {
            bool exist = dal.Product.GetAll().ToList().Exists(itemm => (int)itemm?.ID! == id);
            if (exist && (int)product?.InStock! != 0)
            {
                BO.OrderItem orderItem = new BO.OrderItem()
                {
                    Id = (int)product?.ID!,
                    ProductId = id,
                    ProductName = (string)product?.Name!,
                    ProductPrice = (double)product?.Price!,
                    InOrder = 1,
                    SumPrice = (double)product?.Price!,
                };
                item.orderItemsList.Add(orderItem);
                item.TotalPrice += (double)product?.Price!;
            }
            else
            {
                throw new BO.BlDoesNotExistException("error");
            }
        }
        return item;
    }
    public BO.Cart UpdateAmountOfProduct(BO.Cart item, int id, int newAmount) 
    {
        DO.Product? product = dal.Product.GetAll().ToList().Find(itemm => (int)itemm?.ID! == id);//מחזיר לי את המוצר אם אותו איי די
        int index = item.orderItemsList.FindIndex(itemm => itemm.ProductId == id);

        if (index == -1) // שאז זה אומר שלא היה מוצר כזה מלכתחילה 
        {
            for (int i = 0; i < newAmount; i++)
            {
                AddItemToCART(item, id);
            }
            return item;
        }

        int diffrence = newAmount - item.orderItemsList[index].InOrder;

        if (newAmount == 0)
        {
            item.orderItemsList.RemoveAt(index);
            item.TotalPrice -= (double)product?.Price! * (-1 * diffrence);
        }

        if (diffrence < 0)
        {
            item.orderItemsList[index].InOrder = newAmount;
            item.orderItemsList[index].SumPrice = (double)product?.Price! * newAmount;
            item.TotalPrice -= (double)product?.Price! * (-1*diffrence);
        }

        if (diffrence > 0)
        {
            for (int i = 0; i < diffrence; i++)
            {
                AddItemToCART(item, id);
            }
        }

            return item;
    }
    public void ConfirmationOfOrder(BO.Cart CostumerInfo)
    {
        for (int i = 0; i < CostumerInfo.orderItemsList.Count; i++)
        {
            int intProduct = CostumerInfo.orderItemsList[i].ProductId;
            DO.Product? product = dal.Product.GetAll().ToList().Find(itemm => (int)itemm?.ID! == intProduct);//מחזיר לי את המוצר אם אותו איי די
            int sumOrder = CostumerInfo.orderItemsList[i].InOrder;
            if (sumOrder >= (int)product?.InStock! || sumOrder <= 0)
            {
                throw new BO.BlNotEnoughInStock("error");
            }
        }

        if (CostumerInfo.CostumerName == null)  
        {
            throw new BO.BlNameWasNull("error");
        }

        if (CostumerInfo.CostumerAdress == null)
        {
            throw new BO.BlAdressWasNull("error");

        }

        if (CostumerInfo.CostumerEmail != null && !CostumerInfo.CostumerEmail.Contains("@gmail.com"))
        {
            throw new BlRongEmail("ERROR: rong email");
        }

        DO.Order NewOrder = new DO.Order()
        {
            CostumerName = CostumerInfo.CostumerName,
            CostumerEmail = CostumerInfo.CostumerEmail,
            CostumerAdress = CostumerInfo.CostumerAdress,
            OrderDate = DateTime.Now,
        };

        int NumOreder = dal.Order.Add(NewOrder);

        for (int i = 0; i < CostumerInfo.orderItemsList.Count; i++)
        {
            int intProduct = CostumerInfo.orderItemsList[i].ProductId;
            DO.Product? product = dal.Product.GetAll().ToList().Find(itemm => (int)itemm?.ID! == intProduct);//מחזיר לי את המוצר אם אותו איי די
            DO.OrderItem NewOrderItem = new DO.OrderItem()
            {
                ProductID = (int)product?.ID!,
                OrderID = NumOreder,
                Price = (double)product?.Price!,
                Amount = CostumerInfo.orderItemsList[i]!.InOrder,
            };

            dal.OrderItem.Add(NewOrderItem);
        }

        for (int i = 0; i < CostumerInfo.orderItemsList.Count; i++)
        {
            int intProduct = CostumerInfo.orderItemsList[i]!.ProductId;
            DO.Product product = (DO.Product)dal.Product.GetAll().ToList().Find(itemm => (int)itemm?.ID! == intProduct)!;//מחזיר לי את המוצר אם אותו איי די
            product.InStock -= (int)CostumerInfo?.orderItemsList[i]?.InOrder!;
            dal.Product.Update((DO.Product)product!);
        }
            return; 
    }

}

