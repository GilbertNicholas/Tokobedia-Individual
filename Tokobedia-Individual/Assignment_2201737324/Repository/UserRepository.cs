using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2201737324.Model;
using Assignment_2201737324.Factory;

namespace Assignment_2201737324.Repository
{
    public class UserRepository
    {
        static TokobediaModelContainer db = new TokobediaModelContainer();

        public static void insertUser(string email, string name, string password, string gender)
        {
            User users = UserFront.createUser(email, name, password, gender);
            db.Users.Add(users);
            db.SaveChanges();
        }

        public static void updateUserPassword(string email, string newPassword)
        {
            User users = db.Users.Where(a => a.Email == email).FirstOrDefault();
            users.Password = newPassword;
            db.SaveChanges();
        }

        public static void updateUserInfo(string email, string name, string gender, int id)
        {
            User users = db.Users.Where(a => a.Id == id).FirstOrDefault();
            users.Email = email;
            users.Name = name;
            users.Gender = gender;
            db.SaveChanges();
        }

        public static void changeRole(int id, int role)
        {
            User users = db.Users.Where(a => a.Id == id).FirstOrDefault();
            users.RoleId = role;
            db.SaveChanges();
        }

        public static void changeStatus(int id, int status)
        {
            User users = db.Users.Where(a => a.Id == id).FirstOrDefault();
            users.Status = status;
            db.SaveChanges();
        }

        public static List<User> getUser()
        {
            return db.Users.ToList();
        }
    }
}