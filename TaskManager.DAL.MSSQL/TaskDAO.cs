using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Entities;
using TaskManager.DAL.Interface;

namespace TaskManager.DAL.MSSQL
{
    public class TaskDAO : ITaskDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
        public IEnumerable<Subtask> GetAllSubtasks(Guid taskId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var subtasks = new List<Subtask>();
                var command = new SqlCommand("getAllSubtasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@taskId", SqlDbType.VarChar).Value = taskId.ToString();
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Subtask()
                    {
                        DoneBy= reader["doneBy"] as string,
                        TaskId = (Guid)reader["taskId"],
                        SubtaskId = (Guid)reader["subtaskId"],
                        Name = (string)reader["name"],
                        CreationTime = (DateTime)reader["creationTime"],
                        CompletionTime = reader["completionTime"] as DateTime?,//nullable type
                        ProjectId= (Guid)reader["projectId"]
                    };
                }
            }
        }

        public void AddSubtask(Guid taskId, string name, DateTime creationTime)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addSubtask", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@subtaskName", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@taskId", SqlDbType.VarChar).Value = taskId.ToString();
                command.Parameters.Add("@creationTime", SqlDbType.DateTime2).Value = creationTime;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
