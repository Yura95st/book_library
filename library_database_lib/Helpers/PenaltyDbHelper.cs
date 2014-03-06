using library_data_models.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class PenaltyDbHelper
    {
        private string connectionString;

        public PenaltyDbHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // gets penalty by it's id number
        public Penalty GetPenaltyById(int penaltyId)
        {
            List<int> penaltiesIdList = new List<int>();
            penaltiesIdList.Add(penaltyId);

            Penalty penalty = null;

            try
            {
                penalty = GetPenaltiesById(penaltiesIdList)[0];
            }
            catch(Exception e)
            {
                return null;
            }

            return penalty;
        }

        // gets penalties
        public List<Penalty> GetPenaltiesById(List<int> penaltiesIdList)
        {
            throw new NotImplementedException();
        }

        // creates new penalty and returns it's id number
        public int CreateNewPenalty(Penalty penalty)
        {
            throw new NotImplementedException();
        }

        // deactivates penalty with "penaltyId" id number
        public void DeactivatePenalty(int penaltyId)
        {
            List<int> penaltiesIdList = new List<int>();
            penaltiesIdList.Add(penaltyId);

            DeactivatePenalties(penaltiesIdList);
        }

        // deactivates penalties with id numbers from "penaltyIdsList"
        public void DeactivatePenalties(List<int> penaltiesIdList)
        {
            throw new NotImplementedException();
        }

        // returns Penalty object from the query result - dataReader
        private Penalty GetPenaltyFromQueryResult(DbDataReader dataReader)
        {
            throw new NotImplementedException();
        }
    }
}
