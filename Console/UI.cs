using System;
using System.Linq;

namespace FlBlUI
{
    public class UI
    {
        public void BlockLists(string blockname)
        {
            Console.WriteLine("\nUsername: " + blockname);;
            Console.WriteLine();
        }
        public void NoBlock()
        {
            Console.WriteLine("No blocked list to show.");
        }
        public void FollowerLists(string followname, string course, string section)
        {
            Console.WriteLine("Username: " + followname);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Section: " + section);
            Console.WriteLine();
        }
        public void NoFollower()
        {
            Console.WriteLine("You have no followers.");
        }
        public void FollowingLists(string followingname, string course, string section)
        {
            Console.WriteLine("Username: " + followingname);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Section: " + section);
            Console.WriteLine();
        }
        public void NoFollowing()
        {
            Console.WriteLine("You are not following anyone.");
        }
        public void SuggestionLists(string username, string course, string section)
        {
            Console.WriteLine("\nUsername: "+username);
            Console.WriteLine("Course: "+course);
            Console.WriteLine("Section: "+section);
        }
        public void BlockNotif(string get)
        {
            Console.WriteLine("You have blocked " + get);
        }
        public void AlreadyBlockNotif()
        {
            Console.WriteLine("You have already blocked this account.");
        }
        public void FollowingNotif(string get)
        {
            Console.WriteLine("You're now following " + get);
        }
        public void UnFollowNotif()
        {
            Console.WriteLine("Account unfollowed.");
        }
        public string ShowMainMenu()
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
        public void IfBlocked()
        {
            Console.WriteLine("Account is blocked. Do you want to unblock it? (Y/N)");
        }
        public void IfFollowing()
        {
            Console.WriteLine("Already following. Do you want to unfollow it? (Y/N)");
        }
        public void UnblockedNotice()
        {
            Console.WriteLine("Account unblocked.");
        }
        public void ToDisplay(string studentNo, string username, string course, string section)
        {
            Console.WriteLine("\nStudentNo: " + studentNo);
            Console.WriteLine("Username: " + username);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Section: " + section);
        }
        public void EnterFB()
        {
            Console.WriteLine("\nEnter F to follow, B to Block, or X to Cancel: ");
        }
        public void AccNotFound()
        {
            Console.WriteLine("Account not found");
        }
        public void NameToFollow()
        {
            Console.WriteLine("Enter the username you want to follow:");
        }
        public void NameToBlock()
        {
            Console.WriteLine("Enter the username you want to block:");
        }
        public void ToSearch()
        {
            Console.WriteLine("Enter the username you want to search:");
        }
        public void BlockL()
        {
            Console.WriteLine("Blocked List:\n");
        }
        public void FlwerL()
        {
            Console.WriteLine("Follower List:\n");
        }
        public void FlwngL()
        {
            Console.WriteLine("Following List:\n");
        }
        public void ext()
        {
            Console.WriteLine("\nLog Out\n");
        }
        public void InvalidChoice()
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
        public void Invalid()
        {
            Console.WriteLine("Invalid student number or password");
        }
        public void WelcomeMenu()
        {
            Console.WriteLine("\n=WELCOME=\n");
            Console.WriteLine("1 - Log In");
            Console.WriteLine("2 - Sign Up");
            Console.WriteLine("x - Exit");
            Console.WriteLine("\nEnter here: ");
        }
        public void WelcomeName(string name)
        {
            Console.WriteLine("\nWelcome " + name);
        }
        public static (string username, string course, string section, string password) WelcomeToPupHub()
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

            return (username, course, section, password);
        }
        public void NotRegistered()
        {
            Console.WriteLine("You are not registered as a PUP Student!");
        }
        public void AlreadyRegistered()
        {
            Console.WriteLine("You are already registered!");
        }
        public static (string studentNo, string password) ToLogIn()
        {
            Console.WriteLine("\nEnter your StudentNo: ");
            string studentNo = Console.ReadLine();

            Console.WriteLine("Enter your Password: ");
            string password = Console.ReadLine();

            return (studentNo, password);
        }
        public void ToSignUp()
        {
            Console.WriteLine("Enter Student Number: ");
        }
        public void Terminated()
        {
            Console.WriteLine("Program Terminated");
        }




    }

}