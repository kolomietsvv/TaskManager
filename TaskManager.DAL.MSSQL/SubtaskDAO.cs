using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL.Interface;

namespace TaskManager.DAL.MSSQL
{
    public class SubtaskDAO : ISubtaskDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
        public void TryToDo(Guid subtaskId, string userLogin)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addDoneBy", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@subtaskId", SqlDbType.NVarChar).Value = subtaskId.ToString();
                command.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = userLogin;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ConfirmCompletion(Guid subtaskId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addCompletionTime", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@subtaskId", SqlDbType.VarChar).Value = subtaskId.ToString();
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void RejectCompletion(Guid subtaskId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("removeDoneBy", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@subtaskId", SqlDbType.VarChar).Value = subtaskId.ToString();
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
