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
            var userBlock = new Block();
            var userFollow = new Follow();

            var follower = new Blocked();
            var student = new Blocked();
            var blocker = new Blocked();

            userFollow.FollowAcc(follower, student);
            userFollow.UnfollowAcc(follower, student);

            userBlock.BlockAcc(blocker, student);
            userBlock.UnblockAcc(blocker, student);
        }

    }
}
