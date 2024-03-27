using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Exceptions;
using VirtualArtGallery.Model;
using VirtualArtGallery.Repository;

namespace VirtualArtGallery.Service
{
    internal class ArtworkService
    {
        private readonly ArtworkRepository _repository;

        public ArtworkService()
        {
            _repository = new ArtworkRepository();
        }

        public void InsertRecordstoArtwork(Artwork artwork)
        {
            _repository.addArtwork(artwork);
        }

        public void RemoveRecordsfromArtwork(int artworkID)
        {

            _repository.removeArtwork(artworkID);

        }

        public void UpdateRecordsinArtwork(Artwork artwork)
        {
            _repository.updateArtwork(artwork);
        }

        public void GetArtwork(int artworkID)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkID);
                _repository.getArtworkById(artworkID);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public void SearchArtwork()
        {
            _repository.searchArtworks();
        }
    }
}
