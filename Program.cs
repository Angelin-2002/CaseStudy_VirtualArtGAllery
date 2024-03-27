using VirtualArtGallery.MainMenu;

namespace VirtualArtGallery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" WELCOME TO VIRTUAL ART GALLERY ");
            Console.WriteLine("--------------------------------\n");

            VAG artGallery = new VAG();
            artGallery.Handlemenu();

            Console.WriteLine("\nThank you !Visit Virtual Art Gallery again ! ");
        }
    }
}
