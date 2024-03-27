using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Repository;

namespace VirtualArtGallery.Exceptions
{
    internal class UserNotFoundException :Exception
    {
        public UserNotFoundException(string message) : base(message)
        {

        }

        public static void UserNotFound(int userid)
        {
            UserFavouriteRepository repository = new UserFavouriteRepository();
            if (!repository.UserExists(userid))
            {
                throw new UserNotFoundException("UserID not found. Please try again!");
            }
        }
    }
}
