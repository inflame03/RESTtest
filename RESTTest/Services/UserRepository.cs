using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Common.Models;
using Common.Logic;

namespace RESTTest.Services
{
    public class UserRepository
    {
        //private const string CacheKey = "UserStore";

        public UserRepository() {  }

        public User[] GetAllUsers()
        {
            UserLogic ul = new UserLogic();

            return ul.GetUserList();

        }

        public User GetUser(int ID)
        {
            UserLogic ul = new UserLogic();

            return ul.GetUser(ID);
        }

        public User SaveUser(User userInfo)
        {
            UserLogic ul = new UserLogic();

            return ul.SaveUser(userInfo);

        }

        public bool DeleteUser( int userID )
        {
            UserLogic ul = new UserLogic();

            return ul.DeleteUser(userID);

        }

    }
}