using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TaskManager.Common.Entities;
using TaskManager.DAL.MSSQL;
using TaskManager.DAL.Interface;
using System.Data;

namespace TaskManager.DAL.MSSQL
{
    public class UserDAO : IUserDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = user.LoginName;
                command.Parameters.Add("@passwordHash", System.Data.SqlDbType.VarChar).Value = user.PasswordHash;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = user.Email;
                var reader = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllUsers", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new User(
                        (Guid)reader["userId"], (string)reader["loginame"], (string)reader["passwordHash"],
                        (string)reader["email"], (string)reader["firstName"], (string)reader["lastName"],
                        (DateTime)reader["DateOfBirth"], (string)reader["companyName"], (string)reader["qualification"],
                        (string)reader["extraInf"]);
                }
            }
        }

        public User GetUser(string loginName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = loginName;
                connection.Open();
                var reader = command.ExecuteReader();
                var user = new User();
                while (reader.Read())
                {
                    user.LoginName = (string)reader["loginName"];
                    user.PasswordHash = (string)reader["passwordHash"];
                    user.Email = (string)reader["email"];
                    user.UserId = (Guid)reader["userId"];

                    user.FirstName = reader["firstName"] as string;
                    user.LastName = reader["lastName"] as string;

                    try { user.DateOfBirth = (DateTime)reader["dateOfBirth"]; }
                    catch {; }

                    user.CompanyName = reader["companyName"] as string;
                    user.Qualification = reader["qualification"] as string;
                    user.ExtraInf = reader["extraInf"] as string;

                    connection.Close();
                    command = new SqlCommand("getAllUserRoles", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = loginName;
                    connection.Open();
                    reader = command.ExecuteReader();
                    user.Roles = new List<string>();
                    while (reader.Read())
                    {
                        user.Roles.Add((string)reader["roleName"]);
                    }
                    connection.Close();
                    return user;
                }
                return null;
            }
        }

        public IEnumerable<Project> GetAllProjects(string loginName)
        {
            var projects = new List<Project>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllUserProjects", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = loginName;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                        yield return new Project()
                        {
                            Name = (string)reader["name"],
                            ProjectId = (Guid)reader["projectId"],
                            ManagerLogin = loginName,
                            Summary = reader["summary"] as string
                        };
                }
            }
        }

        public bool CanLogin(string loginName, string passwordHash)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("canLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = loginName;
                command.Parameters.Add("@passwordHash", System.Data.SqlDbType.VarChar).Value = passwordHash;
                connection.Open();
                return (bool)command.ExecuteScalar();
            }
        }

        public bool AddRole(string userId, string roleName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("createRole", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", System.Data.SqlDbType.VarChar).Value = userId;
                command.Parameters.Add("@roleName", System.Data.SqlDbType.VarChar).Value = roleName;
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void AddProject(string login, string projectName, string summary)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addProject", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.NVarChar).Value = login;
                command.Parameters.Add("@projectName", System.Data.SqlDbType.NVarChar).Value = projectName;
                command.Parameters.Add("@summary", System.Data.SqlDbType.NVarChar).Value = summary;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllLike(User request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllUsersLike", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = request.LoginName;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = request.Email;
                command.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = request.FirstName;
                command.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = request.LastName;
                command.Parameters.Add("@age", System.Data.SqlDbType.Int).Value = request.Age;
                command.Parameters.Add("@companyName", System.Data.SqlDbType.VarChar).Value = request.CompanyName;
                command.Parameters.Add("@qualification", System.Data.SqlDbType.VarChar).Value = request.Qualification;
                command.Parameters.Add("@extraInf", System.Data.SqlDbType.VarChar).Value = request.ExtraInf;
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
                        //+Age
                        CompanyName = reader["companyName"] as string,
                        Qualification = reader["qualification"] as string,
                        ExtraInf = reader["extraInf"] as string,
                    };
                }
            }
        }
    }
}
