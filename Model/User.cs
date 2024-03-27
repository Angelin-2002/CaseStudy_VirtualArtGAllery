using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class User
    {
        public int userID;
        public string userName;
        String password;
        String email;
        String firstname;
        public String lastname;
        DateTime dateofbirth;
        String profilepicture;
        int? favouriteart;

        public User() { }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public DateTime Dateofbirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }
        public String ProfilePicture
        {
            get { return profilepicture; }
            set { profilepicture = value; }
        }
        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public int? FavouriteArt
        {
            get { return favouriteart; }
            set { favouriteart = value; }
        }

        public User(int userID, string userName, string password, string email, string firstname, string lastname, DateTime dateofbirth, string profilePicture, int? favouriteart, int? favouriteArt)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Dateofbirth = dateofbirth;
            ProfilePicture = profilePicture;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            FavouriteArt = favouriteArt;
        }
        public override string ToString()
        {
            return $"{UserID}:{UserName}:{Password}:{Email}, {Firstname} {Lastname} {ProfilePicture} {FavouriteArt}";
        }
    }
}
