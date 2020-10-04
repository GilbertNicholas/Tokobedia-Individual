using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2201737324.Model;

namespace Assignment_2201737324.Factory
{
    public class UserFront
    {
        public static User createUser(string email, string name, string password, string gender)
        {
            User user = new User();
            user.Email = email;
            user.Name = name;
            user.Password = password;
            user.Gender = gender;
            user.Status = 1;
            user.RoleId = 2;

            return user;
        }
    }
}