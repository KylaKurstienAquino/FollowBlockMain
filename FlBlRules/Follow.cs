using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlData;
using FlBlModel;

namespace FlBlRules
{
    public  class Follow
    {
        private FollowData followData;    

        public Follow() {
        
            followData = new FollowData();
        }

        public void FollowAcc(StudentAccount follower, StudentAccount studentUser) {

            followData.dataFollow(follower.user, studentUser.user);
        }

        public void UnfollowAcc(StudentAccount follower, StudentAccount studentUser)
        {

            followData.dataUnfollow(follower.user, studentUser.user);
        }
    }
}

public class FollowData
{
    private List<FollowedAccounts> followedAccounts;

    public FollowData()
    {
        followedAccounts = new List<FollowedAccounts>();
    }

    public void dataFollow(string followerUser, string studentUser)
    {
        if (followedAccounts.Any(r => r.FollowerUser == followerUser && r.StudentUser == studentUser))
        {
            Console.WriteLine("Already following.");
            return;
        }

        FollowedAccounts newAccounts = new FollowedAccounts(followerUser, studentUser);
        FollowedAccounts.Add(newAccounts);

        Console.WriteLine($"User '{followerUser}' is now following '{studentUser}'.");
    }

    public void dataUnfollow(string followerUser, string studentUser)
    {
        FollowedAccounts accounts = followedAccounts.FirstOrDefault(r => r.FollowerUser == followerUser && r.StudentUser == studentUser);
        
        if (accounts != null)
        {
            FollowedAccounts.Remove(accounts);
            Console.WriteLine($"User '{followerUser}' has unfollowed '{studentUser}'.");
        }
        else
        {
            Console.WriteLine("No existing followed account found.");
        }
    }
}
