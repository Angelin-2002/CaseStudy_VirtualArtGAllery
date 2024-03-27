using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class Artwork
    {
        public int artworkID;
        String title;
        String description;
        String? medium;
        String? imageurl;
        DateTime creationdate;
        int? artistID;

        public Artwork() { }

        public int ArtworkID { 
            get { return artworkID; } 
            set { artworkID = value; } 
        }
        public String Title { 
            get { return title; } 
            set { title = value; } 
        }
        public String Description { 
            get { return description; } 
            set { description = value; } 
        }
        public String? Medium { 
            get { return medium; } 
            set { medium = value; } 
        }
        public String? ImageURL { 
            get { return imageurl; } 
            set { imageurl = value; } 
        }
        public DateTime CreationDate { 
            get { return creationdate; } 
            set { creationdate = value; } 
        }

        public int? ArtistID { 
            get { return artistID; } 
            set { artistID = value; } 
        }

        public Artwork(int artworkID, string title, string description, DateTime creationdate, string medium, string imageurl, int artistID)
        {
            ArtworkID = artworkID;
            Title = title;
            Description = description;
            Medium = medium;
            ImageURL = imageurl;
            CreationDate = creationdate;
            ArtistID = artistID;
        }

        public override String ToString()
        {
            return $"{ArtworkID} {Title} {Description} {Medium} {ImageURL} {CreationDate}";
        }
    }
}
