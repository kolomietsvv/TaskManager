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

        public User GetUser(string login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = login;
                connection.Open();
                var reader = command.ExecuteReader();
                var user = new User();
                while (reader.Read())
                {// корявый код
                    try
                    {
                        user = new User(
                            (Guid)reader["userId"], (string)reader["loginName"], (string)reader["passwordHash"],
                            (string)reader["email"], (string)reader["firstName"], (string)reader["lastName"],// корявый код
                            (DateTime)reader["DateOfBirth"], (string)reader["companyName"], (string)reader["qualification"],
                            (string)reader["extraInf"]);
                    }
                    catch (Exception)
                    {
                        user = new User(// корявый код
                            (Guid)reader["userId"], (string)reader["loginName"], (string)reader["passwordHash"],
                            (string)reader["email"]);
                    }
                    connection.Close();
                    var newCommand = new SqlCommand("getAllUserRoles", connection);// корявый код
                    newCommand.CommandType = CommandType.StoredProcedure;
                    newCommand.Parameters.Add("@userLogin", System.Data.SqlDbType.VarChar).Value = login;
                    connection.Open();
                    var newReader = newCommand.ExecuteReader();
                    user.Roles = new List<string>();
                    while (newReader.Read())
                    {
                        user.Roles.Add((string)newReader["roleName"]);
                    }
                    return user;         
                }
                return null;
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
    }
}
