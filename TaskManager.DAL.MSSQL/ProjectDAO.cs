using TaskManager.Common.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllTasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@projectId", SqlDbType.VarChar).Value = projectId.ToString();
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new ProjectTask()
                    {
                        TaskId = (Guid) reader["taskId"],
                        Name =reader["name"] as string,
                        Summary =reader["summary"] as string,
                        CreationTime=(DateTime)reader["creationTime"],
                        Deadline=reader["deadline"] as DateTime?
                    };
                }
            }
        }

        public void AddTask(Guid projectId, string name, string summary, DateTime? deadline)
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
                        ManagerLogin = reader["loginName"] as string,
                        Summary = reader["summary"] as string,
                        Name = reader["name"] as string,
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

        public void AddContributor(Guid projectId, string loginName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addContributor", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@projectId", SqlDbType.VarChar).Value = projectId.ToString();
                command.Parameters.Add("@loginName", SqlDbType.VarChar).Value = loginName;
                connection.Open();
                command.ExecuteNonQuery();              
            }
        }
    }
}
