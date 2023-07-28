﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FlBlModel;
using System.Data;

namespace FlBlData
{
    public class SqlData
    {
        static List<Accounts> Acc { get; set; }
        static List<Follower> Flwers { get; set; }
        static List<Following> Flwing { get; set; }
        static List<Blocked> Block { get; set; }

        string connectionString = "Data Source=LAPTOP-54CSVUAH\\SQLEXPRESS;Initial Catalog=FlwBlk;Integrated Security=True";

        static SqlConnection sqlconnection;

        public SqlData()
        {
            sqlconnection = new SqlConnection(connectionString);
        }

        public List<Accounts> GetAccountByStudentNo(string studentNo, string passWord)
        {
            string statement = "SELECT * FROM Accounts WHERE StudentNo = @StudentNo AND Password = @Password";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            command.Parameters.AddWithValue("@Password", passWord);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Acc = new List<Accounts>();

            while (reader.Read())
            {
                Acc.Add(new Accounts
                {
                    StudentNo = reader["StudentNo"].ToString(),
                    Password = reader["Password"].ToString(),
                    Course = reader["Course"].ToString(),
                    Section = reader["Section"].ToString(),
                    Username = reader["Username"].ToString(),
                    Status = reader["Status"].ToString()
                });
            }
            sqlconnection.Close();
            return Acc;
        }
        public List<Accounts> GetStudentAndStatus(string studentNo, string passWord)
        {
            string statement = "SELECT * FROM Accounts WHERE StudentNo = @StudentNo AND Password = @Password";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            command.Parameters.AddWithValue("@Password", passWord);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Acc = new List<Accounts>();

            while (reader.Read())
            {
                Acc.Add(new Accounts
                {
                    StudentNo = reader["StudentNo"].ToString(),
                    Status = reader["Status"].ToString()
                });
            }
            sqlconnection.Close();
            return Acc;
        }


        public List<Accounts> GetStudentNumberForSignUp(string studentNo)
        {
            string statement = "SELECT * FROM Accounts WHERE StudentNo = @StudentNo";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Acc = new List<Accounts>();

            while (reader.Read())
            {
                Acc.Add(new Accounts
                {
                    StudentNo = reader["StudentNo"].ToString(),
                });
            }
            sqlconnection.Close();
            return Acc;
        }

        public List<Accounts> GetAccountByUsername(string userName)
        {
            string statement = "SELECT * FROM Accounts WHERE Username = @Username";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@Username", userName);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Acc = new List<Accounts>();
            while (reader.Read())
            {
                Acc.Add(new Accounts
                {
                    StudentNo = reader["StudentNo"].ToString(),
                    Username = reader["Username"].ToString(),
                    Course = reader["Course"].ToString(),
                    Section = reader["Section"].ToString()
                });
            }
            sqlconnection.Close();
            return Acc;
        }

        public List<Follower> GetFollowerAccountByStudentNo(string studentNo)
        {
            string statement = "SELECT * FROM Accounts WHERE StudentNo = @StudentNo";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Flwers = new List<Follower>();

            while (reader.Read())
            {
                Flwers.Add(new Follower
                {
                    FollowerName = reader["Username"].ToString(),
                    FollowerCourse = reader["Course"].ToString(),
                    FollowerSection = reader["Section"].ToString()
                });
            }
            sqlconnection.Close();
            return Flwers;
        }

