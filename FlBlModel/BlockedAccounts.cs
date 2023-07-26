using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlBlModel
{
    public class BlockedAccounts
    {
        public BlockedAccounts(string blockerUser, string studentUser)
        {
            BlockerUser = blockerUser;
            StudentUser = studentUser;
        }

        public string blocker { get; set; }
        public string blocked { get; set; }
        public string BlockerUser { get; set; }
        public string StudentUser { get; set; }

        public static void Add(BlockedAccounts newAccounts)
        {
            throw new NotImplementedException();
        }

        public static BlockedAccounts FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public static void Remove(BlockedAccounts accounts)
        {
            throw new NotImplementedException();
        }
    }
}
