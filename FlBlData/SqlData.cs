
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
        //local path or file path

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


    }
}
