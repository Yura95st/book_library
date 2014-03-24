using library_data_models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class PublisherDbHelper
    {
        private SqlConnection connection;
        private string selectPublishersCommand = @" SELECT p.pub_id, p.name AS publisher_name,
                                    p.address AS publisher_address, p.city AS publisher_city,
                                    p.phone AS publisher_phone FROM publishers p ";
        public PublisherDbHelper(string connectionString)
        {
            connection = new SqlConnection();
            this.connection.ConnectionString = connectionString;
        }

        // gets publisher by it's id number
        public Publisher GetPublisherById(int publisherId)
        {
            Publisher publisher = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectPublishersCommand +
                @"WHERE pub_id = " + publisherId;
            //use direct command instead of parametr
            /*
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@pub_id",
                Value = publisherId,
                SqlDbType = SqlDbType.Int
            });
                */
            try
            {
                publisher = ExecuteSelectPublishersCommand(cmd)[0];
            }
            catch (Exception e)
            {
                return null;
            }

            return publisher;
        }

        // gets all publishers
        public List<Publisher> GetAllPublishers()
        {
            List<Publisher> publishers = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectPublishersCommand;

            try
            {
                publishers = ExecuteSelectPublishersCommand(cmd);
            }
            catch (Exception e)
            {
                return null;
            }

            return publishers;
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
        public static Publisher GetPublisherFromQueryResult(DbDataReader dataReader)
        {
            Publisher publisher = new Publisher();

            publisher.Id = Convert.ToInt32(dataReader["pub_id"]);
            publisher.Name = (string)dataReader["publisher_name"];
            publisher.Address = (string) dataReader["publisher_address"];
            publisher.City = (string) dataReader["publisher_city"];
            publisher.Phone = (string) dataReader["publisher_phone"];

            return publisher;
        }

        // gets id-list of all publisher's books
        private List<int> GetPublisherBooksIdList(int publisherId)
        {
            throw new NotImplementedException();
        }
        
        // executes sql command to get publisher
        private List<Publisher> ExecuteSelectPublishersCommand(SqlCommand command)
        {
            List<Publisher> publishers = new List<Publisher>();

            try
            {
                connection.Open();

                command.Connection = connection;

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        publishers.Add(GetPublisherFromQueryResult(dataReader));
                    }
                }
            }
            catch (SqlException ex)
            { //TODO: Implement SqlException catch
                string errorMessages = "";
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages += ("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
            }
            finally
            {
                connection.Close();
            }

            return publishers;
        }
    }
}
