using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using library_database_lib.Helpers;
using library_data_models.Models;

namespace library_database_lib_test
{
    [TestClass]
    public class PublisherDbHelperTest
    {
        string connectionString;
        PublisherDbHelper publisherHelper;

        [TestInitialize]
        public void PublisherDbHelperInit()
        {
            connectionString = ConfigurationManager.
                ConnectionStrings["SqlConnectionStrings"].ConnectionString;
            publisherHelper = new PublisherDbHelper(connectionString);
        }
        [TestMethod]
        public void PublisherDbHelper()
        {
            int test_id = 1;
            Publisher receivedPublisher;
            Assert.IsNotNull(publisherHelper);
            receivedPublisher = publisherHelper.GetPublisherById(1);
            Assert.IsNotNull(receivedPublisher);
            Assert.AreEqual(test_id, receivedPublisher.Id);
            test_id = -1;
            receivedPublisher = publisherHelper.GetPublisherById(-1);
            Assert.IsNull(receivedPublisher);
        }
        

    }
}
