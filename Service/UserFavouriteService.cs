using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Exceptions;
using VirtualArtGallery.Repository;

namespace VirtualArtGallery.Service
{
    internal class UserFavouriteService
    {
        private readonly UserFavouriteRepository _urepository;

        public UserFavouriteService()
        {
            _urepository = new UserFavouriteRepository();
        }

        public void InsertArtowrktoFavourites(int userID, int artworkID)
        {
            _urepository.addArtworkToFavorite(userID, artworkID);
        }

        public void RemoveArtwork(int userID, int artworkID)
        {
            try
            {
                UserNotFoundException.UserNotFound(userID);
                _urepository.removeArtworkFromFavorite(userID, artworkID);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void GetArtwork(int userID)
        {
            try
            {
                UserNotFoundException.UserNotFound(userID);
                _urepository.getUserFavouriteArtworks(userID);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