        public List<Follower> GetToFollowAccount(string username)
        {
            string statement = "SELECT * FROM Accounts WHERE Username = @Username";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@Username", username);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Flwers = new List<Follower>();

            while (reader.Read())
            {
                Flwers.Add(new Follower
                {
                    StudentNo = reader["StudentNo"].ToString()
                });
            }
            sqlconnection.Close();
            return Flwers;
        }
        public List<Following> GetFollowingList(string studentNo)
        {
            string statement = "SELECT * FROM Following WHERE StudentNo = @StudentNo";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", studentNo);

            if (sqlconnection.State == ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            Flwing = new List<Following>();

            while (reader.Read())
            {
                Flwing.Add(new Following
                {
                    StudentNo = reader["StudentNo"].ToString(),
                    FollowingName = reader["FollowingName"].ToString(),
                    FollowingCourse = reader["FollowingCourse"].ToString(),
                    FollowingSection = reader["FollowingSection"].ToString()
                });
            }


            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
            return Flwing;
        }

        public List<Follower> GetFollowerList(string studentNo)
        {
            string statement = "SELECT * FROM Follower WHERE StudentNo = @StudentNo";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Flwers = new List<Follower>();

            while (reader.Read())
            {
                Flwers.Add(new Follower
                {
                    StudentNo = reader["StudentNo"].ToString(),
                    FollowerName = reader["FollowerName"].ToString(),
                    FollowerCourse = reader["FollowerCourse"].ToString(),
                    FollowerSection = reader["FollowerSection"].ToString()
                });
            }
            sqlconnection.Close();
            return Flwers;
        }

        public List<Blocked> GetBlockedList(string studentNo)
        {
            string statement = "SELECT * FROM Blocked WHERE StudentNo = @StudentNo";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Block = new List<Blocked>();

            while (reader.Read())
            {
                Block.Add(new Blocked
                {
                    StudentNo = reader["StudentNo"].ToString(),
                    BlockedName = reader["BlockedName"].ToString(),
                    BlockedCourse = reader["BlockedCourse"].ToString(),
                    BlockedSection = reader["BlockedSection"].ToString()
                });
            }
            sqlconnection.Close();
            return Block;
        }

        public List<Accounts> GetCourseSection(string course, string section, string studentNo)
        {
            string statement = "SELECT TOP 5 * FROM Accounts WHERE Course = @Course AND Section = @Section AND StudentNo <> @StudentNo";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@Course", course);
            command.Parameters.AddWithValue("@Section", section);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            sqlconnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Acc = new List<Accounts>();

            while (reader.Read())
            {
                Acc.Add(new Accounts
                {
                    Username = reader["Username"].ToString(),
                    Course = reader["Course"].ToString(),
                    Section = reader["Section"].ToString()
                });
            }
            sqlconnection.Close();

            return Acc;


        }

        public bool AlreadyExists(string loggedInStudentNo)
        {
            bool itExists = false;

            string statement = "SELECT Username, Password, Course, Section FROM Accounts WHERE StudentNo = @StudentNo ";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            sqlconnection.Open();
            command.Parameters.AddWithValue("@StudentNo", loggedInStudentNo);
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string username = reader["Username"].ToString();
                string password = reader["Password"].ToString();
                string course = reader["Course"].ToString();
                string section = reader["Section"].ToString();

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(course) && !string.IsNullOrEmpty(section))
                {
                    itExists = true;
                }
            }
            reader.Close();
            sqlconnection.Close();
            return itExists;
        }

        public void CreateNewAccount(Accounts accounts)
        {
            string statement = "UPDATE Accounts SET Username = @Username , Password = @Password , Course = @Course , Section = @Section , Status = @Status " +
                " WHERE StudentNo = @StudentNo";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            command.Parameters.AddWithValue("@StudentNo", accounts.StudentNo);
            command.Parameters.AddWithValue("@Username", accounts.Username);
            command.Parameters.AddWithValue("@Password", accounts.Password);
            command.Parameters.AddWithValue("@Course", accounts.Course);
            command.Parameters.AddWithValue("@Section", accounts.Section);
            command.Parameters.AddWithValue("@Status", accounts.Status);

            sqlconnection.Open();
            command.ExecuteNonQuery();
            sqlconnection.Close();
        }

        public void ChangeStatus(string studentNo, string password, string status = "oldAcc")
        {
            Acc = GetStudentAndStatus(studentNo, password);

            string statement = "UPDATE Accounts SET Status = @Status WHERE StudentNo = @StudentNo AND Password = @Password";
            SqlCommand command = new SqlCommand(statement, sqlconnection);

            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@StudentNo", studentNo);
            command.Parameters.AddWithValue("@Password", password);

            sqlconnection.Open();
            command.ExecuteNonQuery();
            sqlconnection.Close();
        }
    }
}
