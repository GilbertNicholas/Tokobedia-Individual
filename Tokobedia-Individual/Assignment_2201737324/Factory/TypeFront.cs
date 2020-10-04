using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2201737324.Model;

namespace Assignment_2201737324.Factory
{
    public class TypeFront
    {
        public static ProductType createType(string name, string desc)
        {
            ProductType type = new ProductType();
            type.Name = name;
            type.Description = desc;

            return type;
        }
    }
}