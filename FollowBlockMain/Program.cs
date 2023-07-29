using System;
using System.Linq;
using FlBlData;
using FlBlRules;
using FlBlModel;
using FlBlUI;

namespace FollowBlockMain
{
    public class Program
    {
        static FollowBlockRules _rulelayer = new();
        static UI uI = new UI();

            public static void Main(string[] args)
            {
                do
                {
                    string input = Welcome();

                    switch (input)
                    {
                        case "1":
                            AccLogIn();
                            break;

                        case "2":
                            GetStudentNo();
                            break;
                    }

                    if (input.ToLower() == "x")
                    {
                        uI.Terminated();
                        break;
                    }
                } while (true);
            }

            static string Welcome()
            {
                uI.WelcomeMenu();
                string choice = Console.ReadLine();
                return choice;
            }
            static void AccLogIn()
            {
                var (studentNo, password) = UI.ToLogIn();
                _rulelayer.LogIn(studentNo, password);
            }

            static void GetStudentNo()
            {
                uI.ToSignUp();
                string studentNo = Console.ReadLine();
                _rulelayer.SignUpStudentNo(studentNo);
            }

            


    }
}
