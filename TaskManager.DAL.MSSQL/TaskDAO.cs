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
        public IEnumerable<SubTask> GetAllSubTasks(Guid taskId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var subTasks = new List<SubTask>();
                var command = new SqlCommand("getAllSubTasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@taskId", SqlDbType.VarChar).Value = taskId.ToString();
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        subTasks.Add(new SubTask
                        {
                            SubtaskId = (Guid)reader["subtaskId"],
                            Name = (string)reader["name"],
                            CreationTime = (DateTime)reader["creationTime"],
                            CompletionTime = (DateTime)reader["completionTime"]
                        });
                    }
                    catch (Exception)
                    {
                        subTasks.Add(new SubTask
                        {
                            SubtaskId = (Guid)reader["subtaskId"],
                            Name = (string)reader["name"],
                            CreationTime = (DateTime)reader["creationTime"]
                        });
                    }
                }
                return subTasks;
            }
        }

        public void AddSubTask(Guid taskId, string name, DateTime creationTime)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addSubTask", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@subTaskName", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@taskId", SqlDbType.VarChar).Value = taskId.ToString();
                command.Parameters.Add("@creationTime", SqlDbType.DateTime2).Value = creationTime;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
