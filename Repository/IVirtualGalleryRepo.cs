using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Model;

namespace VirtualArtGallery.Repository
{
    internal interface IVirtualGalleryRepo
    {
        bool addArtwork(Artwork artwork);
        bool updateArtwork(Artwork artwork);
        bool removeArtwork(int artworkId);
        void getArtworkById(int artworkId);
        void searchArtworks();

        bool addArtworkToFavorite(int userId, int artworkId);
        bool removeArtworkFromFavorite(int userId, int artworkId);
        bool getUserFavoriteArtworks(int userId);
    }
}
