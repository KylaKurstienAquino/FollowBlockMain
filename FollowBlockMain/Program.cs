using System;
using System.Linq;
using FlBlData;
using FlBlModel;
using FlBlRules;

namespace FollowBlockMain
{
    class Program
    {
        public static void Main ()
        {
            static FollowBlockRules _rulelayer = new();
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
                        Console.WriteLine("Program Terminated");
                        break;
                    }
                } while (true);
            }

            static string Welcome()
            {
                Console.WriteLine("=WELCOME=");
                Console.WriteLine("1 - Log In");
                Console.WriteLine("2 - Sign Up");
                Console.WriteLine("x - Exit");
                Console.WriteLine("\nEnter here: ");
                string choice = Console.ReadLine();

                return choice;
            }
            static void AccLogIn()
            {
                Console.WriteLine("\nEnter your StudentNo: ");
                string studentNo = Console.ReadLine();

                Console.WriteLine("Enter your Password: ");
                string passWord = Console.ReadLine();

                _rulelayer.LogIn(studentNo, passWord);
            }

            static void GetStudentNo()
            {
                Console.WriteLine("Enter Student Number: ");
                string studentNo = Console.ReadLine();

                _rulelayer.SignUpStudentNo(studentNo);
            }
        }

    }
}
