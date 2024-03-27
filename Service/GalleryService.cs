using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Model;
using VirtualArtGallery.Repository;

namespace VirtualArtGallery.Service
{
    internal class GalleryService
    {
        private readonly GalleryRepository repository;

        public GalleryService()
        {
            repository = new GalleryRepository();
        }

        public void InsertRecordstoGallery(Gallery gallery)
        {
            repository.addGallery(gallery);
        }

        public void UpdateRecordsInGallery(Gallery gallery)
        {
            repository.UpdateGallery(gallery);
        }

        public void RemovefromGallery(int galleryID)
        {
            repository.removeGallery(galleryID);
        }

        public void SearchGallery()
        {
            repository.searchGallery();
        }
    }
}
