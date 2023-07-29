
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FlBlModel;
using System.Data;
using FlBlUI;

namespace FlBlData
{
    public class SqlData
    {
        static List<Accounts> Acc { get; set; }
        static List<Follower> Flwers { get; set; }
        static List<Following> Flwing { get; set; }
        static List<Blocked> Block { get; set; }
        static UI uI = new();


        string connectionString = 
            "Data Source=LAPTOP-54CSVUAH\\SQLEXPRESS;Initial Catalog=FlwBlk;Integrated Security=True";

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
        public void InsertFollower(string theFollowerStudentNo, string toFollowUsername)
        {

            string statement = "INSERT INTO Follower (StudentNo, FollowerName, FollowerCourse, FollowerSection)" +
                    "VALUES (@StudentNo, @FollowerName, @FollowerCourse, @FollowerSection)";

            SqlCommand command = new SqlCommand(statement, sqlconnection);

            foreach (var accountList in Flwers = GetToFollowAccount(toFollowUsername))
            {
                command.Parameters.AddWithValue("@StudentNo", accountList.StudentNo);
            }

            foreach (var flowerlist in Flwers = GetFollowerAccountByStudentNo(theFollowerStudentNo))
            {

                command.Parameters.AddWithValue("@FollowerName", flowerlist.FollowerName);
                command.Parameters.AddWithValue("@FollowerCourse", flowerlist.FollowerCourse);
                command.Parameters.AddWithValue("@FollowerSection", flowerlist.FollowerSection);

            }
            sqlconnection.Open();
            command.ExecuteNonQuery();
            sqlconnection.Close();

        }
        public void InsertFollowing(string loggedInStudentNo, string followingName)
        {
            if (IsFollowing(loggedInStudentNo, followingName))
            {
                Console.WriteLine("Already following. Do you want to unfollow it? (Y/N)");
                string choose = Console.ReadLine().ToUpper();
                if (choose == "Y")
                {
                    RemoveFollowing(loggedInStudentNo, followingName);
                    uI.UnFollowNotif();

                }
                return;
            }

            Acc = GetAccountByUsername(followingName);


            string statement = "INSERT INTO Following ( StudentNo, FollowingName, FollowingCourse, FollowingSection) " +
                "VALUES (@StudentNo, @FollowingName, @FollowingCourse, @FollowingSection)";
            SqlCommand command = new SqlCommand(statement, sqlconnection);

            foreach (var accountList in Acc)
            {
                command.Parameters.AddWithValue("@StudentNo", loggedInStudentNo);
                command.Parameters.AddWithValue("@FollowingName", accountList.Username);
                command.Parameters.AddWithValue("@FollowingCourse", accountList.Course);
                command.Parameters.AddWithValue("@FollowingSection", accountList.Section);
            }

            sqlconnection.Open();
            command.ExecuteNonQuery();

            foreach (var accountList in Acc)
            {
                uI.FollowingNotif(accountList.Username);
            }
            sqlconnection.Close();

        }
        private bool IsFollowing(string loggedInStudentNo, string followingName)
        {
            bool itExists = false;
            string statement = "SELECT * FROM Following WHERE StudentNo = @StudentNo AND FollowingName = @FollowingName";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            sqlconnection.Open();
            command.Parameters.AddWithValue("@StudentNo", loggedInStudentNo);
            command.Parameters.AddWithValue("@FollowingName", followingName);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                itExists = true;
            }
            sqlconnection.Close();
            return itExists;

        }
        public void RemoveFollowing(string loggedInStudentNo, string followName)
        {
            string statement = "DELETE FROM Following WHERE StudentNo = @StudentNo AND FollowingName = @FollowingName";
            SqlCommand command = new SqlCommand(statement, sqlconnection);

            command.Parameters.AddWithValue("@StudentNo", loggedInStudentNo);
            command.Parameters.AddWithValue("@FollowingName", followName);

            sqlconnection.Open();
            command.ExecuteNonQuery();
            sqlconnection.Close();
        }
        public void RemoveBlocked(string loggedInStudentNo, string blockedName)
        {
            string statement = "DELETE FROM Blocked WHERE StudentNo = @StudentNo AND BlockedName = @BlockedName";
            SqlCommand command = new SqlCommand(statement, sqlconnection);

            command.Parameters.AddWithValue("@StudentNo", loggedInStudentNo);
            command.Parameters.AddWithValue("@BlockedName", blockedName);

            sqlconnection.Open();
            command.ExecuteNonQuery();
            sqlconnection.Close();
        }

        public bool InsertBlocked(string loggedInStudentNo, string blockedName)
        {
            if (IsBlocked(loggedInStudentNo, blockedName))
            {
                uI.AlreadyBlockNotif();
                return false;
            }

            Acc = GetAccountByUsername(blockedName);

            string query = "INSERT INTO Blocked (StudentNo, BlockedName, BlockedCourse, BlockedSection)" +
                "VALUES (@StudentNo, @BlockedName, @BlockedCourse, @BlockedSection)";

            SqlCommand command = new SqlCommand(query, sqlconnection);

            foreach (var accountList in Acc)
            {
                command.Parameters.AddWithValue("@StudentNo", loggedInStudentNo);
                command.Parameters.AddWithValue("@BlockedName", accountList.Username);
                command.Parameters.AddWithValue("@BlockedCourse", accountList.Course);
                command.Parameters.AddWithValue("@BlockedSection", accountList.Section);
            }
            sqlconnection.Open();
            command.ExecuteNonQuery();

            foreach (var accountList in Acc)
            {
                uI.BlockNotif(accountList.Username);
            }
            sqlconnection.Close();
            return true;
        }

        public bool IsBlocked(string loggedInStudentNo, string blockedName)
        {
            bool itExists = false;

            string statement = "SELECT * FROM Blocked WHERE StudentNo = @StudentNo AND BlockedName = @BlockedName ";
            SqlCommand command = new SqlCommand(statement, sqlconnection);
            sqlconnection.Open();
            command.Parameters.AddWithValue("@StudentNo", loggedInStudentNo);
            command.Parameters.AddWithValue("@BlockedName", blockedName);
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                itExists = true;
            }
            sqlconnection.Close();
            return itExists;
        }

        



    }
}
