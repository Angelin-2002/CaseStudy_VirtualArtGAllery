using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Model;
using VirtualArtGallery.Utility;

namespace VirtualArtGallery.Repository
{
    internal class GalleryRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public GalleryRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public bool addGallery(Gallery gallery)
        {

            cmd.CommandText = "Insert into Gallery values(@g_name,@g_description,@g_location,@g_curator,@g_ophours,@g_id)";
            cmd.Parameters.AddWithValue("@g_name", gallery.Name);
            cmd.Parameters.AddWithValue("@g_description", gallery.Description);
            cmd.Parameters.AddWithValue("@g_location", gallery.Location);
            cmd.Parameters.AddWithValue("g_curator", gallery.Curator);
            cmd.Parameters.AddWithValue("g_ophours", gallery.Opening_hours);
            cmd.Parameters.AddWithValue("@g_id", gallery.ArtistID);
            connect.Open();
            cmd.Connection = connect;
            int st = cmd.ExecuteNonQuery();
            connect.Close();
            if (st > 0)
            {
                return true;
            }
            return false;

        }

        public bool removeGallery(int galleryID)
        {
            cmd.CommandText = "Delete from Gallery where GalleryID = @g_id";
            cmd.Parameters.AddWithValue("@g_id", galleryID);
            connect.Open();
            cmd.Connection = connect;
            int st = cmd.ExecuteNonQuery();
            connect.Close();
            if (st > 0)
            {
                return true;
            }
            return false;


        }

        public bool UpdateGallery(Gallery gallery)
        {
            cmd.CommandText = "Update Gallery set Name = @name,Description = @desc , Location = @loc, Curator= @cur, Opening_hours = @oph where GalleryID = @g_id";
            cmd.Parameters.AddWithValue("@name", gallery.Name);
            cmd.Parameters.AddWithValue("@desc", gallery.Description);
            cmd.Parameters.AddWithValue("@loc", gallery.Location);
            cmd.Parameters.AddWithValue("@cur", gallery.Curator);
            cmd.Parameters.AddWithValue("oph", gallery.Opening_hours);
            cmd.Parameters.AddWithValue("@g_id", gallery.GalleryID);
            connect.Open();
            cmd.Connection = connect;
            int st1 = cmd.ExecuteNonQuery();
            connect.Close();
            if (st1 > 0)
            {
                return true;
            }
            return false;

        }

        public List<Gallery> searchGallery()
        {
            List<Gallery> gallerylist = new List<Gallery>();
            cmd.CommandText = "Select * from Gallery";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Gallery gallery = new Gallery();
                gallery.GalleryID = (int)sqlDataReader["GalleryID"];
                gallery.Name = (String)sqlDataReader["Name"];
                gallery.Description = (String)sqlDataReader["Description"];
                gallery.Location = (String)sqlDataReader["Location"];
                gallery.Curator = (String)sqlDataReader["Curator"];
                gallery.Opening_hours = (String)sqlDataReader["Opening_hours"];
                gallery.ArtistID = Convert.IsDBNull(sqlDataReader["ArtistID"]) ? null : (int)sqlDataReader["ArtistID"];
                gallerylist.Add(gallery);
            }

            connect.Close();
            return gallerylist;


        }
    }
}
