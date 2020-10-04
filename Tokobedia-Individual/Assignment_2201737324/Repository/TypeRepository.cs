using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2201737324.Factory;
using Assignment_2201737324.Model;

namespace Assignment_2201737324.Repository
{
    public class TypeRepository
    {
        static TokobediaModelContainer db = new TokobediaModelContainer();

        public static void insertType(string name, string desc)
        {
            ProductType types = TypeFront.createType(name, desc);
            db.ProductTypes.Add(types);
            db.SaveChanges();
        }

        public static void updateType(int id, string name, string desc)
        {
            ProductType types = db.ProductTypes.Where(a => a.Id == id).FirstOrDefault();
            types.Name = name;
            types.Description = desc;
            db.SaveChanges();
        }

        public static void deleteProduct(int id)
        {
            ProductType types = db.ProductTypes.Where(a => a.Id == id).FirstOrDefault();
            db.ProductTypes.Remove(types);
            db.SaveChanges();
        }

        public static List<ProductType> getTypes()
        {
            return db.ProductTypes.ToList();
        }
    }
}