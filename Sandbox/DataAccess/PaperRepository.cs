
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Sandbox
{
    public static class PaperRepository
    {

        public static PaperModel GetPaper(Guid id)
        {
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(DataConst.connString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Paper WHERE ID ='" + id + "'", conn);
            PaperModel a = null;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    a = ReadOnePaper(rdr, true);
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

        public static List<PaperModel> GetPaperListByStickerId(Guid stickerId)
        {
            var sql = "SELECT * FROM dbo.Paper WHERE StickerId = '" + stickerId + "'";
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(DataConst.connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            var retList = new List<PaperModel>();
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var a = ReadOnePaper(rdr,false);
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


        public static PaperModel SavePaper(PaperModel a, bool isNew)
        {
            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("Save_Paper", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", a.Id);
            cmd.Parameters.AddWithValue("@name", a.Name);
            cmd.Parameters.AddWithValue("@text", a.Text);
            cmd.Parameters.AddWithValue("@desc", a.Desc);
            cmd.Parameters.AddWithValue("@stickerId", a.StickerId);
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

        public static void DeletePapersByStickerId(Guid stickerId)
        {
            if (stickerId == null || stickerId == Guid.Empty) return;

            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("DELETE FROM Paper WHERE StickerId ='" + stickerId + "'", conn);

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

        public static void DeletePapersByBookId(Guid bookId)
        {
            if (bookId == null || bookId == Guid.Empty) return;

            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("DELETE FROM Paper WHERE StickerId IN (SELECT Id FROM  Sticker WHERE BookId ='" + bookId + "')", conn);

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

        public static void DeletePaper(Guid id)
        {
            if (id == null || id == Guid.Empty) return;

            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("DELETE FROM Paper WHERE id ='" + id + "'", conn);

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
        
        private static PaperModel ReadOnePaper(SqlDataReader rdr, bool withText =false)
        {
            var a = new PaperModel();
            // get the results of each column
            a.Id = (Guid)rdr["Id"];
            a.Name = (rdr["Name"] == DBNull.Value) ? string.Empty : rdr["Name"].ToString();
            a.Desc = (rdr["Desc"] == DBNull.Value) ? string.Empty : rdr["Desc"].ToString();
            if (withText)
            {a.Text = (rdr["Text"] == DBNull.Value) ? string.Empty : rdr["Text"].ToString();}
            a.StickerId = (Guid)rdr["StickerId"];
            return a;
        }

    }

}
