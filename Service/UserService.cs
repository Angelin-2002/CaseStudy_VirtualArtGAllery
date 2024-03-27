using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Model;

namespace VirtualArtGallery.Service
{
    internal class UserService
    {
        public List<User> usersList = new List<User>();


        public void Register(User user)
        {
            if (!UserExists(user.UserName))
            {
                usersList.Add(user);
            }
            else
            {
                Console.WriteLine("UserName already exists! Try Again !");
            }
        }

        public bool Login(string username, string password)
        {
            User user = FindUserByUsername(username);
            if (user != null && user.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UserExists(string username)
        {
            foreach (User user in usersList)
            {
                if (user.UserName.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        public User FindUserByUsername(string username)
        {
            foreach (User user in usersList)
            {
                if (user.UserName.Equals(username))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
