using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Utility;

namespace VirtualArtGallery.Repository
{
    internal class UserFavouriteRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;


        public UserFavouriteRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();

        }

        public bool addArtworkToFavorite(int userId, int artworkId)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "Update Users set Favourite_Artworks=@art_id where UserID=@userId";
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@art_id", artworkId);
            int update = cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into User_Favourite_Artwork values (@user_Id,@artw_ID)";
            cmd.Parameters.AddWithValue("@user_Id", userId);
            cmd.Parameters.AddWithValue("@artw_ID", artworkId);
            int insert = cmd.ExecuteNonQuery();
            connect.Close();
            if (update > 0 && insert > 0)
            {
                return true;
            }
            return false;
        }
        public bool removeArtworkFromFavorite(int UserId, int ArtworkID)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "Update Users set Favourite_Artworks = NULL where UserID=@user_ID";
            cmd.Parameters.AddWithValue("@user_ID", UserId);
            int upd = cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from User_Favourite_Artwork where ArtworkID=@a_Id";
            cmd.Parameters.AddWithValue("@a_Id", ArtworkID);
            int del = cmd.ExecuteNonQuery();
            connect.Close();
            if (upd > 0 && del > 0)
            {
                return true;
            }
            return false;
        }

        public bool getUserFavouriteArtworks(int userId)
        {
            cmd.CommandText = "Select Favourite_Artworks from Users where UserID=@id";
            cmd.Parameters.AddWithValue("@id", userId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                int? favoriteArtwork = Convert.IsDBNull(reader["Favourite_Artworks"]) ? null : (int)reader["Favourite_Artworks"];
                Console.WriteLine($"Artwork:: {favoriteArtwork}");
                count++;
            }
            connect.Close();
            if (count > 0)
                return true;
            return false;
        }
        public bool UserExists(int userId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as Totalusers from Users where UserID=@u_id";
            cmd.Parameters.AddWithValue("@u_id", userId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                count = (int)sqldatareader["Totalusers"];
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
