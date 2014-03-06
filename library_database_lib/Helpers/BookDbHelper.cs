using library_data_models.Models;
using System;
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

        // gets all books in the library
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

        // gets book by it's id number
        public Book GetBookById(int bookId)
        {
            List<int> booksIdList = new List<int>();
            booksIdList.Add(bookId);

            Book book = null;

            try
            {
                book = GetBooksById(booksIdList)[0];
            }
            catch(Exception e)
            {
                return null;
            }

            return book;
        }

        // gets books with id numbers from "bookIdsList" list
        public List<Book> GetBooksById(List<int> booksIdList)
        {
            throw new NotImplementedException();
        }

        // gets book by it's location
        public Book GetBookByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        // gets books by it's ISNB number
        public List<Book> GetBooksByIsnb(string isnb)
        {
            throw new NotImplementedException();
        }

        // gets books by mentioned type
        public List<Book> GetBooksByType(int type)
        {
            throw new NotImplementedException();
        }

        // gets books with the title similar to mentioned one
        public List<Book> GetBooksByTitle(string title)
        {
            return SearchForBooks(title);
        }

        // gets books by searching parameters
        public List<Book> SearchForBooks(string title, int type = 0, int publisherId = 0, int authorId = 0)
        {
            throw new NotImplementedException();
        }

        // adds new book to the library
        public int AddNewBook(Book book)
        {
            throw new NotImplementedException();
        }

        // deletes book from the library
        public void DeleteBook(int bookId)
        {
            throw new NotImplementedException();
        }

        // modifies book's info
        public void ModifyBookInfo(Book book)
        {
            throw new NotImplementedException();
        }

        // returns Book object from the query result - dataReader
        private Book GetBookFromQueryResult(DbDataReader dataReader)
        {
            throw new NotImplementedException();
        }
    }
}
