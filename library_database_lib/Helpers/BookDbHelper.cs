using library_data_models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class BookDbHelper
    {
        private SqlConnection connection;

        private string selectBooksCommand = @"
            SELECT b.book_id, bi.book_isnb, bi.title AS book_title, bi.type  AS book_type, bi.pub_date AS book_pub_date,
                p.pub_id, p.name AS pub_name, p.address AS pub_address, p.city AS pub_city, p.phone AS pub_phone,
                l.row_num, l.shelf_num, l.cell_num
            FROM books_isnb bi JOIN books b
                ON bi.book_isnb = b.book_isnb
            JOIN publishers p
                ON p.pub_id = bi.pub_id
            JOIN book_location l
                ON l.book_id = b.book_id ";

        public BookDbHelper(string connectionString)
        {
            connection = new SqlConnection();
            this.connection.ConnectionString = connectionString;
        }

        // gets all books in the library
        public List<Book> GetAllBooks()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectBooksCommand;

            return ExecuteSelectBooksCommand(cmd);
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
            //convert book id list to string
            string idString = String.Join(", ", booksIdList); 

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectBooksCommand + 
                @" WHERE b.book_id IN (" + idString + ")";

            return ExecuteSelectBooksCommand(cmd);
        }

        // gets book by it's location
        public Book GetBookByLocation(Location location)
        {
            Book book = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectBooksCommand +
                @" WHERE l.row_num = @row_num 
                    AND l.shelf_num = @shelf_num 
                    AND l.cell_num = @cell_num";

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@row_num",
                Value = location.RowNumber,
                SqlDbType = SqlDbType.Int
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@shelf_num",
                Value = location.ShelfNumber,
                SqlDbType = SqlDbType.Int
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@cell_num",
                Value = location.CellNumber,
                SqlDbType = SqlDbType.Int
            });

            try
            {
                book = ExecuteSelectBooksCommand(cmd)[0];
            }
            catch (Exception e)
            {
                return null;
            }

            return book;
        }

        // gets books by it's ISNB number
        public List<Book> GetBooksByIsnb(string isnb)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectBooksCommand +
                @" WHERE b.book_isnb = @book_isnb";

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@book_isnb",
                Value = isnb,
                SqlDbType = SqlDbType.NVarChar
            });

            return ExecuteSelectBooksCommand(cmd);
        }

        // gets books by mentioned type
        public List<Book> GetBooksByType(int type)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectBooksCommand +
                @" WHERE bi.type = @book_type";

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@book_type",
                Value = type,
                SqlDbType = SqlDbType.Int
            });

            return ExecuteSelectBooksCommand(cmd);
        }

        // gets books with the title similar to mentioned one
        public List<Book> GetBooksByTitle(string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectBooksCommand +
                @" WHERE bi.title LIKE @book_title";

            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@book_title",
                Value = "%" + title + "%",
                SqlDbType = SqlDbType.Char
            });

            return ExecuteSelectBooksCommand(cmd);
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
        public static Book GetBookFromQueryResult(DbDataReader dataReader)
        {
            Book book = new Book();

            book.Id = Convert.ToInt32(dataReader["book_id"]);
            book.Isnb = (string) dataReader["book_isnb"];
            book.Title = (string) dataReader["book_title"];
            book.Type = Convert.ToInt32(dataReader["book_type"]);
            //book.pubDate = (DateTime) dataReader["book_pub_date"];

            book.Publisher = PublisherDbHelper.GetPublisherFromQueryResult(dataReader);

            Location location = new Location();
            location.RowNumber = Convert.ToInt32(dataReader["row_num"]);
            location.ShelfNumber = Convert.ToInt32(dataReader["shelf_num"]);
            location.CellNumber = Convert.ToInt32(dataReader["cell_num"]);

            book.Location = location;

            return book;
        }

        // executes sql command to get books
        private List<Book> ExecuteSelectBooksCommand(SqlCommand command)
        {
            List<Book> books = new List<Book>();

            try
            {
                connection.Open();

                //bing opened connection to the command
                command.Connection = connection;

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        books.Add(GetBookFromQueryResult(dataReader));
                    }
                }
            }
            catch (SqlException ex)
            { }
            finally
            {
                connection.Close();
            }

            return books;
        }
    }
}
