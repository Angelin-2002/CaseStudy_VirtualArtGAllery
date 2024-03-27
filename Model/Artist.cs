using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class Artist
    {
        int artistID;
        String name;
        String biography;
        DateTime birthdate;
        String nationality;
        String website;
        String contactinformation;

        public int ArtistID { 
            get { return artistID; } 
            set { artistID = value; } 
        }
        public String Name { 
            get { return name; } 
            set { name = value; } 
        }
        public String Biography { 
            get { return biography; } 
            set { biography = value; } 
        }
        public DateTime Birthdate { 
            get { return birthdate; } 
            set { birthdate = value; } 
        }
        public String Nationality { 
            get { return nationality; } 
            set { nationality = value; } 
        }
        public String Website { 
            get { return website; } 
            set { website = value; } 
        }
        public String Contactinformation { 
            get { return contactinformation; } 
            set { contactinformation = value; } 
        }

        public Artist() { }

        public Artist(int artistID, string name, string biography, DateTime birthdate, string nationality, string website, string contactinformation)
        {

            ArtistID = artistID;
            Name = name;
            Biography = biography;
            Birthdate = birthdate;
            Nationality = nationality;
            Website = website;
            Contactinformation = contactinformation;
        }
        public override string ToString()
        {
            return $" {ArtistID} {Name} {Biography} {Birthdate} {Nationality} {Website} {Contactinformation}";
        }
    }
}
