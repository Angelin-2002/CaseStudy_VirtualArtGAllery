using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Model;
using VirtualArtGallery.Service;

namespace VirtualArtGallery.MainMenu
{
    internal class VAG
    {
        ArtworkService artworkService = new ArtworkService();
        UserFavouriteService userFavouriteService = new UserFavouriteService();
        UserService usersService = new UserService();
        GalleryService galleryService = new GalleryService();
        VirtualArtGal virtualGallery = new VirtualArtGal();

        public void Handlemenu()
        {
            bool log = false;
            do
            {
                Console.WriteLine("\n1: Login\n2: Register\n3: Exit\n");
                Console.WriteLine("What would you like to do: ");
                int loginChoice = int.Parse(Console.ReadLine());

                switch (loginChoice)
                {
                    case 1:
                        Console.WriteLine("Enter the username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter the password: ");
                        string password = Console.ReadLine();
                        log = usersService.Login(username, password);
                        if (!log)
                        {
                            Console.WriteLine("Invalid username or password. Please try again.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter username: ");
                        string newUsername = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string newPassword = Console.ReadLine();
                        User newUser = new User() { UserName = newUsername, Password = newPassword };
                        usersService.Register(newUser);
                        Console.WriteLine("Registration successfull. Please continue to Login");
                        break;

                    case 3:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
            } while (!log);

            virtualGallery.MainMenu();
        }
    }
}

