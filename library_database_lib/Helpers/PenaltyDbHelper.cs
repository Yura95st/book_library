using library_data_models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace library_database_lib.Helpers
{
    public class PenaltyDbHelper
    {
        private SqlConnection connection;
        private string selectPenaltiesCommand = @"
            SELECT p.penalty_id, p.type AS penalty_type, p.state AS penalty_state, p.exp_date AS penalty_exp_date
            FROM penalties p";

        public PenaltyDbHelper(string connectionString)
        {
            connection = new SqlConnection();
            this.connection.ConnectionString = connectionString;
        }

        // gets penalty by it's id number
        public Penalty GetPenaltyById(int penaltyId)
        {
            Penalty penalty = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectPenaltiesCommand +
                @" WHERE penalty_id = @penalty_id";

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@penalty_id",
                Value = penaltyId,
                SqlDbType = SqlDbType.Int
            });

            try
            {
                penalty = ExecuteSelectPenaltiesCommand(cmd)[0];
            }
            catch (Exception e)
            {
                return null;
            }

            return penalty;
        }

        // gets all reader's penalties
        public List<Penalty> GetPenaltiesByReaderId(int readerId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectPenaltiesCommand +
                @" WHERE reader_id = @reader_id";

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@reader_id",
                Value = readerId,
                SqlDbType = SqlDbType.Int
            });

            return ExecuteSelectPenaltiesCommand(cmd);
        }

        // creates new penalty and returns it's id number
        public int CreateNewPenalty(Penalty penalty, int readerId)
        {
            int id = 0;

            try
            {
                connection.Open();

                string strSQL = @"INSERT INTO penalties (reader_id, type, state)" +
                    " VALUES (@reader_id, @type, @state);" +
                    " SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(strSQL, connection);

                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@reader_id",
                    Value = readerId,
                    SqlDbType = SqlDbType.Int
                });

                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@type",
                    Value = penalty.Type,
                    SqlDbType = SqlDbType.Int
                });

                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@state",
                    Value = penalty.State,
                    SqlDbType = SqlDbType.Int
                });

                //cmd.Parameters.Add(new SqlParameter
                //{
                //    ParameterName = "@exp_date",
                //    Value = "",//penalty.ExpirationDate,
                //    SqlDbType = SqlDbType.Timestamp
                //});

                id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            { }
            finally
            {
                connection.Close();
            }

            return id;
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
            string listString = String.Join(", ", penaltiesIdList);

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE penalties" +
                    " SET state = 1" +
                    " WHERE penalty_id IN (" + listString + ")";

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            { }
            finally
            {
                connection.Close();
            }
        }

        // returns Penalty object from the query result - dataReader
        public static Penalty GetPenaltyFromQueryResult(DbDataReader dataReader)
        {
            Penalty penalty = new Penalty();

            penalty.Id = Convert.ToInt32(dataReader["penalty_id"]);
            penalty.Type = Convert.ToInt32(dataReader["penalty_type"]);
            penalty.State = Convert.ToInt32(dataReader["penalty_state"]);

            //TODO: DateTime to UNIX TimeStamp covertation

            //private static DateTime TimeFromUnixTimestamp(int unixTimestamp)
            //{
            //    DateTime unixYear0 = new DateTime(1970, 1, 1);
            //    long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            //    DateTime dtUnix = new DateTime(unixYear0.Ticks + unixTimeStampInTicks);
            //    return dtUnix;
            //}

            //penalty.ExpirationDate = (DateTime)dataReader["penalty_exp_date"];

            return penalty;
        }

        // executes sql command to get penalties
        private List<Penalty> ExecuteSelectPenaltiesCommand(SqlCommand command)
        {
            List<Penalty> penalties = new List<Penalty>();

            try
            {
                connection.Open();

                command.Connection = connection;

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        penalties.Add(GetPenaltyFromQueryResult(dataReader));
                    }
                }
            }
            catch (SqlException ex)
            { }
            finally
            {
                connection.Close();
            }

            return penalties;
        }
    }
}
