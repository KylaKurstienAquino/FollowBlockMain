using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlData;
using FlBlModel;
using FlBlUI;

namespace FlBlRules
{
    public class FollowBlockRules
    {
        static SqlData sqlDataAccess = new();
        static List<Accounts> account = new();
        static UI uI = new();
        static ToShowData toShowData = new();
        static string choiceToShow, press;

        public void LogIn(string studentNo, string password)
        {
            account = sqlDataAccess.GetAccountByStudentNo(studentNo, password);

            foreach (var accounts in account)
            {
                
                    if (accounts.StudentNo.Contains(studentNo) || accounts.Password.Contains(password))
                    {
                        uI.WelcomeName(accounts.Username);

                        if (accounts.Status == "newAcc")
                        {
                            toShowData.ShowSuggestions(accounts.Course, accounts.Section, accounts.StudentNo);
                            do{
                            uI.EnterFB();
                                press = Console.ReadLine().ToUpper();

                                switch (press)
                                {
                                    case "F":
                                        uI.NameToFollow();
                                        string username = Console.ReadLine();
                                        account = sqlDataAccess.GetAccountByUsername(username);
                                        foreach (var getFollow in account)
                                        {
                                            sqlDataAccess.InsertFollowing(accounts.StudentNo, getFollow.Username);
                                            sqlDataAccess.InsertFollower(accounts.StudentNo, getFollow.Username);
                                        }
                                        break;

                                    case "B":
                                        uI.NameToBlock();
                                        string toblockname = Console.ReadLine();
                                        account = sqlDataAccess.GetAccountByUsername(toblockname);
                                        foreach (var getBlock in account)
                                        {
                                            sqlDataAccess.InsertBlocked(accounts.StudentNo, getBlock.Username);
                                        }
                                        break;
                               
                                   
                                }
                            sqlDataAccess.ChangeStatus(studentNo, password);
                            if (press.ToUpper() == "X")
                            {
                                break;
                            }
                        } while (true);
                        }

                        do
                        {
                            foreach (var accountList in account)
                            {
                                choiceToShow = uI.ShowMainMenu();
                                switch (choiceToShow)
                                {
                                    case "1":
                                        uI.ToSearch();
                                        string searchName = Console.ReadLine();
                                        SearchAccount(accounts.StudentNo, searchName);
                                        break;

                                    case "2":
                                        uI.FlwngL();
                                        toShowData.ShowFollowingList(accounts.StudentNo);
                                        break;

                                    case "3":
                                        uI.FlwerL();
                                        toShowData.ShowFollowerList(accounts.StudentNo);
                                        break;

                                    case "4":
                                        uI.BlockL();
                                        toShowData.ShowBlockedList(accounts.StudentNo);
                                        break;

                                    case "x":
                                        uI.ext();
                                        break;

                                    default:


                                        if (choiceToShow.ToLower() == "x")
                                        {

                                        }
                                        else

                                        {
                                            uI.InvalidChoice();
                                        }
                                        break;
                                }
                            }

                        } while (choiceToShow.ToLower() != "x");
                    }
     
              else if (!accounts.StudentNo.Contains(studentNo) || !accounts.Password.Contains(password))
               {
                  uI.Invalid();
                }
                else if (!accounts.StudentNo.Contains(studentNo))
                {
                    uI.Invalid();
                }
                else if (!accounts.Password.Contains(password))
                {
                   uI.Invalid();
                }
                else
                { uI.Invalid(); }

            }

        }

        static void SearchAccount(string studentNo, string searchName)
        {
            account = sqlDataAccess.GetAccountByUsername(searchName);

            foreach (var accounts in account)
            {
                if (sqlDataAccess.IsBlocked(studentNo, searchName))
                {
                    uI.IfBlocked();
                    string choose = Console.ReadLine().ToUpper();
                    if (choose == "Y")
                    {
                        sqlDataAccess.RemoveBlocked(studentNo, searchName);
                        uI.UnblockedNotice();

                    }
                    return;
                }

                else if (accounts.Username.Contains(searchName))
                {
                    foreach (var display in account)
                    {
                        uI.ToDisplay(display.StudentNo, display.Username, display.Course, display.Section);
                    }

                    if (sqlDataAccess.IsFollowing(studentNo, searchName))
                    {
                        uI.IfFollowing();
                        string choose = Console.ReadLine().ToUpper();
                        if (choose == "Y")
                        {
                            sqlDataAccess.RemoveFollowing(studentNo, searchName);
                            uI.UnFollowNotif();

                        }
                        return;
                    }


                    uI.EnterFB();
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
                    uI.AccNotFound();
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
                    uI.AlreadyRegistered();
                }

                else if (accounts.StudentNo.Contains(studentNo))
                {
                    var (username, course, section, password) = UI.WelcomeToPupHub();

                    CreateAccount(accounts.StudentNo, username, course, section, password);
                }
                else
                {
                    uI.NotRegistered();
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

    }



}