using library_data_models.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class PublisherDbHelper
    {
        private string connectionString;

        public PublisherDbHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // gets publisher by it's id number
        public Publisher GetPublisherById(int publisherId)
        {
            throw new NotImplementedException();
        }

        // gets all publishers
        public List<Publisher> GetAllPublishers()
        {
            throw new NotImplementedException();
        }

        // gets publisher's all books
        public List<Book> GetPublisherBooks(int publisherId)
        {
            throw new NotImplementedException();
        }

        // creates new publisher and returns it's id number
        public int CreateNewPublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        // deletes publisher with "publisherId" id number
        public void DeletePublisher(int publisherId)
        {
            throw new NotImplementedException();
        }

        // modifies publisher's info
        public void ModifyPublisherInfo(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        // gets publishers with the name similar to mentioned one
        public List<Publisher> GetPublishersByName(string publisherName)
        {
            throw new NotImplementedException();
        }

        // returns Publisher object from the query result - dataReader
        private Publisher GetPublisherFromQueryResult(DbDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        // gets id-list of all publisher's books
        private List<int> GetPublisherBooksIdList(int publisherId)
        {
            throw new NotImplementedException();
        }
    }
}
