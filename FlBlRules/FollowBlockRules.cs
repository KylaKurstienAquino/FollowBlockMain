 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlData;
using FlBlModel;

namespace FlBlRules
{
    public class FollowBlockRules
    {
        static SqlData sqlDataAccess = new();
        static List<Accounts> account = new();
        static SuggestData suggests = new();
        static BlockData block = new();
        static FollowData follow = new();
        static string choiceToShow;

        public void LogIn(string studentNo, string password)
        {
            account = sqlDataAccess.GetAccountByStudentNo(studentNo, password);

            foreach (var accounts in account)
            {
                if (accounts.StudentNo.Contains(studentNo) || accounts.Password.Contains(password))
                {
                    Console.WriteLine("\nWelcome " + accounts.Username);

                    if (accounts.Status == "newAcc")
                    {
                        suggests.ShowSuggestions(accounts.Course, accounts.Section, accounts.StudentNo);
                        
                        do
                        {
                            Console.WriteLine("\npress F if you wish to follow");
                            Console.WriteLine("press B if you wish to block");
                            Console.WriteLine("press x to cancel");
                            string press = Console.ReadLine().ToUpper();

                            switch (press)
                            {
                                case "F":
                                    Console.WriteLine("Enter the username you want to follow:");
                                    string username = Console.ReadLine();
                                    account = sqlDataAccess.GetAccountByUsername(username);
                                    foreach (var getFollow in account)
                                    {
                                        sqlDataAccess.InsertFollowing(getFollow.StudentNo, getFollow.Username);
                                        sqlDataAccess.InsertFollower(getFollow.StudentNo, getFollow.Username);
                                    }
                                    break;

                                case "B":
                                    Console.WriteLine("Enter the username you want to block:");
                                    string toblockname = Console.ReadLine();
                                    account = sqlDataAccess.GetAccountByUsername(toblockname);
                                    foreach (var getFollow in account)
                                    {
                                        sqlDataAccess.InsertBlocked(getFollow.StudentNo, getFollow.Username);
                                    }
                                    break;
                            }
                            sqlDataAccess.ChangeStatus(studentNo, password);

                            if (press.ToLower() == "x")
                            {

                                break;
                            }
                        } while (true);
                    }

                    do
                    {
                        foreach (var accountList in account)
                        {
                            choiceToShow = ShowMainMenu();
                            switch (choiceToShow)
                            {
                                case "1":
                                    Console.WriteLine("Enter the username you want to search:");
                                    string searchName = Console.ReadLine();
                                        SearchAccount(accounts.StudentNo, searchName);

                                    break;

                                case "2":
                                    Console.WriteLine("Following List:\n");
                                    follow.ShowFollowingList(accounts.StudentNo);
                                    break;

                                case "3":
                                    Console.WriteLine("Follower List:\n");
                                    follow.ShowFollowerList(accounts.StudentNo);
                                    break;

                                case "4":
                                    block.ShowBlockedList(accounts.StudentNo);
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        }
                        if (choiceToShow.ToLower() == "x")
                        {

                            break;
                        }
                    } while (choiceToShow.ToLower() != "x");
                }
                else if (!accounts.StudentNo.Contains(studentNo) || !accounts.Password.Contains(password))
                {
                    Console.WriteLine("Invalid student number or password");
                }
                else if (!accounts.StudentNo.Contains(studentNo))
                {
                    Console.WriteLine("Invalid student number");
                }
                else if (!accounts.Password.Contains(password))
                {
                    Console.WriteLine("Invalid password");
                }
                else
                { Console.WriteLine("\nInvalid"); }
            }

        }

        static void SearchAccount(string studentNo, string searchName)
        {
            account = sqlDataAccess.GetAccountByUsername(searchName);

            foreach (var accounts in account)
            {
                if (sqlDataAccess.IsBlocked(studentNo, searchName))
                {
                    Console.WriteLine("Account is blocked. Do you want to unblock it? (Y/N)");
                    string choose = Console.ReadLine().ToUpper();
                    if (choose == "Y")
                    {
                        sqlDataAccess.RemoveBlocked(studentNo, searchName);
                        Console.WriteLine("Account unblocked.");

                    }
                    return;
                }

                else if (accounts.Username.Contains(searchName))
                {
                    foreach (var display in account)
                    {
                        Console.WriteLine("\nStudentNo: " + display.StudentNo);
                        Console.WriteLine("Username: " + display.Username);
                        Console.WriteLine("Course: " + display.Course);
                        Console.WriteLine("Section: " + display.Section);
                    }

                    Console.WriteLine("Enter F to follow, B to Block, or any key to Cancel: ");
                    string choice = Console.ReadLine().ToUpper();

                    switch (choice)
                    {
                        case "F":
                            sqlDataAccess.InsertFollowing(studentNo, searchName);
                            sqlDataAccess.InsertFollower(studentNo, searchName);
                            break;

                        case "B":
                            sqlDataAccess.InsertBlocked(studentNo, searchName);
                            break;

                        default:
                            break;

                    }
                }

                else
                {
                    Console.WriteLine("Account not found");
                    return;
                }

            }

        }

        public void SignUpStudentNo(string studentNo)
        {
            account = sqlDataAccess.GetStudentNumberForSignUp(studentNo);

            foreach (var accounts in account)
            {
                if (sqlDataAccess.AlreadyExists(studentNo))
                {
                    Console.WriteLine("You are already registered!");
                }

                else if (accounts.StudentNo.Contains(studentNo))
                {
                    Console.WriteLine("Welcome to PUPHub!\n");
                    Console.WriteLine("Please enter your credentials:\n");

                    Console.WriteLine("Username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Course: ");
                    string course = Console.ReadLine();
                    Console.WriteLine("Section: ");
                    string section = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();

                    CreateAccount(accounts.StudentNo, username, course, section, password);
                }
                else
                {
                    Console.WriteLine("You are not registered as a PUP Student!");
                }
            }
        }

        public void CreateAccount(string studentNo, string username, string course, string section, string password)
        {
            Accounts newacc = new()
            {
                StudentNo = studentNo,
                Username = username,
                Password = password,
                Course = course,
                Section = section,
                Status = "newAcc"
            };

            sqlDataAccess.CreateNewAccount(newacc);
        }
        static string ShowMainMenu()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Search for an account");
            Console.WriteLine("2. Show Following List");
            Console.WriteLine("3. Show Follower List");
            Console.WriteLine("4. Show Blocked List");
            Console.WriteLine("x = Log Out");
            Console.WriteLine("Enter: ");
            string choice = Console.ReadLine();
            return choice;
        }

    }



}