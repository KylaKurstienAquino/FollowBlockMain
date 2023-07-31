using FlBlModel;
using FlBlUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlBlData
{
    public class ToShowData
    {
        static SqlData sqlDataAccess = new();
        static List<Blocked> Block = new();
        static List<Following> Flwing = new();
        static List<Follower> Flwers = new();
        static List<Accounts> Account = new();
        static UI uI = new();

        public void ShowSuggestions(string course, string section, string studentNo)
        {
            Account = sqlDataAccess.GetCourseSection(course, section, studentNo);

            foreach (var account in Account)
            {
                uI.SuggestionLists(account.Username, account.Course, account.Section);
            }

        }
        public void ShowFollowingList(string accountFollowing)
        {
            Flwing = sqlDataAccess.GetFollowingList(accountFollowing);

            if (Flwing.Count == 0)
            {
                uI.NoFollowing();
            }
            else if (Flwing.Count > 0)
            {
                foreach (var tofollow in Flwing)
                {
                    uI.FollowingLists(tofollow.FollowingName, tofollow.FollowingCourse, tofollow.FollowingSection);
                }
            }
        }
        public void ShowFollowerList(string accountFollower)
        {
            Flwers = sqlDataAccess.GetFollowerList(accountFollower);

            if (Flwers.Count == 0)
            {
                uI.NoFollower();
            }
            else
            {
                foreach (var thefollower in Flwers)
                {
                    uI.FollowerLists(thefollower.FollowerName, thefollower.FollowerCourse, thefollower.FollowerSection);
                }
            }
        }
        public void ShowBlockedList(string accountBlocked)
        {
            Block = sqlDataAccess.GetBlockedList(accountBlocked);

            if (Block.Count == 0)
            {
                uI.NoBlock();
            }
            else if (Block.Count > 0)
            {
                foreach (var blocked in Block)
                {
                    uI.BlockLists(blocked.BlockedName);
                }
            }

        }
    }
}
