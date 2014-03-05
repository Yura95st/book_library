using library_data_models.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class BookDbHelper
    {
        private string connectionString;

        public BookDbHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = connectionString;

                try
                {
                    cn.Open();

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT " + DbValues.BOOKS_COLUMN_ID + ", " + 
                        DbValues.BOOKS_COLUMN_TITLE + ", " +
                        DbValues.BOOKS_COLUMN_TYPE + ", " +
                        DbValues.BOOKS_COLUMN_PUB_ID + ", " +
                        DbValues.BOOKS_COLUMN_PUB_DATE + ", " +
                        DbValues.BOOKS_COLUMN_ISNB + 
                        " FROM " + DbValues.TABLE_BOOKS;

                    using (DbDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        { }
                    }                    
                }
                catch (SqlException ex)
                { }
                finally
                {
                    cn.Close();
                }
            }

            return books;
        }
    }
}
