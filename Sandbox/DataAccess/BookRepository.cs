
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Sandbox
{
    public static class BookRepository
    {

        public static BookModel GetBook(Guid id)
        {
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(DataConst.connString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Book WHERE ID ='" + id + "'", conn);
            BookModel a = null;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    a = ReadOneBook(rdr);
                }
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }
            return a;
        }


        public static List<BookModel> GetBookList()
        {
            var sql = "SELECT * FROM dbo.Book";
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(DataConst.connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            var retList = new List<BookModel>();
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var a = ReadOneBook(rdr);
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

        public static BookModel SaveBook(BookModel a , bool isNew)
            {
            // When a.Id is a Guid.Null, this is a create. else this is a update
            SqlConnection conn = new SqlConnection(DataConst.connString);
            var cmd = new SqlCommand("Save_Book", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", a.Id);
                cmd.Parameters.AddWithValue("@name", a.Name);
                cmd.Parameters.AddWithValue("@desc", a.Desc);
                cmd.Parameters.AddWithValue("@width", a.Width);
                cmd.Parameters.AddWithValue("@height", a.Height);
                cmd.Parameters.AddWithValue("@isNew", isNew);
            try
            {
                    conn.Open();
                    cmd.ExecuteScalar();
                //var retId = (Guid)cmd.ExecuteScalar();
                // a.Id = retId;
            }
            catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    if (conn != null) { conn.Close(); }
                }
                return a;
            }


            public static void DeleteBook(Guid id)
            {
                if (id == null || id == Guid.Empty) return;

            SqlConnection conn = new SqlConnection(DataConst.connString);
                var cmd = new SqlCommand("DELETE FROM Book WHERE id ='" + id + "'", conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteScalar();
                }
                finally
                {
                    if (conn != null) { conn.Close(); }
                }

                return;
            }
        
            private static BookModel ReadOneBook(SqlDataReader rdr)
            {
                var a = new BookModel();
                // get the results of each column
                a.Id = (Guid)rdr["Id"];
                a.Name = (rdr["Name"] == DBNull.Value) ? string.Empty : rdr["Name"].ToString();
                a.Desc = (rdr["Desc"] == DBNull.Value) ? string.Empty : rdr["Desc"].ToString();
                a.Width = (rdr["Width"] == DBNull.Value) ? 800 :(int) rdr["Width"];
                a.Height = (rdr["Height"] == DBNull.Value) ? 600 : (int)rdr["Height"];

                return a;
            }
    
    }
}
