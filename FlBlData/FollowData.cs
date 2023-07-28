using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlModel;


namespace FlBlData
{
    public class FollowData
    {
        static SqlData sqlDataAccess = new();
        static List<Following> Flwing = new();
        static List<Follower> Flwers = new();
        public void ShowFollowingList(string accountFollowing)
        {
            Flwing = sqlDataAccess.GetFollowingList(accountFollowing);

            if (Flwing.Count == 0)
            {
                Console.WriteLine("You are not following anyone.");
            }
            else if (Flwing.Count > 0)
            {
                foreach (var tofollow in Flwing)
                {
                    Console.WriteLine("StudentNo: " + tofollow.StudentNo);
                    Console.WriteLine("Username: " + tofollow.FollowingName);
                    Console.WriteLine("Course: " + tofollow.FollowingCourse);
                    Console.WriteLine("Section: " + tofollow.FollowingSection);
                    Console.WriteLine();
                }
            }
        }

        public void ShowFollowerList(string accountFollower)
        {
            Flwers = sqlDataAccess.GetFollowerList(accountFollower);

            if (Flwers.Count == 0)
            {
                Console.WriteLine("You have no followers.");
            }
            else
            {
                foreach (var thefollower in Flwers)
                {
                    Console.WriteLine("StudentNo: " + thefollower.StudentNo);
                    Console.WriteLine("Username: " + thefollower.FollowerName);
                    Console.WriteLine("Course: " + thefollower.FollowerCourse);
                    Console.WriteLine("Section: " + thefollower.FollowerSection);
                    Console.WriteLine();
                }
            }
        }
    }
}
