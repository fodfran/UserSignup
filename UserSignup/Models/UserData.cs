using System;
using System.Collections.Generic;
using System.Linq;

namespace UserSignup.Models
{
    public class UserData
    {
        static private List<User> users = new List<User>();

        public static List<User> GetAll()
        {
            return users;
        }

        public static void AddUser(User newUser)
        {
            users.Add(newUser);
        }

        public static User GetByID(int id)
        {
            return users.Single(x => x.UserId == id);
        }
    }
}
