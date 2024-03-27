using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Repository;

namespace VirtualArtGallery.Exceptions
{
    internal class ArtworkNotFoundException : Exception
    {
        public ArtworkNotFoundException(string message) : base(message) { }


        public static void ArtworkNotFound(int artworkID)
        {
            ArtworkRepository artworkRepository = new ArtworkRepository();
            if (!artworkRepository.ArtworkExists(artworkID))
            {

                throw new ArtworkNotFoundException("Artwork ID not found. Try Again!");
            }

        }
    }
}
