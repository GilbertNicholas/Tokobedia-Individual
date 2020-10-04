using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2201737324.Model;

namespace Assignment_2201737324.Factory
{
    public class ProductFront
    {
        public static Product createProduct(string name, int price, int stock, int typeId)
        {
            Product item = new Product();
            item.Name = name;
            item.Price = price;
            item.Stock = stock;
            item.ProductTypeID = typeId;

            return item;
        }
    }
}