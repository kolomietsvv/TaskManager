using TaskManager.Common.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TaskManager.DAL.MSSQL;
using TaskManager.DAL.Interface;
using System.Data;
using System.Configuration;
using System;

namespace TaskManager.DAL.MSSQL
{
   public class ProjectDAO : IProjectDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;

        public List<ProjectTask> GetAllTasks(Guid projectId)
        {
            var tasks = new List<ProjectTask>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllTasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@projectId", System.Data.SqlDbType.VarChar).Value = projectId.ToString();
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        tasks.Add(new ProjectTask((Guid)reader["projectId"], (string)reader["name"], 
                            (string)reader["summary"], (DateTime)reader["creationTime"], (DateTime)reader["deadline"]));
                    }
                    catch (Exception)
                    {
                        tasks.Add(new ProjectTask((Guid)reader["projectId"], 
                            (string)reader["name"], (DateTime)reader["creationTime"], (DateTime)reader["deadline"]));
                    }

                }
                return tasks;
            }
        }
    }
}
