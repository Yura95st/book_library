using library_data_models.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class AuthorDbHelper
    {
        private SqlConnection connection;

        public AuthorDbHelper(string connectionString)
        {
            connection = new SqlConnection();
            this.connection.ConnectionString = connectionString;
        }

        // gets author by it's id number
        public Author GetAuthorById(int authorId)
        {
            throw new NotImplementedException();
        }

        // gets all authors
        public List<Author> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        // deletes author with "authorId" id number
        public void DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        // modifies author's info
        public void ModifyAuthorInfo(Author author)
        {
            throw new NotImplementedException();
        }

        // get all books of author with "authorId" id number
        public List<Book> GetAuthorBooks(int authorId)
        {
            throw new NotImplementedException();
        }

        // returns Author object from the query result - dataReader
        public static Author GetAuthorFromQueryResult(DbDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        // get id-list of all books of author with "authorId" id number
        private List<int> GetAuthorBooksIdList(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}
