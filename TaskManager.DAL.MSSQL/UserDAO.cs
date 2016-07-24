﻿using System;
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

                    try { user.FirstName = (string)reader["firstName"]; }
                    catch (Exception) { new Exception("firstName haven't been added"); }
                    try { user.LastName = (string)reader["lastName"]; }
                    catch (Exception) { new Exception("lastName haven't been added"); }
                    try { user.DateOfBirth = (DateTime)reader["dateOfBirth"]; }
                    catch (Exception) { new Exception("dateOfBirth haven't been added"); }
                    try { user.CompanyName = (string)reader["companyName"]; }
                    catch (Exception) { new Exception("companyName haven't been added"); }
                    try { user.Qualification = (string)reader["qualification"]; }
                    catch (Exception) { new Exception("qualification haven't been added"); }
                    try { user.ExtraInf = (string)reader["extraInf"]; }
                    catch (Exception) { new Exception("extraInf haven't been added"); }

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

        public List<Project> GetAllProjects(string loginName)
        {
            var projects= new List<Project>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("getAllUserProjects", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = loginName;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try 
                    { 
                        projects.Add(new Project((Guid)reader["projectId"], (string)reader["name"], (string)reader["summary"])); 
                    }
                    catch(Exception)
                    {
                        projects.Add(new Project((Guid)reader["projectId"],(string)reader["name"]));
                    }
                    
                }
                return projects;
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

        public void AddProject(string login, string projectName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("addProject", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@loginName", System.Data.SqlDbType.VarChar).Value = login;
                command.Parameters.Add("@projectName", System.Data.SqlDbType.VarChar).Value = projectName;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
