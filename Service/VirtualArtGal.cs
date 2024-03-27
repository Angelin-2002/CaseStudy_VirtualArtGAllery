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
    internal class VirtualArtGal
    {
        private readonly ArtworkRepository _repository;
        private readonly UserFavouriteRepository _userFavouriteRepository;


        public VirtualArtGal()
        {
            _repository = new ArtworkRepository();
            _userFavouriteRepository = new UserFavouriteRepository();
        }

        public void addRecord(Artwork artwork)
        {
            if (_repository.addArtwork(artwork))
            {
                Console.WriteLine("Artwork Added successfully");
            }
            else
            {
                Console.WriteLine("Artwork not Added successfully");
            }
        }

        public void UpdateArtworks(Artwork artwork)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artwork.ArtworkID);
                if (_repository.updateArtwork(artwork))
                    Console.WriteLine("Artwork updated successfully");
                else
                    Console.WriteLine("Artwork not updated successfully. Try again!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveArtworks(int artworkId)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkId);
                if (_repository.removeArtwork(artworkId))
                    Console.WriteLine("Artwork removed successfully");
                else
                    Console.WriteLine("Artwork not removed successfully.Try again!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getArtworks(int artworkID)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkID);
                _repository.getArtworkById(artworkID);
                Console.WriteLine("Artwork found successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void searchArtwork()
        {
            foreach (Artwork item in _repository.searchArtworks())
                Console.WriteLine(item);
        }

        public void addFavorite(int user_id, int art_id)
        {
            try
            {
                UserNotFoundException.UserNotFound(user_id);
                ArtworkNotFoundException.ArtworkNotFound(art_id);
                if (_userFavouriteRepository.addArtworkToFavorite(user_id, art_id))
                    Console.WriteLine("Favorite artwork added successfully");
                else
                    Console.WriteLine("Operation unsuccessful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeFavorite(int user_id, int art_id)
        {
            try
            {
                UserNotFoundException.UserNotFound(user_id);
                ArtworkNotFoundException.ArtworkNotFound(art_id);
                if (_userFavouriteRepository.removeArtworkFromFavorite(user_id, art_id))
                    Console.WriteLine("Favorite artwork removed unsuccessfully");
                else
                    Console.WriteLine("Operation unsuccessful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getUserFavourite(int userId)
        {
            try
            {
                UserNotFoundException.UserNotFound(userId);
                Console.WriteLine(_userFavouriteRepository.getUserFavouriteArtworks(userId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MainMenu()
        {

            int choice = 0, choice1 = 0, choice2 = 0, choice3 = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1: Artwork Management\n2: User Favorite Management\n3: Gallery Management\n4: Exit");
                Console.WriteLine("What would you like to do: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Artwork Management");
                            Console.WriteLine("1. Add Artwork\n2. Update Artwork\n3. Remove Artwork\n4.Get Artwork\n5.Search Artwork\n6. Exit\n");
                            Console.WriteLine("What would you like to do: ");
                            choice1 = int.Parse(Console.ReadLine());
                            Artwork artwork;
                            switch (choice1)
                            {
                                case 1:
                                    Console.WriteLine("Enter the title: ");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter the description: ");
                                    string desc = Console.ReadLine();
                                    Console.WriteLine("Enter the creation date: ");
                                    string cdate = Console.ReadLine();
                                    Console.WriteLine("Enter the medium: ");
                                    string medium = Console.ReadLine();
                                    Console.WriteLine("Enter the image url: ");
                                    string imurl = Console.ReadLine();
                                    Console.WriteLine("Enter the artist id: ");
                                    int artistID = int.Parse(Console.ReadLine());
                                    artwork = new Artwork() { Title = title, Description = desc, CreationDate = DateTime.Parse(cdate), Medium = medium, ImageURL = imurl, ArtistID = artistID };
                                    addRecord(artwork);
                                    Console.WriteLine("Artwork added succesfully");
                                    break;

                                case 2:
                                    Console.WriteLine("Enter the artwork id: ");
                                    int artID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the title: ");
                                    string updt_title = Console.ReadLine();
                                    Console.WriteLine("Enter the description: ");
                                    string updt_desc = Console.ReadLine();
                                    Console.WriteLine("Enter the creation date: ");
                                    DateTime updt_date = DateTime.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the medium: ");
                                    string updt_medium = Console.ReadLine();
                                    Console.WriteLine("Enter the image url: ");
                                    string updt_url = Console.ReadLine();
                                    Console.WriteLine("Enter the artist id: ");
                                    int updt_artistId = int.Parse(Console.ReadLine());
                                    artwork = new Artwork(artID, updt_title, updt_desc, updt_date, updt_medium, updt_url, updt_artistId);
                                    UpdateArtworks(artwork);
                                    Console.WriteLine("Artwork Updated Successfully");
                                    break;

                                case 3:
                                    Console.WriteLine("Enter the artwork id: ");
                                    int art_id = int.Parse(Console.ReadLine());
                                    RemoveArtworks(art_id);
                                    Console.WriteLine("Artwork Removed Successfully");
                                    break;

                                case 4:
                                    Console.WriteLine("Enter the artwork id: ");
                                    int art1_id = int.Parse(Console.ReadLine());
                                    getArtworks(art1_id);
                                    break;

                                case 5:
                                    searchArtwork();
                                    break;

                                case 6:
                                    Console.WriteLine("Redirecting to Main menu!");
                                    break;

                                default:
                                    Console.WriteLine("Wrong choice!Please Try again!");
                                    break;
                            }
                        } while (choice1 != 6);
                        break;

                    case 2:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("User Favorite Management");
                            Console.WriteLine("1. Add Favorites\n2. Remove Favorites\n3. Get Favorites\n4. Exit\n");
                            Console.WriteLine("What would you like to do: ");
                            choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    Console.WriteLine("Enter the user id: ");
                                    int userID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the Artwork id: ");
                                    int artworkID = int.Parse(Console.ReadLine());
                                    addFavorite(userID, artworkID);
                                    Console.WriteLine("Favourite added successfully");
                                    break;

                                case 2:
                                    Console.WriteLine("Enter the user id: ");
                                    int user_id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the Artwork id: ");
                                    int artwork_id = int.Parse(Console.ReadLine());
                                    removeFavorite(user_id, artwork_id);
                                    Console.WriteLine("Favourite removed successfully");
                                    break;

                                case 3:
                                    Console.WriteLine("Enter the user id: ");
                                    int updt_id = int.Parse(Console.ReadLine());
                                    getUserFavourite(updt_id);
                                    break;

                                case 4:
                                    Console.WriteLine("Exiting from User Favourite Management");
                                    break;

                                default:
                                    Console.WriteLine("Wrong choice!Try again!");
                                    break;
                            }
                        } while (choice2 != 4);
                        break;

                    case 3:
                        GalleryService galleryService = new GalleryService();
                        do
                        {
                            Console.WriteLine("Gallery Management");
                            Console.WriteLine("1.Add Gallery\n2.Update Gallery\n3.Remove Gallery\n4.Search Gallery\n5.Exit");
                            Console.WriteLine("What would you like to do:");
                            choice3 = int.Parse(Console.ReadLine());
                            Gallery gallery;
                            switch (choice3)
                            {
                                case 1:
                                    Console.WriteLine("Enter the Name: ");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Enter the description: ");
                                    string desc = Console.ReadLine();
                                    Console.WriteLine("Enter the Location: ");
                                    string loct = Console.ReadLine();
                                    Console.WriteLine("Enter the Openiong hours: ");
                                    string opnhr = Console.ReadLine();
                                    Console.WriteLine("Enter the Curator: ");
                                    string cur = Console.ReadLine();
                                    Console.WriteLine("Enter the Artist id: ");
                                    int artistID = int.Parse(Console.ReadLine());
                                    gallery = new Gallery() { Name = name, Description = desc, Location = loct, Opening_hours = opnhr, Curator = cur, ArtistID = artistID };
                                    galleryService.InsertRecordstoGallery(gallery);
                                    Console.WriteLine("Gallery added succesfully");
                                    break;

                                case 2:

                                    Console.WriteLine("Enter the Name: ");
                                    string updt_name = Console.ReadLine();
                                    Console.WriteLine("Enter the description: ");
                                    string updt_des = Console.ReadLine();
                                    Console.WriteLine("Enter the Location: ");
                                    string updt_loc = Console.ReadLine();
                                    Console.WriteLine("Enter the Openiong hours: ");
                                    string updt_opnh = Console.ReadLine();
                                    Console.WriteLine("Enter the Curator: ");
                                    string updt_cur = Console.ReadLine();
                                    Console.WriteLine("Enter the artist id: ");
                                    int updt_artistID = int.Parse(Console.ReadLine());
                                    gallery = new Gallery() { Name = updt_name, Description = updt_des, Location = updt_loc, Opening_hours = updt_opnh, Curator = updt_cur, ArtistID = updt_artistID };
                                    galleryService.UpdateRecordsInGallery(gallery);
                                    Console.WriteLine("Gallery udpated succesfully");
                                    break;

                                case 3:
                                    Console.WriteLine("Enter the gallery id: ");
                                    int gallery_id = int.Parse(Console.ReadLine());
                                    galleryService.RemovefromGallery(gallery_id);
                                    Console.WriteLine("Gallery Removed Successfully");
                                    break;



                                case 4:
                                    galleryService.SearchGallery();
                                    break;

                                case 5:
                                    Console.WriteLine("Exiting from Gallery Management!");
                                    break;

                                default:
                                    Console.WriteLine("Wrong choice!Try Again!");
                                    break;
                            }
                        } while (choice3 != 5);
                        break;
                    case 4:
                        Console.WriteLine("Exiting from Art Gallery");
                        break;

                    default:
                        Console.WriteLine("Wrong choice!Try again!");
                        break;
                }

            } while (choice != 4);
        }
    }
}
