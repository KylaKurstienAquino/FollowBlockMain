using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlBlModel
{
    public class FollowedAccounts
    {
        public FollowedAccounts(string followerUser, string studentUser)
        {
            FollowerUser = followerUser;
            StudentUser = studentUser;
        }

        public string follower { get; set; }
        public string following { get; set; }
        public string FollowerUser { get; set; }
        public string StudentUser { get; set; }

        public static void Add(FollowedAccounts newAccounts)
        {
            throw new NotImplementedException();
        }

        public static FollowedAccounts FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public static void Remove(FollowedAccounts accounts)
        {
            throw new NotImplementedException();
        }
    }
}
