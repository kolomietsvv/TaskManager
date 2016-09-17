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

        public IEnumerable<ProjectTask> GetAllTasks(Guid projectId)
        {
            var tasks = new List<ProjectTask>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllTasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@projectId", SqlDbType.VarChar).Value = projectId.ToString();
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        tasks.Add(new ProjectTask((Guid)reader["taskId"], (string)reader["name"],
                            (string)reader["summary"], (DateTime)reader["creationTime"], (DateTime)reader["deadline"]));
                    }
                    catch (Exception)
                    {
                        tasks.Add(new ProjectTask((Guid)reader["taskId"],
                            (string)reader["name"], (DateTime)reader["creationTime"], (DateTime)reader["deadline"]));
                    }

                }
                return tasks;
            }
        }
        public void AddTask(Guid projectId, string name, string summary, DateTime deadline)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addTask", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@projectId", SqlDbType.VarChar).Value = projectId.ToString();
                command.Parameters.Add("@taskName", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@taskSummary", SqlDbType.NVarChar).Value = summary;
                command.Parameters.Add("@deadline", SqlDbType.DateTime2).Value = deadline;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Project> GetAllLike(Project request)
        {
            throw new NotImplementedException();
        }

        public Project GetProject(string Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getProject", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@projectId", SqlDbType.VarChar).Value = Id;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Project()
                    {
                        ManagerLogin = (string)reader["loginName"],
                        Summary = (string)reader["summary"],
                        Name = (string)reader["name"]
                    };
                }
                return null;
            }
        }

        public IEnumerable<User> GetAllContributors(string projectId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllProjectContributors", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@projectId", SqlDbType.VarChar).Value = projectId;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new User()
                    {
                        LoginName = (string)reader["loginName"],
                        Email = (string)reader["email"],
                        FirstName = reader["firstName"] as string,
                        LastName = reader["lastName"] as string,
                        CompanyName = reader["companyName"] as string,
                        Qualification = reader["qualification"] as string,
                        ExtraInf = reader["extraInf"] as string,
                    };
                }
            }
        }

    }
}
