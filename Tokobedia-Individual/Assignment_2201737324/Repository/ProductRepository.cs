using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2201737324.Factory;
using Assignment_2201737324.Model;

namespace Assignment_2201737324.Repository
{
    public class ProductRepository
    {
        static TokobediaModelContainer db = new TokobediaModelContainer();

        public static void insertProduct(string name, int price, int stock, int typeId)
        {
            Product products = ProductFront.createProduct(name, price, stock, typeId);
            db.Products.Add(products);
            db.SaveChanges();
        }

        public static void updateProductInfo(int id, string name, int price, int stock, int typeId)
        {
            Product products = db.Products.Where(a => a.Id == id).FirstOrDefault();
            products.Name = name;
            products.Price = price;
            products.Stock = stock;
            products.ProductTypeID = typeId;
            db.SaveChanges();
        }

        public static void deleteProduct(int id)
        {
            Product products = db.Products.Where(a => a.Id == id).FirstOrDefault();
            db.Products.Remove(products);
            db.SaveChanges();
        }

        public static List<Product> getProducts()
        {
            return db.Products.ToList();
        }
    }
}