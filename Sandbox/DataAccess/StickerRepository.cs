
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Sandbox
{
    public static class StickerRepository
    {

        public static StickerModel GetSticker(Guid id)
        {
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(DataConst.connString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Sticker WHERE ID ='" + id + "'", conn);
            StickerModel a = null;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    a = ReadOneSticker(rdr);
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }

            return a;
        }

        public static List<StickerModel> GetStickerListByBookId(Guid BookId)
        {
            var sql = "SELECT * FROM dbo.Sticker WHERE BookId = '" + BookId + "'";
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(DataConst.connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            var retList = new List<StickerModel>();
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var a = ReadOneSticker(rdr);
                    retList.Add(a);
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }

            return retList;
        }

        public static StickerModel SaveSticker(StickerModel a, bool isNew)
        {
            // When a.Id is a Guid.Null, this is a create. else this is a update
            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("Save_Sticker", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", a.Id);
            cmd.Parameters.AddWithValue("@name", a.Name);
            cmd.Parameters.AddWithValue("@desc", a.Desc);
            cmd.Parameters.AddWithValue("@tag", a.Tag);
            cmd.Parameters.AddWithValue("@posX", a.PosX);
            cmd.Parameters.AddWithValue("@posY", a.PosY);
            cmd.Parameters.AddWithValue("@width", a.Width);
            cmd.Parameters.AddWithValue("@height", a.Height);

            cmd.Parameters.AddWithValue("@forecolorA", a.ForecolorA);
            cmd.Parameters.AddWithValue("@forecolorR", a.ForecolorR);
            cmd.Parameters.AddWithValue("@forecolorG", a.ForecolorG);
            cmd.Parameters.AddWithValue("@forecolorB", a.ForecolorB);
            cmd.Parameters.AddWithValue("@backcolorA", a.BackcolorA);
            cmd.Parameters.AddWithValue("@backcolorR", a.BackcolorR);
            cmd.Parameters.AddWithValue("@backcolorG", a.BackcolorG);
            cmd.Parameters.AddWithValue("@backcolorB", a.BackcolorB);

            cmd.Parameters.AddWithValue("@BookId", a.BookId);
            cmd.Parameters.AddWithValue("@isNew", isNew);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return a;
        }

        public static void DeleteSticker(Guid id)
        {
            if (id == null || id == Guid.Empty) return;

            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("DELETE FROM Sticker WHERE id ='" + id + "'", conn);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return;
        }

        public static void DeleteStickersByBookId(Guid bookId)
        {
            if (bookId == null || bookId == Guid.Empty) return;

            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("DELETE FROM Sticker WHERE BookId ='" + bookId + "'", conn);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return;
        }

        private static StickerModel ReadOneSticker(SqlDataReader rdr)
        {
            var a = new StickerModel(Guid.Empty);
            a.Id = (Guid)rdr["Id"];
            a.Name = (rdr["Name"] == DBNull.Value) ? string.Empty : rdr["Name"].ToString();
            a.Desc = (rdr["Desc"] == DBNull.Value) ? string.Empty : rdr["Desc"].ToString();
            a.Tag = (rdr["Tag"] == DBNull.Value) ? string.Empty : rdr["Tag"].ToString();
            a.PosX = (rdr["PosX"] == DBNull.Value) ? 1600 : (int)rdr["PosX"];
            a.PosY = (rdr["PosY"] == DBNull.Value) ? 1600 : (int)rdr["PosY"];

            a.ForecolorA = (rdr["ForecolorAm"] == DBNull.Value) ? 120 : (int)rdr["ForecolorA"];
            a.ForecolorR = (rdr["ForecolorR"] == DBNull.Value) ? 120 : (int)rdr["ForecolorR"];
            a.ForecolorG = (rdr["ForecolorG"] == DBNull.Value) ? 120 : (int)rdr["ForecolorG"];
            a.ForecolorB = (rdr["ForecolorB"] == DBNull.Value) ? 120 : (int)rdr["ForecolorB"];

            a.BackcolorA = (rdr["BackcolorA"] == DBNull.Value) ? 120 : (int)rdr["BackcolorA"];
            a.BackcolorR = (rdr["BackcolorR"] == DBNull.Value) ? 120 : (int)rdr["BackcolorR"];
            a.BackcolorG = (rdr["BackcolorG"] == DBNull.Value) ? 120 : (int)rdr["BackcolorG"];
            a.BackcolorB = (rdr["BackcolorB"] == DBNull.Value) ? 120 : (int)rdr["BackcolorB"];
            a.Width = (rdr["Width"] == DBNull.Value) ? 30 : (int)rdr["Width"];
            a.Height = (rdr["Height"] == DBNull.Value) ? 20 : (int)rdr["Height"];
            
            a.BookId = (Guid)rdr["BookId"];
            return a;
        }

    }

}
