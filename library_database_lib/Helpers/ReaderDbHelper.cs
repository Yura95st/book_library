using library_data_models.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class ReaderDbHelper
    {
        private SqlConnection connection;

        public ReaderDbHelper(string connectionString)
        {
            connection = new SqlConnection();
            this.connection.ConnectionString = connectionString;
        }

        // gets all readers of the library
        public List<Reader> GetAllReaders()
        {
            throw new NotImplementedException();
        }

        // gets reader info by his id number
        public Reader GetReaderById(int readerId)
        {
            throw new NotImplementedException();
        }

        // gets all reader's books (whole history list)
        public List<ReadersBook> GetReaderAllBooks(int readerId)
        {
            throw new NotImplementedException();
        }

        // gets all reader's borrowed books, that isn't yet returned
        public List<ReadersBook> GetReaderBorrowedBooks(int readerId)
        {
            throw new NotImplementedException();
        }

        // gets readers by searching parameters
        public List<Reader> SearchForReaders(string firstName, string lastName, string phone = "")
        {
            throw new NotImplementedException();
        }

        // creates new reader and returns it's id number
        public int CreateNewReader(Reader reader)
        {
            throw new NotImplementedException();
        }

        // deactivates reader
        public void DeactivateReader(int readerId)
        {
            throw new NotImplementedException();
        }

        // modifies reader's info
        public void ModifyReaderInfo(Reader reader)
        {
            throw new NotImplementedException();
        }

        // reader borrow new book
        public void BorrowNewReaderBook(int readerId, int bookId)
        {
            throw new NotImplementedException();
        }

        // reader returns book with "bookId" to the library
        public void ReturnReaderBook(int readerId, int bookId)
        {
            List<int> booksIdList = new List<int>();
            booksIdList.Add(bookId);

            ReturnReaderBooks(readerId, booksIdList);
        }

        // reader returns books to the library
        public void ReturnReaderBooks(int readerId, List<int> booksIdList)
        {
            throw new NotImplementedException();
        }

        // gets all reader's penalties (whole history list)
        public List<Penalty> GetReaderAllPenalties(int readerId, int type = 0)
        {
            throw new NotImplementedException();
        }

        // gets all reader's penalties, that aren't expired yet
        public List<Penalty> GetReaderActivePenalties(int readerId, int type = 0)
        {
            throw new NotImplementedException();
        }

        // returns Reader object from the query result - dataReader
        public static Reader GetReaderFromQueryResult(DbDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        // gets id-list of all reader's books (whole history list)
        private List<int> GetReaderAllBooksIdList(int readerId)
        {
            throw new NotImplementedException();
        }

        // gets id-list of all reader's borrowed books, that isn't yet returned
        private List<int> GetReaderBorrowedBooksIdList(int readerId)
        {
            throw new NotImplementedException();
        }

        // gets id-list of all reader's penalties (whole history list)
        private List<int> GetReaderAllPenaltiesIdList(int readerId, int type = 0)
        {
            throw new NotImplementedException();
        }

        // gets id-list of all reader's penalties, that aren't expired yet
        private List<int> GetReaderActivePenaltiesIdList(int readerId, int type = 0)
        {
            throw new NotImplementedException();
        }
    }
}
