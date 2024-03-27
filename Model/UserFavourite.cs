using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class UserFavourite
    {
        int userID;
        int artworkID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int ArtworkID
        {
            get { return artworkID; }
            set { artworkID = value; }
        }

        public UserFavourite(int userID, int artworkID)
        {
            UserID = userID;
            ArtworkID = artworkID;
        }

        public UserFavourite() { }

        public override string ToString()
        {
            return $"{userID} {artworkID}";
        }
    }
}
