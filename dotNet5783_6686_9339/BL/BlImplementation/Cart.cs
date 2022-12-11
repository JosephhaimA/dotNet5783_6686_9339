using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using DalApi;

using static System.Net.Mime.MediaTypeNames;

namespace BlImplementation;
internal class Cart : ICart
{
    private DalApi.IDal dal = new Dal.DalList(); 

    public BO.Cart AddItemToCART(BO.Cart item, int id)
    {
        DO.Product product = dal.Product.GetAll().ToList().Find(itemm => itemm.ID == id);//מחזיר לי את המוצר אם אותו איי די

        int i = item.orderItemsList.FindIndex(itemm => itemm.ProductId == id);

        bool exists = item.orderItemsList.Exists(itemm => itemm.ProductId == id);
        if (exists)
        {
            if (product.InStock != 0)
            {
                item.orderItemsList[i].InOrder++;
                item.orderItemsList[i].SumPrice += product.Price;
                item.TotalPrice += product.Price;
            }
            else
            {
                throw new BO.BlDoesNotExistException("error");
            }
        }
        else
        {
            bool exist = dal.Product.GetAll().ToList().Exists(itemm => itemm.ID == id);
            if (exist && product.InStock != 0)
            {
                BO.OrderItem orderItem = new BO.OrderItem()
                {
                    Id = product.ID,
                    ProductId = id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    InOrder = 1,
                    SumPrice = product.Price,
                };
                item.orderItemsList.Add(orderItem);
                item.TotalPrice += product.Price;
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
        DO.Product product = dal.Product.GetAll().ToList().Find(itemm => itemm.ID == id);//מחזיר לי את המוצר אם אותו איי די
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
            item.TotalPrice -= product.Price * (-1 * diffrence);
        }

        if (diffrence < 0)
        {
            item.orderItemsList[index].InOrder = newAmount;
            item.orderItemsList[index].SumPrice = product.Price* newAmount;
            item.TotalPrice -= product.Price*(-1*diffrence);
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
            DO.Product product = dal.Product.GetAll().ToList().Find(itemm => itemm.ID == intProduct);//מחזיר לי את המוצר אם אותו איי די
            int sumOrder = CostumerInfo.orderItemsList[i].InOrder;
            if (sumOrder >= product.InStock || sumOrder <= 0)
            {
                throw new Exception("error");
            }
        }

        if (CostumerInfo.CostumerName == null || CostumerInfo.CostumerAdress == null)
        {
            throw new Exception("error");
        }

        if (CostumerInfo.CostumerEmail != null && !CostumerInfo.CostumerEmail.Contains("@gmail.com")   )
        {
            throw new Exception("error");

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
            DO.Product product = dal.Product.GetAll().ToList().Find(itemm => itemm.ID == intProduct);//מחזיר לי את המוצר אם אותו איי די
            DO.OrderItem NewOrderItem = new DO.OrderItem()
            {
                ProductID = product.ID,
                OrderID = NumOreder,
                Price = product.Price,
                Amount = CostumerInfo.orderItemsList[i].InOrder,
            };

            dal.OrderItem.Add(NewOrderItem);
        }

        for (int i = 0; i < CostumerInfo.orderItemsList.Count; i++)
        {
            int intProduct = CostumerInfo.orderItemsList[i].ProductId;
            DO.Product product = dal.Product.GetAll().ToList().Find(itemm => itemm.ID == intProduct);//מחזיר לי את המוצר אם אותו איי די
            product.InStock -= CostumerInfo.orderItemsList[i].InOrder;
            dal.Product.Update(product);
        }
            return; 
    }

}

