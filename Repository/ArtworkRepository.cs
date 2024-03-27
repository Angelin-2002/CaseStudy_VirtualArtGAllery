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
    internal class ArtworkRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;


        public ArtworkRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public bool addArtwork(Artwork artwork)
        {

            cmd.CommandText = "Insert into Artwork values(@a_title,@a_description,@a_cdate,@a_medium,@a_imURL,@id)";
            cmd.Parameters.AddWithValue("@a_title", artwork.Title);
            cmd.Parameters.AddWithValue("@a_description", artwork.Description);
            cmd.Parameters.AddWithValue("@a_cdate", artwork.CreationDate);
            cmd.Parameters.AddWithValue("a_medium", artwork.Medium);
            cmd.Parameters.AddWithValue("a_imURL", artwork.ImageURL);
            cmd.Parameters.AddWithValue("@id", artwork.ArtistID);
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
        public bool removeArtwork(int ArtworkID)
        {
            cmd.CommandText = "Delete from Artwork where ArtworkID = @a_id";
            cmd.Parameters.AddWithValue("@a_id", ArtworkID);
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

        public bool updateArtwork(Artwork artwork)
        {
            cmd.CommandText = "Update Artwork set Title = @title,Description = @desc , CreationDate = @cdate, Medium = @med, ImageURL = @imgurl where ArtworkID = @a_id";
            cmd.Parameters.AddWithValue("@title", artwork.Title);
            cmd.Parameters.AddWithValue("@desc", artwork.Description);
            cmd.Parameters.AddWithValue("@cdate", artwork.CreationDate);
            cmd.Parameters.AddWithValue("@med", artwork.Medium);
            cmd.Parameters.AddWithValue("imgurl", artwork.ImageURL);
            cmd.Parameters.AddWithValue("@a_id", artwork.ArtworkID);
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
        public void getArtworkById(int ArtworkID)
        {
            cmd.CommandText = "Select * from Artwork where ArtworkID = @a_id";
            cmd.Parameters.AddWithValue("@a_id", ArtworkID);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Artwork artwork = new Artwork();
                artwork.ArtworkID = (int)sqlDataReader["ArtworkID"];
                artwork.Title = (String)sqlDataReader["Title"];
                artwork.Description = (String)sqlDataReader["Description"];
                artwork.Medium = (String)sqlDataReader["Medium"];
                artwork.CreationDate = (DateTime)sqlDataReader["CreationDate"];
                artwork.ImageURL = (String)sqlDataReader["ImageURL"];
                artwork.ArtistID = Convert.IsDBNull(sqlDataReader["ArtistID"]) ? null : (int)sqlDataReader["ArtistID"];
                Console.WriteLine(artwork);
            }
            connect.Close();

        }

        public List<Artwork> searchArtworks()
        {
            List<Artwork> artworklist = new List<Artwork>();
            cmd.CommandText = "Select * from Artwork";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Artwork artwork = new Artwork();
                artwork.ArtworkID = (int)sqlDataReader["ArtworkID"];
                artwork.Title = (String)sqlDataReader["Title"];
                artwork.Description = (String)sqlDataReader["Description"];
                artwork.Medium = (String)sqlDataReader["Medium"];
                artwork.CreationDate = (DateTime)sqlDataReader["CreationDate"];
                artwork.ImageURL = (String)sqlDataReader["ImageURL"];
                artwork.ArtistID = Convert.IsDBNull(sqlDataReader["ArtistID"]) ? null : (int)sqlDataReader["ArtistID"];
                artworklist.Add(artwork);
            }

            connect.Close();
            return artworklist;


        }

        public bool ArtworkExists(int artworkID)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as totalartworks from Artwork where ArtworkID=@a_id";
            cmd.Parameters.AddWithValue("@a_id", artworkID);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                count = (int)sqldatareader["totalartworks"];
            }
            connect.Close();
            if (count > 0)
            {
                return true;
            }
            return false;

        }
    }
}
